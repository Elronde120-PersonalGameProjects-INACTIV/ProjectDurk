using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : Attackable
{
    [SerializeField,Header("TowerBase variables"), Tooltip("The ID of the upgraded version of this tower. If no tower exists then it should be left at 0")]
    private int TowerUpgrade = 0;

}
