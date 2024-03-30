using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
static public class BuildEditorLife
{
    [UnityEditor.Callbacks.DidReloadScripts(0)]
    static void OnScriptReload()
    {
        OnCodeBuildComplete();
    }
    /// <summary>
    /// Editor代码刷新后执行
    /// </summary>
    static public void OnCodeBuildComplete()
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }
        InitFrameworkEditor();
    }
    /// <summary>
    /// 初始化框架编辑器
    /// </summary>
    static public void InitFrameworkEditor()
    {
        BuildApplication.Init();
    }
}
