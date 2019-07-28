using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDatabaseManager : MonoBehaviour
{
    public Entry[] Entries;
    public Dictionary<int, GameObject> Database = new Dictionary<int, GameObject>();
    public bool Ready = false;

    private void Awake()
    {
        for (int i = 0; i < Entries.Length; i++)
        {
            Database.Add(Entries[i].ID , Entries[i].Tower);
        }
        Ready = true;
    }




    /// <summary>
    /// Handles all query messages
    /// </summary>
    /// <param name="IDToQuery"></param>
    public void OnMessageRecieved(int IDToQuery, TowerSpawnPoint TSP)
    {
        IDebug.DebugVerbose("\"" + this.name + "\" has recieved a message: \"" + IDToQuery + "\" with TowerSpawnPoint \"" + TSP.name + "\".");
        GameObject Obj;
        try
        {
             Obj = Database[IDToQuery];
        }
        catch
        {
            IDebug.LogError("TowerDatabaseManager (\"" + this.name + "\") does not have a entry with the ID \"" + IDToQuery + "\".");
            return;
        }
        MsgJunction.instance.SendTowerSpawnMsg("SPAWN_TOWER", TSP, Obj);

    }
}




[System.Serializable]
public class Entry
{
    public int ID;
    public GameObject Tower;

}
