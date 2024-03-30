// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System.IO;
// public class FbxOptimizeImporter : AssetPostprocessor
// {
//     void OnPostprocessModel(GameObject go)
//     {
//         ModelImporter modelImporter = assetImporter as ModelImporter;
//         if (modelImporter == null)
//         {
//             //如果类型不匹配
//             return;
//         }
//         if (modelImporter.assetPath.Contains("ProjectAsset"))
//         {
//             //如果是投影的模型则不处理
//             return;
//         }
//         if (modelImporter.isReadable == false)
//         {
//             //如果是不可读则不处理
//             return;
//         }

//         // string src = modelImporter.assetPath;
//         // string dst = Path.GetDirectoryName(src) + "/@@@" + Path.GetFileName(src);

//         // // 复制一个模型用unity的算法生成描边法线，此处ImportAsset完之后会再次导入此asset进入else分支(仅2019.3.1+)
//         // if (!File.Exists(Application.dataPath + "/" + dst.Substring(7)))
//         // {
//         //     AssetDatabase.CopyAsset(src, dst);
//         //     AssetDatabase.ImportAsset(dst);
//         //     return;
//         // }
//         // else
//         // {
//         //     var g = AssetDatabase.LoadAssetAtPath<GameObject>(dst);

//         //     // Dictionary<string, Mesh> originalMesh = GetMesh(go), smoothedMesh = GetMesh(g);

//         //     // foreach (var item in originalMesh)
//         //     // {
//         //     //     var m = item.Value;
//         //     //     m.colors = ComputeSmoothedNormalByJob(smoothedMesh[item.Key], m);
//         //     // }

//         //     AssetDatabase.DeleteAsset(dst);

//         // }

//         //如果有定点色则认为是处理过的不再处理
//         List<Mesh> meshes = new List<Mesh>();
//         if (go.GetComponentInChildren<SkinnedMeshRenderer>())
//         {
//             var skinRenders = go.GetComponentsInChildren<SkinnedMeshRenderer>();
//             foreach (var render in skinRenders)
//             {
//                 meshes.Add(render.sharedMesh);
//             }
//         }
//         else if (go.GetComponentInChildren<MeshFilter>())
//         {
//             var filters = go.GetComponentsInChildren<MeshFilter>();
//             foreach (var filter in filters)
//             {
//                 meshes.Add(filter.sharedMesh);
//             }
//         }
//         foreach (var mesh in meshes)
//         {
//             ProcessMesh(mesh);
//         }
//         //再次设置回来
//         modelImporter.isReadable = false;
//     }
//     //处理网格
//     void ProcessMesh(Mesh mesh)
//     {
//         Debug.Log(mesh.name);
//         // //如果有顶点色则认为是处理过的则不再处理
//         // if (mesh.colors != null && mesh.colors.Length == mesh.vertices.Length)
//         // {
//         //     return;
//         // }
//         //声明一个V3数组，长度与mesh.normals一样，用于存放
//         //与mesh.vertices中顶点一一对应的光滑处理后的法线值
//         // Vector4[] avgNormals = new Vector4[mesh.normals.Length];
//         Vector3[] meshVerts = mesh.vertices;
//         Vector3[] meshNormals = mesh.normals;
//         Vector4[] meshTangents = mesh.tangents;
//         //新建一个颜色数组把光滑处理后的法线值存入其中
//         Color[] meshColors = new Color[mesh.vertices.Length];
//         //优化步骤：计算每个顶点距离游戏世界原点的长度
//         SortedList<int, List<int>> sl = new SortedList<int, List<int>>();
//         int precision = 10000000;
//         for (int i = 0; i < meshVerts.Length; i++)
//         {
//             Vector3 v = meshVerts[i];
//             int f = (int)(Vector3.Magnitude(v) * precision);
//             if (sl.ContainsKey(f) == false)
//             {
//                 sl[f] = new List<int>();
//             }
//             sl[f].Add(i);
//         }
//         //开始一个循环,循环的次数 = mesh.normals.Length = mesh.vertices.Length = meshNormals.Length
//         int len = meshVerts.Length;
//         for (int i = 0; i < len; i++)
//         {
//             //定义一个零值法线
//             Vector3 normal = Vector3.zero;
//             var slIndices = sl[(int)(Vector3.Magnitude(meshVerts[i]) * precision)];

//             //遍历mesh.vertices数组，如果遍历到的值与当前序号顶点值相同，则将其对应的法线与Normal相加
//             int sharedCnt = 0;
//             foreach (var j in slIndices)
//             {
//                 Vector3 vj = meshVerts[j];
//                 if (Vector3.Distance(vj, meshVerts[i]) < 0.01f)
//                 {
//                     normal += meshNormals[j];
//                     sharedCnt++;
//                 }
//             }
//             //归一化Normal并将meshNormals数列对应位置赋值为Normal,到此序号为i的顶点的对应法线光滑处理完成
//             //此时求得法线为模型空间下得法线
//             normal.Normalize();
//             //模型空间转切线空间
//             Vector3[] OtoTMatrix = new Vector3[3];
//             OtoTMatrix[0] = new Vector3(meshTangents[i].x, meshTangents[i].y, meshTangents[i].z);
//             OtoTMatrix[1] = Vector3.Cross(meshNormals[i], OtoTMatrix[0]);
//             OtoTMatrix[1] = new Vector3(OtoTMatrix[1].x * meshTangents[i].w, OtoTMatrix[1].y * meshTangents[i].w, OtoTMatrix[1].z * meshTangents[i].w);
//             OtoTMatrix[2] = meshNormals[i];

//             Vector3 tNormal = Vector3.zero;
//             tNormal.x = Vector3.Dot(OtoTMatrix[0], normal);
//             tNormal.y = Vector3.Dot(OtoTMatrix[1], normal);
//             tNormal.z = Vector3.Dot(OtoTMatrix[2], normal);
//             //转颜色
//             meshColors[i].r = tNormal.x * 0.5f + 0.5f;
//             meshColors[i].g = tNormal.y * 0.5f + 0.5f;
//             meshColors[i].b = tNormal.z * 0.5f + 0.5f;
//             meshColors[i].a = 1;

//             if (i % 10 != 0)
//             {
//                 continue;
//             }
//             Debug.Log($"Processing meshColors {i}/{meshColors.Length},shared count = {sharedCnt}");
//         }
//         mesh.colors = meshColors;
//         Debug.Log("Done:All finished!");
//     }
// }
