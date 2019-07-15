using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [Header("Interactable Variables")]
    public string m_name;

    public virtual void Awake()
    {
        if(m_name == "")
        {
            m_name = "Default_" + gameObject.name;
        }
    }
}
