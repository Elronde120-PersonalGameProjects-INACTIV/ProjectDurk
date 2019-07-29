using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TowerUI;
    [SerializeField]
    private GameObject[] TowerOptionUI;
    /// <summary>
    /// Used to keep track of what tower spawn point moved the TowerUI
    /// </summary>
    public TowerSpawnPoint m_currentTowerSpawnPoint { get; private set; }

    private void Awake()
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(new Vector3(999,999,999));
        TowerUI.transform.position = newPos;
    }

    /// <summary>
    /// Handles all messages recieved with a vector in the message
    /// </summary>
    /// <param name="MSG">The message</param>
    /// <param name="POS">The position attached to the message</param>
    public void OnRecieveMessage(string MSG, Vector3 POS, TowerSpawnPoint TSP)
    {
        IDebug.DebugVerbose("\"" + this.name + "\" has recieved a message: \"" + MSG + "\" with vector \"" + POS + "\".");
        m_currentTowerSpawnPoint = TSP;
        if (MSG == "MOVE_TOWER_UI")
            MOVETOWERUI(POS);

    }


    void MOVETOWERUI(Vector3 POS)
    {
       Vector3 newPos = Camera.main.WorldToScreenPoint(POS);
        TowerUI.transform.position = newPos;
    }
}
