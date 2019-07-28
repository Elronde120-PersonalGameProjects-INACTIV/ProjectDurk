using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 Rotation;
    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotation * RotationSpeed * Time.deltaTime);
    }
}
