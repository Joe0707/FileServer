using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
public class OptimizeMesh
{
    #region 静态工具处理
    public static string ActorPath = "/Models/";
    static bool isOptimizedModel(GameObject go)
    {
        //获取模型的颜色看是否优化过
        Mesh mesh = null;
        if (go.GetComponentInChildren<SkinnedMeshRenderer>())
        {
            var skinRender = go.GetComponentInChildren<SkinnedMeshRenderer>();
            mesh = skinRender.sharedMesh;
        }
        else if (go.GetComponentInChildren<MeshFilter>())
        {
            mesh = go.GetComponentInChildren<MeshFilter>().sharedMesh;
        }
        //如果有顶点色并且不是0不是1则认为是处理过的则不再处理
        if (mesh.colors != null && mesh.colors.Length == mesh.vertices.Length)
        {
            for (var i = 0; i < mesh.colors.Length; i++)
            {
                var color = mesh.colors[i];
                if (MathUtil.NearlyEquals(color.r, 1) == false && MathUtil.NearlyEquals(color.r, 0) == false)
                {
                    return true;
                }
            }
        }
        return false;
    }
    //模型法线平滑优化
    [MenuItem("Tools/Optimize Model/Optimize Actor Model")]
    public static void OptimizeActorModel()
    {
        //材质优化
        OptimizeActorMaterial(() =>
        {
            OptimizeActorMesh();
        });
    }

    static void OptimizeActorMesh()
    {
        // //网格优化
        // var directory = Application.dataPath + ActorPath;
        // string[] modelPaths = Directory.GetFiles(directory, "*.fbx", SearchOption.AllDirectories);
        // foreach (var modelPath in modelPaths)
        // {
        //     //截取资源路径
        //     var modelp = modelPath.Substring(modelPath.IndexOf("Assets"));
        //     ModelImporter model = AssetImporter.GetAtPath(modelp) as ModelImporter;
        //     var go = AssetDatabase.LoadAssetAtPath<GameObject>(modelp);
        //     if (model != null && go != null)
        //     {
        //         if (isOptimizedModel(go) == false)
        //         {
        //             model.isReadable = true;
        //             model.SaveAndReimport();
        //         }
        //     }
        // }
        var directory = Application.dataPath + ActorPath;
        OptimizeMeshes(directory);
    }

    public static string ScenePath = "/LRS-BN-SceneRes/Models/Scenes/Scenes_Ly/Model/";
    //模型法线平滑优化
    [MenuItem("Tools/Optimize Model/Optimize Scene Model")]
    public static void OptimizeSceneModel()
    {
        //材质优化
        OptimizeSceneMaterial(() =>
        {
            OptimizeSceneMesh();
        });
    }
    static int GetCoreNumber()
    {
        //获取核数
        return System.Environment.ProcessorCount;
    }
    static void OptimizeSceneMesh()
    {
        var directory = Application.dataPath + ScenePath;
        OptimizeMeshes(directory);
    }

    static void OptimizeMeshes(string directory)
    {
        // var directory = Application.dataPath + assetPath;
        List<string> processModelPaths = new List<string>();
        string[] modelPaths = Directory.GetFiles(directory, "*.fbx", SearchOption.AllDirectories);
        //配置处理
        foreach (var modelPath in modelPaths)
        {
            //截取资源路径
            var modelp = modelPath.Substring(modelPath.IndexOf("Assets"));
            ModelImporter model = AssetImporter.GetAtPath(modelp) as ModelImporter;
            if (model != null)
            {
                if (model.importTangents != ModelImporterTangents.Import)
                {
                    model.importTangents = ModelImporterTangents.Import;
                    model.SaveAndReimport();
                }
            }
            //物体是否需要处理优化
            var go = AssetDatabase.LoadAssetAtPath<GameObject>(modelp);
            if (go != null && isOptimizedModel(go) == false)
            {
                processModelPaths.Add(modelPath);
            }
        }
        //网格优化
        //获取当前项目路径
        var path = Application.dataPath;
        DirectoryInfo info = new DirectoryInfo(path);
        var parent = info.Parent.FullName;
        var exepath = Path.Combine(parent, "NormalSmooth/");
        var disk = path.Substring(0, path.IndexOf(":"));
        var list = new List<string>();
        list.Add(disk + ":");
        list.Add("cd " + exepath);
        //开多进程处理
        int coreCount = GetCoreNumber();//核数量
        int ProcessCount = processModelPaths.Count / coreCount + 1;
        int curIndex = 0;
        var processList = new List<List<string>>();
        List<string> curList = null;
        foreach (string modelPath in processModelPaths)
        {
            if (curIndex % ProcessCount == 0)
            {
                curList = new List<string>();
                curList.AddRange(list);
                processList.Add(curList);
            }
            curList.Add("NormalSmooth.exe \"" + modelPath + "\"");
            curIndex++;
        }
        int finishCount = 0;
        foreach (List<string> processCommand in processList)
        {
            ProcessUtil.RunCmd(processCommand, false, () =>
            {
                finishCount++;
                if (finishCount == coreCount)
                {
                    //完成了
                    Debug.Log("<color=red>模型优化执行完成!</color>");
                }
            });
        }

    }

