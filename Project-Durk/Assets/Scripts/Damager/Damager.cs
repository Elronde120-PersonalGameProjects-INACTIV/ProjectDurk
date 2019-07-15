using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : Interactable
{
    public int m_damage { get; private set; }

    [Header("Attackable variables"), Tooltip("Sets the objects damage output. local ints will react to changes during gameplay")]
    public int CurrentDamage = 100;

    public override void Awake()
    {
        base.Awake();
        m_damage = CurrentDamage;
    }

    public virtual void Update()
    {
        m_damage = CurrentDamage;
    }
}
