using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : Interactable
{

    public int m_health { get; private set; }
    public bool m_isDead { get; private set; } = false;

    
    public bool m_attackable { get; private set; } = true; //Can be changed at any time

    [SerializeField,Header("Attackable variables"),Tooltip("Sets the objects initial health. local ints will NOT react when changed during gameplay")]
    private int StartHealth = 100;
    [SerializeField,Tooltip("Set wether or not the object should already be dead. local bools will NOT react when changed during gameplay")]
    private bool StartDead = false;
    [Tooltip("An inspector way to set attackable. can be updated at anytime during gameplay and local bools will react")]
    public bool CurrentlyAttackable = true; //left public so that other scripts can modify variable
    public override void Awake()
    {
        base.Awake();
        m_health = StartHealth;
        if(m_health <= 0)
        {
            IDebug.LogWarning("Attackable " + m_name + ": m_health is <= 0. Was this on purpose?");
            m_isDead = true;
        }
        m_isDead = StartDead;
        m_attackable = CurrentlyAttackable;
    }

    public virtual void Update()
    {
        m_attackable = CurrentlyAttackable;
    }
}
