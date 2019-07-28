using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDebug : UnityEngine.Debug
{
    public static bool Verbose = false;
    public static void DebugVerbose(object msg)
    {
        if (Verbose)
            Debug.Log(msg);
    }
}
