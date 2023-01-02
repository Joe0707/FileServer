using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//烘焙配置
public struct BakeConfig
{
    public string SceneName;//场景名
    public string LightName;//光效名
}
//烘焙关卡
public class BakeLevel
{
    public string LevelIDs = "";//烘焙关卡id
}
//烘焙上下文
public class BakeContext
{
    public LightmapParameters LMP;//光照贴图参数
}

//编辑器工具
public static class EditorUtils
{
    const string OptimizeBar = "Tools/Optimize";
    [MenuItem("Tools/Clear Console #x")]//SHIFT + X
    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(ActiveEditorTracker));
        var type = assembly.GetType("UnityEditorInternal.LogEntries");
        if (type == null)
        {
            type = assembly.GetType("UnityEditor.LogEntries");
        }
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    [MenuItem("Tools/ChangeToolShader")]
    public static void ChangeToonShader()
    {
        var gameobjs = Selection.gameObjects;
        var renders = new List<Renderer>();
        for (var i = 0; i < gameobjs.Length; i++)
        {
            var gameObj = gameobjs[i];
            var objrenders = gameObj.GetComponentsInChildren<Renderer>();
            renders.AddRange(objrenders);
        }
        //   var renders = GameObject.FindObjectsOfType<Renderer>();
        var path = "Assets/Shaders/Ramp_Texture0.psd";
        var RampTexture = AssetDatabase.LoadAssetAtPath<Texture>(path);
        var toonshader = Shader.Find("Custom/Toon Shading");
        for (var i = 0; i < renders.Count; i++)
        {
            var render = renders[i];
            if (render.gameObject != null)
            {
                if (render.gameObject.tag != "NoToon")
                {
                    var mats = render.sharedMaterials;
                    for (var j = 0; j < mats.Length; j++)
                    {
                        var mat = mats[j];
                        if (mat != null && toonshader != null)
                        {
                            mat.shader = toonshader;
                            mat.SetColor("_AmbientColor", new Color(0.1f, 0.1f, 0.1f, 1));
                            mat.SetFloat("_Outline", 0);
                            mat.SetFloat("_SpecularScale", 0);
                            mat.SetTexture("_Ramp", RampTexture);
                        }
                    }
                }
            }
        }
    }

    [MenuItem("Tools/ChangeStandardShader")]
    public static void ChangeStandardShader()
    {
        var gameobjs = Selection.gameObjects;
        var renders = new List<Renderer>();
        for (var i = 0; i < gameobjs.Length; i++)
        {
            var gameObj = gameobjs[i];
            var objrenders = gameObj.GetComponentsInChildren<Renderer>();
            renders.AddRange(objrenders);
        }
        var standardshader = Shader.Find("Standard");
        for (var i = 0; i < renders.Count; i++)
        {
            var render = renders[i];
            if (render.gameObject != null)
            {
                if (render.gameObject.tag != "NoToon")
                {
                    var mats = render.sharedMaterials;
                    for (var j = 0; j < mats.Length; j++)
                    {
                        var mat = mats[j];
                        if (mat != null && standardshader != null)
                        {
                            mat.shader = standardshader;
                            // mat.SetColor("_AmbientColor", new Color(0.1f, 0.1f, 0.1f, 1));
                            // mat.SetFloat("_Outline", 0);
                            // mat.SetFloat("_SpecularScale", 0);
                            // mat.SetTexture("_Ramp", RampTexture);
                        }
                    }
                }
            }
        }
    }

    [MenuItem("Tools/ChangeLeafToolShader")]
    public static void ChangeSelectedLeafShader()
    {
        var gameobjs = Selection.gameObjects;
        var leafshader = Shader.Find("Hidden/Nature/Tree Creator Leaves Optimized");
        for (var i = 0; i < gameobjs.Length; i++)
        {
            var obj = gameobjs[i];
            var renderer = obj.GetComponent<Renderer>();
            var mats = renderer.sharedMaterials;
            for (var j = 0; j < mats.Length; j++)
            {
                var mat = mats[j];
                if (mat != null && leafshader != null)
                {
                    mat.shader = leafshader;
                }
            }

        }
    }
    [MenuItem("Tools/ChangeObjOverProjection")]
    public static void ChangeObjOverProjection()
    {
        var mats = new List<Material>();
        var gameobjs = Selection.gameObjects;
        for (var i = 0; i < gameobjs.Length; i++)
        {
            var renders = gameobjs[i].GetComponentsInChildren<Renderer>();
            for (var j = 0; j < renders.Length; j++)
            {
                var sharedmats = renders[j].sharedMaterials;
                for (var k = 0; k < sharedmats.Length; k++)
                {
                    mats.Add(sharedmats[k]);
                }
            }
        }
        for (var i = 0; i < mats.Count; i++)
        {
            mats[i].renderQueue = 3000;
        }
    }
    [MenuItem("Tools/SetMatPropertiesWithMetal %F1")] //CTRL+F1
    public static void SetMetalMatProperties()
    {
        var mats = new List<Material>();
        var objects = Selection.objects;
        for (var i = 0; i < objects.Length; i++)
        {
            var obj = objects[i];
            if (obj is GameObject)
            {
                var gameObj = obj as GameObject;
                var renders = gameObj.GetComponentsInChildren<Renderer>();
                for (var j = 0; j < renders.Length; j++)
                {
                    var sharedmats = renders[j].sharedMaterials;
                    for (var k = 0; k < sharedmats.Length; k++)
                    {
                        mats.Add(sharedmats[k]);
                    }
                }
            }
            else if (obj is Material)
            {
                var matObj = obj as Material;
                mats.Add(matObj);
            }
        }
        int color = System.Convert.ToInt32("BE", 16);
        var total = System.Convert.ToInt32("FF", 16);
        float colorf = (float)color / (float)total;
        var diffuseColor = new Color(colorf, colorf, colorf, 1);
        for (var i = 0; i < mats.Count; i++)
        {
            var mat = mats[i];
            mat.SetColor("_Color", diffuseColor);
            mat.SetFloat("_Outline", 1f);
            mat.SetFloat("_SpecShininess", 25f);
            mat.SetFloat("_IndirectDiffuseCheck", 0);
            mat.renderQueue = 3000;
        }
        for (var i = 0; i < objects.Length; i++)
        {
            var obj = objects[i];
            EditorUtility.SetDirty(obj);
        }
    }

    [MenuItem("Tools/SetMatPropertiesWithoutMetal %F3")] //CTRL+F3
    public static void SetNoMetalMatProperties()
    {
        var mats = new List<Material>();
        var objects = Selection.objects;
        for (var i = 0; i < objects.Length; i++)
        {
            var obj = objects[i];
            if (obj is GameObject)
            {
                var gameObj = obj as GameObject;
                var renders = gameObj.GetComponentsInChildren<Renderer>();
                for (var j = 0; j < renders.Length; j++)
                {
                    var sharedmats = renders[j].sharedMaterials;
                    for (var k = 0; k < sharedmats.Length; k++)
                    {
                        mats.Add(sharedmats[k]);
                    }
                }
            }
            else if (obj is Material)
            {
                var matObj = obj as Material;
                mats.Add(matObj);
            }
        }
        int color = System.Convert.ToInt32("BE", 16);
        var total = System.Convert.ToInt32("FF", 16);
        float colorf = (float)color / (float)total;
        var diffuseColor = new Color(colorf, colorf, colorf, 1);
        for (var i = 0; i < mats.Count; i++)
        {
            var mat = mats[i];
            mat.SetColor("_Color", diffuseColor);
            mat.SetFloat("_Outline", 1f);
            mat.SetFloat("_SpecShininess", 25f);
            mat.SetFloat("_IndirectDiffuseCheck", 0);
            mat.SetFloat("_SpecCheck", 0);
            mat.renderQueue = 3000;
        }
        for (var i = 0; i < objects.Length; i++)
        {
            var obj = objects[i];
            EditorUtility.SetDirty(obj);
        }
    }
    //生成替换图片压缩格式
    [MenuItem(OptimizeBar + "/CompressLMTexture")]
    public static void CompressLMTexture()
    {
        string[] texPaths = Directory.GetFiles(Application.dataPath + "/Scenes", "*.exr", SearchOption.AllDirectories);
        foreach (string texPath in texPaths)
        {
            if (texPath.Contains("Lightmap") == false)
            {
                continue;
            }
            //替换路径中的反斜杠为正
            var path = texPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            TextureImporter import = AssetImporter.GetAtPath(path) as TextureImporter;
            if (import != null)
            {
                var setting = import.GetPlatformTextureSettings("Android");
                if (setting.format != TextureImporterFormat.ETC_RGB4 || setting.overridden == false)
                {
                    setting.format = TextureImporterFormat.ETC_RGB4;
                    setting.overridden = true;
                    import.SetPlatformTextureSettings(setting);
                    import.SaveAndReimport();
                }
            }
        }
        texPaths = Directory.GetFiles(Application.dataPath + "/Scenes", "*.png", SearchOption.AllDirectories);
        foreach (string texPath in texPaths)
        {
            if (texPath.Contains("Lightmap") == false)
            {
                continue;
            }
            //替换路径中的反斜杠为正
            var path = texPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            TextureImporter import = AssetImporter.GetAtPath(path) as TextureImporter;
            if (import != null)
            {
                var setting = import.GetPlatformTextureSettings("Android");
                if (setting.format != TextureImporterFormat.EAC_R || setting.overridden == false)
                {
                    setting.format = TextureImporterFormat.EAC_R;
                    setting.overridden = true;
                    import.SetPlatformTextureSettings(setting);
                    import.SaveAndReimport();
                }
            }
        }
        AssetDatabase.Refresh();
    }


    //生成光照贴图Uv
    [MenuItem("Tools/GenerateLMUV")]
    public static void GenerateLMUV()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/Models/Scenes", "*.fbx", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            ModelImporter model = AssetImporter.GetAtPath(path) as ModelImporter;
            if (model != null)
            {
                if (model.generateSecondaryUV == false)
                {
                    model.generateSecondaryUV = true;
                    AssetDatabase.ImportAsset(path);
                }
            }
        }
    }
    //生成光照贴图Uv
    [MenuItem("Tools/ChangeEffectsLayer")]
    public static void ChangeEffectsLayer()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/LRS-BN-Effects", "*.prefab", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));

            var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (obj != null)
            {
                var trans = obj.GetComponentsInChildren<Transform>();
                for (var i = 0; i < trans.Length; i++)
                {
                    trans[i].gameObject.layer = LayerMask.NameToLayer("Effect");
                    EditorUtility.SetDirty(trans[i].gameObject);
                }
            }
        }
    }

    [MenuItem("Tools/DeleteHairAC")]
    static void DeleteHairAC()
    {
        string[] textureStrPaths = Directory.GetFiles(Application.dataPath + "/Descent/Resources/Parts", "*", SearchOption.AllDirectories).Where((s) =>
        {
            bool result = false;
            var fileName = s.Replace("\\", "/");
            if (fileName.EndsWith(".meta") == false)
            {
                var shotName = fileName.Substring(fileName.LastIndexOf("/") + 1, fileName.LastIndexOf(".") - 1 - fileName.LastIndexOf("/"));
                PartResResult parseResult;
                if (DescentEditorUtil.ParsePartResName(shotName, out parseResult))
                {
                    if (parseResult.type == EPartType.hair && (parseResult.subName == "a" || parseResult.subName == "c"))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }).ToArray();
        foreach (string textureStrPath in textureStrPaths)
        {
            var fileName = textureStrPath.Replace("\\", "/");
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
    [MenuItem("Tools/ChangeFXOption")]
    static void ChangeFXOption()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/LRS-BN-Effects", "*.prefab", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));

            var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (obj != null)
            {
                var ps = obj.GetComponentsInChildren<ParticleSystem>();
                var ischange = false;
                for (var i = 0; i < ps.Length; i++)
                {
                    var psitem = ps[i];
                    var main = psitem.main;
                    if (main.loop == true)
                    {
                        main.loop = false;
                        ischange = true;
                    }
                    EditorUtility.SetDirty(psitem.gameObject);
                }
                if (ischange)
                {
                    EditorUtility.SetDirty(obj);
                }
            }
        }
    }
    [MenuItem("Tools/ChangeFXLayer")]
    static void ChangeFXLayer()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/LRS-BN-Effects/Effect_Jmt/Resources", "*.prefab", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));

            var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (obj != null)
            {
                var trans = obj.GetComponentsInChildren<Transform>();
                for (var i = 0; i < trans.Length; i++)
                {
                    trans[i].gameObject.layer = LayerMask.NameToLayer("TransparentFX");
                    EditorUtility.SetDirty(trans[i].gameObject);
                }
            }
        }
        AssetDatabase.SaveAssets();
    }
    [MenuItem(OptimizeBar + "/OptimizeTerrainInstance")]
    static void OptimizeTerrainInstance()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                var terrains = GameObject.FindObjectsOfType<Terrain>();
                foreach (var terrain in terrains)
                {
                    if (terrain.drawInstanced == false)
                    {
                        terrain.drawInstanced = true;
                        EditorUtility.SetDirty(terrain);
                    }
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
        }
    }

    [MenuItem("Tools/ChangeProjectorOption")]
    static void ChangeProjectorOption()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                var pro = GameObject.FindObjectOfType<Projector>();
                pro.ignoreLayers = System.Int32.MaxValue;
                int terrain = 1 << LayerMask.NameToLayer("Terrain");
                pro.ignoreLayers = pro.ignoreLayers ^ terrain;
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
            // var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(path) as SceneAsset;
            // if (obj != null)
            // {
            //     var ps = SceneAsset.FindObjectOfType<Projector>();
            //     var ischange = false;
            //     for (var i = 0; i < ps.Length; i++)
            //     {
            //         var psitem = ps[i];
            //         var main = psitem.main;
            //         if (main.loop == true)
            //         {
            //             main.loop = false;
            //             ischange = true;
            //         }
            //         EditorUtility.SetDirty(psitem.gameObject);
            //     }
            //     if (ischange)
            //     {
            //         EditorUtility.SetDirty(obj);
            //     }
            // }
        }
    }
    [MenuItem("Tools/RemoveEdgeCamera")]
    static void RemoveEdgeCamera()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                var cameras = GameObject.FindObjectsOfType<Camera>();
                for (var i = 0; i < cameras.Length; i++)
                {
                    if (cameras[i].name == "EdgeCheckCamera")
                    {
                        GameObject.DestroyImmediate(cameras[i].gameObject);
                        break;
                    }
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
            // var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(path) as SceneAsset;
            // if (obj != null)
            // {
            //     var ps = SceneAsset.FindObjectOfType<Projector>();
            //     var ischange = false;
            //     for (var i = 0; i < ps.Length; i++)
            //     {
            //         var psitem = ps[i];
            //         var main = psitem.main;
            //         if (main.loop == true)
            //         {
            //             main.loop = false;
            //             ischange = true;
            //         }
            //         EditorUtility.SetDirty(psitem.gameObject);
            //     }
            //     if (ischange)
            //     {
            //         EditorUtility.SetDirty(obj);
            //     }
            // }
        }
    }

    public static void ResizeHeightmap(TerrainData terrainData, int resolution)
    {
        RenderTexture oldRT = RenderTexture.active;

        RenderTexture oldHeightmap = RenderTexture.GetTemporary(terrainData.heightmapTexture.descriptor);
        Graphics.Blit(terrainData.heightmapTexture, oldHeightmap);
#if UNITY_2019_3_OR_NEWER
        // terrain holes
        RenderTexture oldHoles = RenderTexture.GetTemporary(terrainData.holesTexture.width, terrainData.holesTexture.height);
        Graphics.Blit(terrainData.holesTexture, oldHoles);
#endif

        Undo.RegisterCompleteObjectUndo(terrainData, "Resize heightmap");

        float sUV = 1.0f;
        int dWidth = terrainData.heightmapResolution;
        int sWidth = resolution;

        Vector3 oldSize = terrainData.size;
        terrainData.heightmapResolution = resolution;
        terrainData.size = oldSize;

        oldHeightmap.filterMode = FilterMode.Bilinear;

        // Make sure textures are offset correctly when resampling
        // tsuv = (suv * swidth - 0.5) / (swidth - 1)
        // duv = (tsuv(dwidth - 1) + 0.5) / dwidth
        // duv = (((suv * swidth - 0.5) / (swidth - 1)) * (dwidth - 1) + 0.5) / dwidth
        // k = (dwidth - 1) / (swidth - 1) / dwidth
        // duv = suv * (swidth * k)		+ 0.5 / dwidth - 0.5 * k

        float k = (dWidth - 1.0f) / (sWidth - 1.0f) / dWidth;
        float scaleX = sUV * (sWidth * k);
        float offsetX = (float)(0.5 / dWidth - 0.5 * k);
        Vector2 scale = new Vector2(scaleX, scaleX);
        Vector2 offset = new Vector2(offsetX, offsetX);

        Graphics.Blit(oldHeightmap, terrainData.heightmapTexture, scale, offset);
        RenderTexture.ReleaseTemporary(oldHeightmap);

#if UNITY_2019_3_OR_NEWER
        oldHoles.filterMode = FilterMode.Point;
        Graphics.Blit(oldHoles, (RenderTexture)terrainData.holesTexture);
        RenderTexture.ReleaseTemporary(oldHoles);
#endif

        RenderTexture.active = oldRT;

        terrainData.DirtyHeightmapRegion(new RectInt(0, 0, terrainData.heightmapTexture.width, terrainData.heightmapTexture.height), TerrainHeightmapSyncControl.HeightAndLod);
#if UNITY_2019_3_OR_NEWER
        terrainData.DirtyTextureRegion(TerrainData.HolesTextureName, new RectInt(0, 0, terrainData.holesTexture.width, terrainData.holesTexture.height), false);
#endif
    }

    [MenuItem("Tools/Optimize/ChangeCameraOption")]
    static void ChangeCamera()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                //修改相机设置
                var mainCamera = Camera.main;
                if (mainCamera.gameObject.layer == LayerMask.NameToLayer("PostProcess"))
                {
                    //说明有hdr
                    mainCamera.allowHDR = true;
                }
                else
                {
                    mainCamera.allowHDR = false;
                }
                mainCamera.allowMSAA = false;
                //查找特效相机
                var fxCamera = mainCamera.transform.Find("FXCamera").GetComponent<Camera>();
                fxCamera.allowMSAA = false;
                fxCamera.allowHDR = false;
                EditorUtility.SetDirty(fxCamera);
                EditorUtility.SetDirty(mainCamera);
                // //修改Terrain的Resolution
                // var terrains = GameObject.FindObjectsOfType<Terrain>();
                // foreach (var terrain in terrains)
                // {
                //     if (terrain.heightmapPixelError != 15)
                //     {
                //         terrain.heightmapPixelError = 15;
                //         EditorUtility.SetDirty(terrain);
                //     }
                //     //检测分辨率
                //     if (terrain.terrainData.heightmapResolution != 65)
                //     {
                //         ResizeHeightmap(terrain.terrainData, 65);
                //         EditorUtility.SetDirty(terrain.terrainData);
                //     }
                // }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/Optimize/ChangeProjectCameraOption")]
    static void ChangeProjectCameraOption()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                //修改相机设置
                var slotCameraObj = GameObject.Find("SlotCamera");
                var slotCamera = slotCameraObj.GetComponent<Camera>();
                if (slotCamera.fieldOfView != 5)
                {
                    slotCamera.fieldOfView = 5;
                    EditorUtility.SetDirty(slotCamera);
                }
                var BlobProject = GameObject.FindObjectOfType<Projector>();
                if (BlobProject.fieldOfView != 5)
                {
                    BlobProject.fieldOfView = 5;
                    EditorUtility.SetDirty(BlobProject);
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/ChangeTerrainResolution")]
    static void ChangeTerrainResolution()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                //修改Terrain的Resolution
                var terrains = GameObject.FindObjectsOfType<Terrain>();
                foreach (var terrain in terrains)
                {
                    if (terrain.heightmapPixelError != 15)
                    {
                        terrain.heightmapPixelError = 15;
                        EditorUtility.SetDirty(terrain);
                    }
                    //检测分辨率
                    if (terrain.terrainData.heightmapResolution != 65)
                    {
                        ResizeHeightmap(terrain.terrainData, 65);
                        EditorUtility.SetDirty(terrain.terrainData);
                    }
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
            // var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(path) as SceneAsset;
            // if (obj != null)
            // {
            //     var ps = SceneAsset.FindObjectOfType<Projector>();
            //     var ischange = false;
            //     for (var i = 0; i < ps.Length; i++)
            //     {
            //         var psitem = ps[i];
            //         var main = psitem.main;
            //         if (main.loop == true)
            //         {
            //             main.loop = false;
            //             ischange = true;
            //         }
            //         EditorUtility.SetDirty(psitem.gameObject);
            //     }
            //     if (ischange)
            //     {
            //         EditorUtility.SetDirty(obj);
            //     }
            // }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    [MenuItem("Tools/AddFXCamera")]
    static void AddFXCamera()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                var cameras = GameObject.FindObjectsOfType<Camera>();
                for (var i = 0; i < cameras.Length; i++)
                {
                    if (cameras[i].name == "Main Camera")
                    {
                        //修改层级
                        int layer = System.Int32.MaxValue;
                        int fxlayer = 1 << LayerMask.NameToLayer("TransparentFX");
                        layer = layer ^ fxlayer;
                        cameras[i].cullingMask = cameras[i].cullingMask & layer;
                        //创建新相机
                        var fxcamera = new GameObject("FXCamera");
                        fxcamera.transform.parent = cameras[i].transform;
                        fxcamera.transform.localPosition = Vector3.zero;
                        fxcamera.transform.localRotation = Quaternion.identity;
                        var fxc = fxcamera.AddComponent<Camera>();
                        fxc.CopyFrom(cameras[i]);
                        fxc.cullingMask = fxlayer;
                        fxc.clearFlags = CameraClearFlags.Nothing;
                        fxc.allowMSAA = false;
                        fxc.depth = 0;
                    }
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
            // var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(path) as SceneAsset;
            // if (obj != null)
            // {
            //     var ps = SceneAsset.FindObjectOfType<Projector>();
            //     var ischange = false;
            //     for (var i = 0; i < ps.Length; i++)
            //     {
            //         var psitem = ps[i];
            //         var main = psitem.main;
            //         if (main.loop == true)
            //         {
            //             main.loop = false;
            //             ischange = true;
            //         }
            //         EditorUtility.SetDirty(psitem.gameObject);
            //     }
            //     if (ischange)
            //     {
            //         EditorUtility.SetDirty(obj);
            //     }
            // }
        }
    }

    [MenuItem("Tools/TestLoad")]
    static void TestLoad()
    {
        string CollectionPath = "AllShader/AllShaderVariants";
        var collection = Resources.Load<ShaderVariantCollection>(CollectionPath);

    }
    [MenuItem("Tools/ChangeABSceneLight")]
    static void ChangeABSceneLight()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                var lights = GameObject.FindObjectsOfType<Light>();
                for (var i = 0; i < lights.Length; i++)
                {
                    var light = lights[i];
                    if (light.GetComponent<MainLightColor>() != null)
                    {
                        //主光
                        light.shadowBias = 0.05f;
                        light.shadowNormalBias = 0.4f;
                        light.shadowNearPlane = 0.2f;
                    }
                }
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
            // var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(path) as SceneAsset;
            // if (obj != null)
            // {
            //     var ps = SceneAsset.FindObjectOfType<Projector>();
            //     var ischange = false;
            //     for (var i = 0; i < ps.Length; i++)
            //     {
            //         var psitem = ps[i];
            //         var main = psitem.main;
            //         if (main.loop == true)
            //         {
            //             main.loop = false;
            //             ischange = true;
            //         }
            //         EditorUtility.SetDirty(psitem.gameObject);
            //     }
            //     if (ischange)
            //     {
            //         EditorUtility.SetDirty(obj);
            //     }
            // }
        }
    }

    [MenuItem("Tools/ChangeSkyBox")]
    static void ChangeSkyBox()
    {
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/ABPackage/ABTest/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach (string modelPath in modelPaths)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            if (scene != null)
            {
                //校验是否设置过
                if (RenderSettings.skybox == null)
                {
                    continue;
                }
                //创建天空盒
                var skyBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                skyBox.transform.localScale = new Vector3(800, 800, 800);
                var render = skyBox.GetComponent<Renderer>();
                render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                render.receiveShadows = false;
                if (skyBox.GetComponent<BoxCollider>() != null)
                {
                    GameObject.DestroyImmediate(skyBox.GetComponent<BoxCollider>());
                }
                //创建天空盒材质
                //创建场景文件夹
                var sceneForderName = scene.name.Substring(0, scene.name.IndexOf("_Lighting"));
                var folderPath = Application.dataPath + SceneFolderDirectoryPath + sceneForderName;
                if (Directory.Exists(folderPath) == false)
                {
                    Debug.LogError($"文件夹{folderPath}不存在 无法创建天空盒物体材质");
                    continue;
                }
                //创建天空盒材质
                var matPath = folderPath + "/" + sceneForderName + "_skybox.mat";
                var matAssetPath = FullPath2AssetPath(matPath);
                Material mat = new Material(Shader.Find("Custom/Skybox/Cubemap"));
                var cubeMap = RenderSettings.skybox.GetTexture("_Tex");
                mat.SetTexture("_Tex", cubeMap);
                //保存mat
                AssetDatabase.CreateAsset(mat, matAssetPath);
                render.sharedMaterial = mat;
                //去掉原来设置的天空盒
                RenderSettings.skybox = null;
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
            }
        }
    }

    #region AutoBake
    static string BakeConfigPath = "/Editor/BakeConfig.json";   //烘焙配置路径
    static string LevelDirectoryPath = "Data/LevelJson/";   //关卡配置路径
    static string PrefabDirectoryPath = "/LRS-BN-SceneRes/ScenePrefab/";    //烘焙预制体路径
    static float DecreaseFactor = 0.375f;//点光源衰减系数
    static string LightMapParameterPath = "/Scenes/Terrain.giparams";   //烘焙参数路径
    static string SceneFolderDirectoryPath = "/LRS-BN-SceneRes/Models/Scenes/"; //场景文件夹路径
    static string SkyBoxPath = "/LRS-BN-SceneRes/Table/SkyBox.xls"; //天空盒数据
    static string TemplateScenePath = "/Scenes/template.unity";//场景模板
    static string SaveScenePath = "/Scenes/";//保存的场景路径
    [MenuItem("Tools/BakePrefabsWithOption")]
    static void BakePrefabsWithOption()
    {
        //显示窗体
        var instance = EditorWindow.GetWindowWithRect(typeof(BaseComfirmWindow), new Rect(200, 200, 200, 100), true, "烘焙预制体") as BaseComfirmWindow;
        var context = new GUIContext();
        context.mGuiObjects = new System.Collections.Generic.List<GUIObject>();
        context.mGuiObjects.Add(new GUIObject(GUIEnum.Toggle, "是否重烘已有场景", false, 0));
        instance.Init(context);
        instance.mConfirm = (d) =>
        {
            var isOver = (bool)d[0];
            BakePrefabs(isOver);
        };

    }
    // [MenuItem("Tools/BakePrefabs")]
    static void BakePrefabs(bool isOverRide)
    {
        //准备数据
        var configs = LoadBakeConfigs();
        var context = new BakeContext();
        var parameterPath = Application.dataPath + LightMapParameterPath;
        //替换路径中的反斜杠为正
        parameterPath = parameterPath.Replace(@"\", "/");
        //截取我们需要的路径
        parameterPath = parameterPath.Substring(parameterPath.IndexOf("Assets"));
        var lmp = AssetDatabase.LoadAssetAtPath<LightmapParameters>(parameterPath);
        if (lmp == null)
        {
            Debug.LogError(string.Format("烘焙失败,未找到地形烘焙参数文件{0}", parameterPath));
            return;
        }
        context.LMP = lmp;
        //加载天空盒数据
        SkyBoxMgr.Instance.Init();
        var buildScenes = EditorBuildSettings.scenes;
        foreach (var config in configs)
        {
            //校验是否已经烘焙过
            if (isOverRide == false && BuildScenesContains(config.SceneName, config.LightName))
            {
                Debug.Log($"场景已经烘焙过{config.SceneName}_{config.LightName}");
                continue;
            }
            var modelPath = Application.dataPath + PrefabDirectoryPath + config.SceneName + ".prefab";
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));
            var prefabGo = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefabGo == null)
            {
                Debug.LogError(string.Format("烘焙失败,预制体{0}未找到", path));
                continue;
            }
            var effectMgr = prefabGo.transform.GetComponentInChildren<LevelEffectManager>();
            if (effectMgr == null)
            {
                Debug.LogError(string.Format("烘焙失败,预制体{0}未找到LevelEffectManager", prefabGo.name));
                continue;
            }
            try
            {
                BakePrefab(prefabGo, config.LightName, context);
            }
            catch (BakeException ex)
            {
                Debug.LogError(string.Format("烘焙失败 场景{0} 光效{1}", config.SceneName, config.LightName));
                Debug.LogError(ex.Message);
                Debug.LogError(ex.StackTrace);
                continue;
            }
            //进行图片压缩格式修改
            CompressLMTexture();
        }
    }
    //构建设置中是否包含场景
    static bool BuildScenesContains(string sceneName, string lightName)
    {
        var scene = $"{sceneName}_{lightName}";
        var scenes = EditorBuildSettings.scenes;
        foreach (var s in scenes)
        {
            if (s.path.Contains(scene))
            {
                return true;
            }
        }
        return false;
    }

    //加载烘焙配置
    static List<BakeConfig> LoadBakeConfigs()
    {
        var result = new List<BakeConfig>();
        var idPath = Application.dataPath + BakeConfigPath;
        //替换路径中的反斜杠为正
        idPath = idPath.Replace(@"\", "/");
        //截取我们需要的路径
        idPath = idPath.Substring(idPath.IndexOf("Assets"));
        //加载要烘焙的关卡Id
        var text = AssetDatabase.LoadAssetAtPath<TextAsset>(idPath);
        if (text != null)
        {
            var jsontext = text.text;
            if (string.IsNullOrEmpty(jsontext) == false)
            {
                var config = Newtonsoft.Json.JsonConvert.DeserializeObject<BakeLevel>(jsontext);
                var levelstr = config.LevelIDs;
                var levels = levelstr.Split(',');
                foreach (var level in levels)
                {
                    uint levelId = uint.Parse(level);
                    Levels.LevelLoader.Instance.LoadLevel(levelId);
                    var levelConfig = Levels.LevelLoader.Instance.CurLevelConfig;
                    var bakeConfig = new BakeConfig();
                    bakeConfig.SceneName = levelConfig.ScenePrefabName;
                    var activeeffects = levelConfig.ActiveEffects;
                    for (int i = 0; i < activeeffects.Count; i++)
                    {
                        var effect = activeeffects[i];
                        if (effect.Contains("Lighting"))
                        {
                            bakeConfig.LightName = effect;
                        }
                    }
                    result.Add(bakeConfig);
                }
            }
        }
        return result;
    }

    //烘焙预制体
    static void BakePrefab(GameObject prefab, string lightName, BakeContext context)
    {
        //创建场景
        var sceneName = prefab.name.Replace("(Clone)", "");
        var saveSceneName = sceneName + "_" + lightName + ".unity";
        var templateScenePath = Application.dataPath + TemplateScenePath;
        //替换路径中的反斜杠为正
        templateScenePath = templateScenePath.Replace(@"\", "/");
        //截取我们需要的路径
        templateScenePath = templateScenePath.Substring(templateScenePath.IndexOf("Assets"));
        var newScene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(templateScenePath);
        //在场景中创建预制体
        var go = GameObject.Instantiate(prefab);
        //静态物体设置
        SetStaticObjs(go);
        //光效设置
        SetLight(go, lightName);
        //Terrain参数设置
        TerrainParamSet(go, sceneName, lightName, context);
        //天空盒设置
        SkyBoxSet(sceneName);
        //探针设置
        CreateLightProbeGroups(go);
        //雾效设置
        FogSet(go);
        //保存场景
        var scenePath = Application.dataPath + SaveScenePath + saveSceneName;
        //判断如果存在则删除
        if (File.Exists(scenePath))
        {
            File.Delete(scenePath);
        }
        UnityEditor.SceneManagement.EditorSceneManager.SaveScene(newScene, scenePath, true);
        AssetDatabase.Refresh();
        //打开场景 进行烘焙
        if (UnityEditor.Lightmapping.giWorkflowMode != UnityEditor.Lightmapping.GIWorkflowMode.OnDemand)
        {
            throw new System.Exception("ExtractLightmapData requires that you have baked you lightmaps and Auto mode is disabled.");
        }
        var bakescene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenePath);
        UnityEditor.Lightmapping.Bake();
        UnityEditor.SceneManagement.EditorSceneManager.SaveScene(bakescene);
    }

    static void FogSet(GameObject rootGo)
    {
        var fogs = rootGo.GetComponentsInChildren<FogChange>();
        foreach (var fog in fogs)
        {
            fog.enabled = false;
        }
    }

    //创建光照探针
    static void CreateLightProbeGroups(GameObject rootGo)
    {
        //获取地形中心点
        var terrains = rootGo.GetComponentsInChildren<Terrain>();
        var bound = new Bounds();
        for (var i = 0; i < terrains.Length; i++)
        {
            var terrain = terrains[i];
            var terrainBound = terrain.terrainData.bounds;
            var offsetPosition = terrain.transform.position;
            terrainBound.SetMinMax(terrainBound.min + offsetPosition, terrainBound.max + offsetPosition);
            bound.Encapsulate(terrainBound);
        }
        var center = bound.center;
        var lightprobeObj = new GameObject("LightProbeGroup");
        lightprobeObj.transform.position = new Vector3(center.x, center.y - bound.size.y * 0.5f, center.z);
        var lightProbe = lightprobeObj.AddComponent<LightProbesTetrahedralGrid>();
        var radius = Mathf.Max(bound.size.x * 0.5f, bound.size.z * 0.5f);
        lightProbe.m_Radius = radius;
        lightProbe.m_Height = bound.size.y + 5;//默认要加5装树
        lightProbe.m_Levels = (uint)lightProbe.m_Height / 10 * 3; //10个高度3个层级
        //刷新探针
        lightProbe.enabled = false;
        lightProbe.enabled = true;
        //去掉探针
        GameObject.DestroyImmediate(lightProbe);
    }

    //天空盒设置
    static void SkyBoxSet(string sceneName)
    {
        //加载天空盒
        var skyBox = SkyBoxMgr.Instance.GetDataBySceneName(sceneName);
        if (skyBox == null)
        {
            throw new BakeException("未找到天空盒数据");
        }
        var path = Application.dataPath + "/LRS-BN-SceneRes/" + skyBox.SkyBoxPath;
        path = path.Substring(path.IndexOf("Assets"));
        var sky = AssetDatabase.LoadAssetAtPath<Material>(path);
        if (sky == null)
        {
            throw new BakeException(string.Format("未找到天空盒资源{0}", path));
        }
        RenderSettings.skybox = sky;

        // //校验是否设置过
        // if (RenderSettings.skybox == null)
        // {
        //     continue;
        // }
        //创建天空盒
        var skyBoxCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        skyBoxCube.transform.localScale = new Vector3(800, 800, 800);
        var render = skyBoxCube.GetComponent<Renderer>();
        render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        render.receiveShadows = false;
        if (skyBoxCube.GetComponent<BoxCollider>() != null)
        {
            GameObject.DestroyImmediate(skyBoxCube.GetComponent<BoxCollider>());
        }
        //创建天空盒材质
        //创建场景文件夹
        var sceneForderName = sceneName;
        var folderPath = Application.dataPath + SceneFolderDirectoryPath + sceneForderName;
        if (Directory.Exists(folderPath) == false)
        {
            // Debug.LogError($"文件夹{folderPath}不存在 无法创建天空盒物体材质");
            throw new BakeException($"文件夹{folderPath}不存在 无法创建天空盒物体材质");
        }
        //创建天空盒材质
        var matPath = folderPath + "/" + sceneForderName + "_skybox.mat";
        var matAssetPath = FullPath2AssetPath(matPath);
        Material mat = new Material(Shader.Find("Custom/Skybox/Cubemap"));
        var cubeMap = RenderSettings.skybox.GetTexture("_Tex");
        mat.SetTexture("_Tex", cubeMap);
        //保存mat
        AssetDatabase.CreateAsset(mat, matAssetPath);
        render.sharedMaterial = mat;
        //去掉原来设置的天空盒
        RenderSettings.skybox = null;
    }

    //Terrain参数设置
    static void TerrainParamSet(GameObject rootGo, string sceneName, string lightName, BakeContext context)
    {
        var terrains = rootGo.GetComponentsInChildren<Terrain>();
        var firstTerrain = terrains[0];
        //创建场景文件夹
        var folderPath = Application.dataPath + SceneFolderDirectoryPath + sceneName;
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }
        //根据光效名创建材质
        var matPath = folderPath + "/" + lightName + ".mat";
        var matAssetPath = FullPath2AssetPath(matPath);
        var curterrainMat = firstTerrain.materialTemplate;
        var mat = AssetDatabase.LoadAssetAtPath<Material>(matAssetPath);
        if (mat == null)
        {
            //新建一个材质
            mat = new Material(curterrainMat.shader);
            //保存mat
            AssetDatabase.CreateAsset(mat, matAssetPath);
        }
        mat.CopyPropertiesFromMaterial(curterrainMat);
        var mainlight = rootGo.GetComponentInChildren<MainLightColor>().GetComponent<Light>();
        mat.SetFloat("_ShadowLowestValue", 1 - mainlight.shadowStrength);
        EditorUtility.SetDirty(mat);
        var lightmapScale = 0.8f / terrains.Length;
        foreach (var terrain in terrains)
        {
            if (terrain.terrainData.size.y > 300)
            {
                terrain.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
            else
            {
                terrain.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
            SerializedObject s = new SerializedObject(terrain);
            s.FindProperty("m_ScaleInLightmap").floatValue = lightmapScale;
            s.FindProperty("m_LightmapParameters").objectReferenceValue = context.LMP;

            // Remember to apply changes when done editing
            s.ApplyModifiedProperties();
            terrain.materialTemplate = mat;
            //检测PixelError
            if (terrain.heightmapPixelError != 15)
            {
                terrain.heightmapPixelError = 15;
                EditorUtility.SetDirty(terrain);
            }
            // //检测分辨率
            // if (terrain.terrainData.heightmapResolution != 65)
            // {
            //     ResizeHeightmap(terrain.terrainData, 65);
            //     EditorUtility.SetDirty(terrain.terrainData);
            // }
            //检测草的批次
            if (terrain.terrainData.detailResolutionPerPatch != 128)
            {
                terrain.terrainData.SetDetailResolution(terrain.terrainData.detailResolution, 128);
                EditorUtility.SetDirty(terrain.terrainData);
            }
        }
        AssetDatabase.SaveAssets();
    }

    //光效设置
    static void SetLight(GameObject rootGo, string lightName)
    {
        var effectMgr = rootGo.transform.GetComponentInChildren<LevelEffectManager>();
        if (effectMgr == null)
        {
            throw new BakeException("未找到特效组件");
        }
        var lightlist = effectMgr.transform.Find("LightingList");
        if (lightlist == null)
        {
            throw new BakeException("未找到LightingList");
        }
        GameObject lightObj = null;
        var childCount = lightlist.transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            var child = lightlist.transform.GetChild(i);
            if (child.name == lightName)
            {
                child.gameObject.SetActive(true);
                lightObj = child.gameObject;
                break;
            }
        }
        if (lightObj == null)
        {
            throw new BakeException(string.Format("未找到光源{0}", lightName));
        }
        //主光添加MainLight组件
        var lights = lightObj.transform.GetComponentsInChildren<Light>();
        foreach (var light in lights)
        {
            if (light.type == LightType.Directional && light.shadows != LightShadows.None && light.shadowStrength > 0)
            {
                //带阴影的平行光为主光
                if (light.gameObject.GetComponent<MainLightColor>() == null)
                {
                    light.gameObject.AddComponent<MainLightColor>();
                }
                light.lightmapBakeType = LightmapBakeType.Mixed;
                light.bounceIntensity = 0;
                //由于烘焙阴影所以如果调整过Normal Bias的可以恢复默认值
                if (light.shadowNormalBias > 0.4f)
                {
                    light.shadowNormalBias = 0.4f;
                }
            }
            else if (light.type == LightType.Directional)
            {
                light.lightmapBakeType = LightmapBakeType.Baked;
                light.shadows = LightShadows.None;
                light.bounceIntensity = light.intensity;
            }
            else if (light.type == LightType.Point)
            {
                light.lightmapBakeType = LightmapBakeType.Baked;
                light.intensity = DecreaseFactor * light.intensity;
                light.bounceIntensity = light.intensity;
            }
            else
            {
                throw new BakeException(string.Format("未处理光源类型{0}", light.type.ToString()));
            }
        }
        //校验是否有多个主光
        var mainlights = lightObj.transform.GetComponentsInChildren<MainLightColor>();
        if (mainlights.Length > 1)
        {
            throw new BakeException("场景有多个主光");
        }
    }

    //静态物体设置
    static void SetStaticObjs(GameObject rootGo)
    {
        var renderers = rootGo.GetComponentsInChildren<MeshRenderer>();
        for (var i = 0; i < renderers.Length; i++)
        {
            var renderer = renderers[i];
            if (renderer.GetComponent<Tree>() != null)
            {
                //说明是树跳过
                continue;
            }
            var mats = renderer.sharedMaterials;
            bool isVertexAnim = false;  //是否有顶点动画
            foreach (var mat in mats)
            {
                var shaderName = mat.shader.name;
                if (shaderName == "Custom/New Toon Wave Shading" || shaderName.Contains("Toon_Water") || shaderName.Contains("Toon_River") || shaderName.Contains("Toon_Foam"))
                {
                    isVertexAnim = true;
                    break;
                }
            }
            if (isVertexAnim == true)
            {
                //有顶点动画跳过
                continue;
            }
            if (renderer.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            {
                //地形投影体跳过
                continue;
            }
            if (renderer.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                //地形碰撞体跳过
                continue;
            }
            //设置静态
            renderer.gameObject.isStatic = true;
        }
    }
    #endregion
    //全路径转资源路径
    public static string FullPath2AssetPath(string fullpath)
    {
        //替换路径中的反斜杠为正
        var result = fullpath.Replace(@"\", "/");
        //截取我们需要的路径
        result = result.Substring(result.IndexOf("Assets"));
        return result;
    }
}