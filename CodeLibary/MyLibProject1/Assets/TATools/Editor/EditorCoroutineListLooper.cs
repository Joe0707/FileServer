using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public static class EditorCoroutineListLooper
{
    private static List<IEnumerator> m_loopers = new List<IEnumerator>();
    private static bool M_Started = false;
    public static void StartLoop(IEnumerator iterator)
    {
        if (iterator != null)
        {
            if (!m_loopers.Contains(iterator))
            {
                m_loopers.Add(iterator);
            }
        }
        if (!M_Started)
        {
            M_Started = true;
            EditorApplication.update += Update;
        }
    }

    private static List<IEnumerator> M_DropItems = new List<IEnumerator>();
    private static void Update()
    {
        if (m_loopers.Count > 0)
        {
            var allItems = m_loopers.GetEnumerator();
            while (allItems.MoveNext())
            {
                var item = allItems.Current;
                IEnumerator ie = item;
                if (ie == null)
                {
                    M_DropItems.Add(ie);
                    continue;
                }
                if (!ie.MoveNext())
                {
                    M_DropItems.Add(item);
                }
            }
            for (int i = 0; i < M_DropItems.Count; i++)
            {
                if (M_DropItems[i] != null)
                {
                    m_loopers.Remove(M_DropItems[i]);
                }
            }
            M_DropItems.Clear();
        }
        if (m_loopers.Count == 0)
        {
            EditorApplication.update -= Update;
            M_Started = false;
        }
    }
}
