using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgJunction : MonoBehaviour
{
    public static MsgJunction instance;
    [Header("There should only be one of these per scene")]
    public GameObject UIMsgReciever;
    public TowerSpawnHighlightManager TSHMReciever;

    private void Awake()
    {
        if (instance != this)
            instance = this;

        if (UIMsgReciever == null)
            IDebug.LogError("MsgJunction (\"" + this.name + "\") does not have a reference to the UI message reciever.");

        if (TSHMReciever == null)
            IDebug.LogError("MsgJunction (\"" + this.name + "\") does not have a reference to the highlight message reciever.");
    }

    /// <summary>
    /// Handles messages to the UI message reciever. Currently does nothing...
    /// </summary>
    /// <param name="MSG">The message to send</param>
    /// <param name="POS">A vector to give the reciever</param>
    public void SendUIMsg(string MSG, Vector3 POS)
    {
        //do nothing for now...
    }

    /// <summary>
    /// Handles messages being sent to a tower spawn point with a bool in the message
    /// </summary>
    /// <param name="MSG">The message</param>
    /// <param name="Reciever">The tower spawn point to recieve the message</param>
    /// <param name="T_F">true or false</param>
    public void SendTowerSpawnMsg(string MSG, TowerSpawnPoint Reciever, bool T_F)
    {
        Reciever.OnMessageRecieved(MSG, T_F);
    }

    /// <summary>
    /// Handles messages being sent to the TowerSpawnHighlightManager with a gameobject in the message
    /// </summary>
    /// <param name="MSG">The message</param>
    /// <param name="OBJ">The GameObject to send</param>
    public void SendHighlightManagerMsg(string MSG, GameObject OBJ)
    {
        TSHMReciever.OnMessageRecieved(MSG, OBJ);
    }
}