    static void OnOptimizeObject(GameObject go, string path)
    {
        if (path.Contains("ProjectAsset"))
        {
            //如果是投影的模型则不处理
            return;
        }
        //如果有定点色则认为是处理过的不再处理
        Mesh mesh = new Mesh();
        Mesh newMesh = new Mesh();
        if (go.GetComponentInChildren<SkinnedMeshRenderer>())
        {
            var skinRender = go.GetComponentInChildren<SkinnedMeshRenderer>();
            mesh = skinRender.sharedMesh;
            var obj = new GameObject();
            var meshF = obj.AddComponent<MeshFilter>();
            meshF.sharedMesh = mesh;
            newMesh = meshF.mesh;
        }
        else if (go.GetComponentInChildren<MeshFilter>())
        {
            mesh = go.GetComponentInChildren<MeshFilter>().sharedMesh;
            var obj = new GameObject();
            var meshF = obj.AddComponent<MeshFilter>();
            meshF.sharedMesh = mesh;
            newMesh = meshF.mesh;
            // newMesh = go.GetComponentInChildren<MeshFilter>().mesh;
        }
        Debug.Log(mesh.name);
        // //如果有顶点色则认为是处理过的则不再处理
        // if (mesh.colors != null && mesh.colors.Length == mesh.vertices.Length)
        // {
        //     return;
        // }
        //声明一个V3数组，长度与mesh.normals一样，用于存放
        //与mesh.vertices中顶点一一对应的光滑处理后的法线值
        // Vector4[] avgNormals = new Vector4[mesh.normals.Length];
        Vector3[] meshVerts = mesh.vertices;
        Vector3[] meshNormals = mesh.normals;
        Vector4[] meshTangents = mesh.tangents;
        //新建一个颜色数组把光滑处理后的法线值存入其中
        Color[] meshColors = new Color[mesh.vertices.Length];
        //优化步骤：计算每个顶点距离游戏世界原点的长度
        SortedList<int, List<int>> sl = new SortedList<int, List<int>>();
        int precision = 10000000;
        for (int i = 0; i < meshVerts.Length; i++)
        {
            Vector3 v = meshVerts[i];
            int f = (int)(Vector3.Magnitude(v) * precision);
            if (sl.ContainsKey(f) == false)
            {
                sl[f] = new List<int>();
            }
            sl[f].Add(i);
        }
        //开始一个循环,循环的次数 = mesh.normals.Length = mesh.vertices.Length = meshNormals.Length
        int len = meshVerts.Length;
        for (int i = 0; i < len; i++)
        {
            //定义一个零值法线
            Vector3 normal = Vector3.zero;
            var slIndices = sl[(int)(Vector3.Magnitude(meshVerts[i]) * precision)];

            //遍历mesh.vertices数组，如果遍历到的值与当前序号顶点值相同，则将其对应的法线与Normal相加
            int sharedCnt = 0;
            foreach (var j in slIndices)
            {
                Vector3 vj = meshVerts[j];
                if (Vector3.Distance(vj, meshVerts[i]) < 0.01f)
                {
                    normal += meshNormals[j];
                    sharedCnt++;
                }
            }
            //归一化Normal并将meshNormals数列对应位置赋值为Normal,到此序号为i的顶点的对应法线光滑处理完成
            //此时求得法线为模型空间下得法线
            normal.Normalize();
            //模型空间转切线空间
            Vector3[] OtoTMatrix = new Vector3[3];
            OtoTMatrix[0] = new Vector3(meshTangents[i].x, meshTangents[i].y, meshTangents[i].z);
            OtoTMatrix[1] = Vector3.Cross(meshNormals[i], OtoTMatrix[0]);
            OtoTMatrix[1] = new Vector3(OtoTMatrix[1].x * meshTangents[i].w, OtoTMatrix[1].y * meshTangents[i].w, OtoTMatrix[1].z * meshTangents[i].w);
            OtoTMatrix[2] = meshNormals[i];

            Vector3 tNormal = Vector3.zero;
            tNormal.x = Vector3.Dot(OtoTMatrix[0], normal);
            tNormal.y = Vector3.Dot(OtoTMatrix[1], normal);
            tNormal.z = Vector3.Dot(OtoTMatrix[2], normal);
            //转颜色
            meshColors[i].r = tNormal.x * 0.5f + 0.5f;
            meshColors[i].g = tNormal.y * 0.5f + 0.5f;
            meshColors[i].b = tNormal.z * 0.5f + 0.5f;
            meshColors[i].a = 1;

            if (i % 10 != 0)
            {
                continue;
            }
            Debug.Log($"Processing meshColors {i}/{meshColors.Length},shared count = {sharedCnt}");
        }
        newMesh.colors = meshColors;
        path = path.Replace("\\", "/");
        path = path.Substring(path.IndexOf("Assets"));
        path = path.Substring(0, path.LastIndexOf("/"));
        AssetDatabase.CreateAsset(newMesh, $"{path}/{mesh.name}.asset");
        AssetDatabase.Refresh();
        if (go.GetComponentInChildren<SkinnedMeshRenderer>())
        {
            var skinRender = go.GetComponentInChildren<SkinnedMeshRenderer>();
            skinRender.sharedMesh = newMesh;
        }
        else if (go.GetComponentInChildren<MeshFilter>())
        {
            go.GetComponentInChildren<MeshFilter>().sharedMesh = newMesh;
        }
        // PrefabUtility.SaveAsPrefabAsset()
        EditorUtility.SetDirty(go);
        AssetDatabase.SaveAssets();
        Debug.Log("Done:All finished!");
    }

