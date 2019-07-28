using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) IDebug.Verbose = !IDebug.Verbose;
    }
}
