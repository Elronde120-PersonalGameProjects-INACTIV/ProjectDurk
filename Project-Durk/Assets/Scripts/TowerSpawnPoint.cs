using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnPoint : MonoBehaviour
{
    /// <summary>
    /// Reference to the spawn points current tower. Can be null at anytime.
    /// </summary>
    public GameObject m_currentTower { get; private set; }
    /// <summary>
    /// Reference to the tower that will spawn here. Can be null at anytime. Will be set to null once tower has spawned.
    /// </summary>
    public GameObject m_towerToSpawn { get; private set; }
    /// <summary>
    /// Is the spawn point highlighted?
    /// </summary>
    public bool m_highlighted { get; private set; }

    [SerializeField]
    private Transform TowerInstantiationPoint;
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private Color highlightColor;
    private Color startColor;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            IDebug.LogError("\"" + this.name + "\" could not find its renderer.");
            return;
        }
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (rend && m_highlighted == false)
            rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (rend && m_highlighted == false)
            rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (m_highlighted == false)
            MsgJunction.instance.SendHighlightManagerMsg("HIGHLIGHT", this.gameObject);
    }



    /// <summary>
    /// Handles all messages sent to this spawn point with gameobjects in the message
    /// </summary>
    /// <param name="MSG">the message</param>
    /// <param name="OBJ">the object to be used</param>
    public void OnMessageRecieved(string MSG, GameObject OBJ)
    {
        IDebug.DebugVerbose("\"" + this.name + "\" has recieved a message: \"" + MSG + "\" with gameobject \"" + OBJ.name + "\".");
        if (MSG == "SPAWN_TOWER")
            SPAWNTOWER_MSG(OBJ);
    }

    /// <summary>
    /// Handles all messages sent to this spawn point with a bool in the message
    /// </summary>
    /// <param name="MSG">the message</param>
    /// <param name="OBJ">the object to be used</param>
    public void OnMessageRecieved(string MSG, bool T_F)
    {
        IDebug.DebugVerbose("\"" + this.name + "\" has recieved a message: \"" + MSG + "\" with bool \"" + T_F + "\".");
        if (MSG == "HIGHLIGHT")
            HIGHLIGH_MSG(T_F);
    }

    /// <summary>
    /// Handles all highlight messages
    /// </summary>
    /// <param name="T_F">wether or not to highlight</param>
    void HIGHLIGH_MSG(bool T_F)
    {
        if (rend)
        {
            m_highlighted = T_F;
            if (T_F)
                rend.material.color = highlightColor;
            else
                rend.material.color = startColor;
        }
    }

    /// <summary>
    /// Used to handle any spawn messages sent to this TowerSpawnPoint
    /// </summary>
    /// <param name="TTS">The tower to spawn. Must have a TowerBase component on its highest parent</param>
    void SPAWNTOWER_MSG(GameObject TTS)
    {
        if (TTS.GetComponent<TowerBase>() != null)
        {
            m_towerToSpawn = TTS;
            if (SpawnTower() == false)
                IDebug.LogError("Attempt to spawn tower at spawn point \"" + this.name + "\" has failed for an unknown reason.");

            return;
        }
        IDebug.LogError("Attempt to spawn tower at spawn point \"" + this.name + "\" has failed because the TowerBase component could not be found on the highest parent.");
    }

    /// <summary>
    /// If the spawn point has a tower to spawn, it will be spawned here. Returns true if the spawn was successful.
    /// </summary>
    public bool SpawnTower()
    {
        bool result = false;
        if (m_towerToSpawn != null)
        {
            GameObject obj = Instantiate(m_towerToSpawn, TowerInstantiationPoint.position, Quaternion.identity);
            m_currentTower = obj;
            m_towerToSpawn = null;
            result = true;
        }
        return result;
    }
}
