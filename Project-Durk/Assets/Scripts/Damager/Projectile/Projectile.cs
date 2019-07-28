using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 m_movementDirection { get; private set; }
    public Transform m_bjectOfOrigin { get; set; }
    public float m_areOfEffect { get; private set; }
    public float m_speed { get; private set; }

    [SerializeField, Header("Projectile Variables")]
    private Vector3 StartMoveDir = Vector3.zero;
    [SerializeField]
    private float AreaOfEffect = 0f;
    [SerializeField]
    private float InitialSpeed = 0f;

    public virtual void Awake()
    {
        if (StartMoveDir != Vector3.zero) m_movementDirection = StartMoveDir;
        if (AreaOfEffect != 0f) m_areOfEffect = AreaOfEffect;
        if (InitialSpeed != 0f) m_speed = InitialSpeed;
    }

    //TODO: possibly look into not using default variables if setup is called?
}
