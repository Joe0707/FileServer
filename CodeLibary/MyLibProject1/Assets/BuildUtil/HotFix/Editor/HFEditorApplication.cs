using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace HotfixFrame.Editor
{
    public class HFEditorApplication
    {
        static public HFEditorSetting HFEditorSetting { get; private set; }
        static public void Init()
        {
            HFEditorSetting = new HFEditorSetting();
        }
    }
}