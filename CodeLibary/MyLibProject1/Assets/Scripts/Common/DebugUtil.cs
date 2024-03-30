using UnityEngine;
public class DebugUtil
{
    public static void DebugInfo(string message)
    {
        Debug.Log(message);
    }

    public static void DebugError(string errormessage)
    {
        Debug.LogError(errormessage);
    }

    public static void DebugWarn(string warnmessage)
    {
        Debug.LogWarning(warnmessage);
    }
}