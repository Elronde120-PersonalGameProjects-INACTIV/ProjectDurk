using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnHighlightManager : MonoBehaviour
{
    TowerSpawnPoint previousTowerSpawnPoint;
    TowerSpawnPoint currentTowerSpawnPoint;

    /// <summary>
    /// Handles all messages recieved
    /// </summary>
    /// <param name="MSG">the message</param>
    /// <param name="OBJ">the object to be used</param>
    public void OnMessageRecieved(string MSG, GameObject OBJ)
    {
        IDebug.DebugVerbose("\"" + this.name + "\" has recieved a message: \"" + MSG + "\" with gameobject \"" + OBJ.name + "\".");
        if (MSG == "HIGHLIGHT")
            HIGHLIGHT_MSG(OBJ);
    }

    void HIGHLIGHT_MSG(GameObject OBJ)
    {

        if (previousTowerSpawnPoint == null && currentTowerSpawnPoint == null)
        {
            currentTowerSpawnPoint = OBJ.GetComponent<TowerSpawnPoint>();
            MsgJunction.instance.SendTowerSpawnMsg("HIGHLIGHT", currentTowerSpawnPoint, true);           
        }
        else
        {
            previousTowerSpawnPoint = currentTowerSpawnPoint;
            currentTowerSpawnPoint = OBJ.GetComponent<TowerSpawnPoint>();
            MsgJunction.instance.SendTowerSpawnMsg("HIGHLIGHT", previousTowerSpawnPoint, false);
            MsgJunction.instance.SendTowerSpawnMsg("HIGHLIGHT", currentTowerSpawnPoint, true);
        }
    }
}