    #endregion
    #region OptimizeMaterial
    const string ActorOutlineKey = "ActorOutline";
    const string SceneOutlineKey = "SceneOutline";
    // [MenuItem("Tools/OptimizeMaterial/OptimizeActorMaterial")]
    static void OptimizeOutlineMaterial(float outline, string matPath)
    {
        string[] otherspath = Directory.GetFiles(matPath, "*.mat", SearchOption.AllDirectories);
        foreach (string modelPath in otherspath)
        {
            //替换路径中的反斜杠为正
            var path = modelPath.Replace(@"\", "/");
            //截取我们需要的路径
            path = path.Substring(path.IndexOf("Assets"));

            var obj = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (obj != null)
            {
                //如果有描边
                if (obj.HasProperty("_Outline") && obj.GetFloat("_Outline") != outline)
                {
                    obj.SetFloat("_Outline", outline);
                    EditorUtility.SetDirty(obj);
                }
                //设置材质使用优化法线
                if (obj.HasProperty("_UseSmoothNormal") && obj.IsKeywordEnabled("_USESMOOTHNORMAL") == false)
                {
                    obj.SetInt("_UseSmoothNormal", 1);
                    obj.EnableKeyword("_USESMOOTHNORMAL");
                    EditorUtility.SetDirty(obj);
                }
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    const float mDefaultSceneOutlineWidth = 1.5f;
    const float mDefaultActorOutlineWidth = 1f;
    static void OptimizeActorMaterial(System.Action callback)
    {
        //显示窗体
        var instance = EditorWindow.GetWindowWithRect(typeof(BaseComfirmWindow), new Rect(200, 200, 200, 100), true, "优化角色材质") as BaseComfirmWindow;
        var context = new GUIContext();
        context.mGuiObjects = new System.Collections.Generic.List<GUIObject>();
        context.mGuiObjects.Add(new GUIObject(GUIEnum.TextField, "描边宽度", PlayerPrefs.GetFloat(ActorOutlineKey, mDefaultActorOutlineWidth), 0));
        instance.Init(context);
        instance.mConfirm = (d) =>
        {
            var outline = float.Parse(d[0].ToString());
            //角色材质
            OptimizeOutlineMaterial(outline, Application.dataPath + "/Models");
            //当前角色描边值记录到PlayerPrefs
            PlayerPrefs.SetFloat(ActorOutlineKey, outline);
            if (callback != null)
            {
                callback();
            }
        };
    }
    // [MenuItem("Tools/OptimizeMaterial/OptimizeSceneMaterial")]
    static void OptimizeSceneMaterial(System.Action callback)
    {
        //显示窗体
        var instance = EditorWindow.GetWindowWithRect(typeof(BaseComfirmWindow), new Rect(200, 200, 200, 100), true, "优化场景材质") as BaseComfirmWindow;
        var context = new GUIContext();
        context.mGuiObjects = new System.Collections.Generic.List<GUIObject>();
        context.mGuiObjects.Add(new GUIObject(GUIEnum.TextField, "描边宽度", PlayerPrefs.GetFloat(SceneOutlineKey, mDefaultSceneOutlineWidth), 0));
        instance.Init(context);
        instance.mConfirm = (d) =>
        {
            var outline = float.Parse(d[0].ToString());
            //场景材质
            OptimizeOutlineMaterial(outline, Application.dataPath + "/LRS-BN-SceneRes/Models/Scenes/Scenes_Ly/");
            //当前描边值记录到PlayerPrefs
            PlayerPrefs.SetFloat(SceneOutlineKey, outline);
            if (callback != null)
            {
                callback();
            }
        };
    }
    #endregion

}