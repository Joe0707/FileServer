using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HotfixFrame.Core.Tools;

namespace HotfixFrame.Editor
{
    [InitializeOnLoad]
    static public class HotfixEditorLife
    {
        [UnityEditor.Callbacks.DidReloadScripts(0)]
        static void OnScriptReload()
        {
            // Debug.Log("OnScriptReload");
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
            InitHFFrameworkEditor();
        }
        /// <summary>
        /// 初始化框架编辑器
        /// </summary>
        static public void InitHFFrameworkEditor()
        {
            HFApplication.Init();
            HFEditorApplication.Init();
        }
    }
}