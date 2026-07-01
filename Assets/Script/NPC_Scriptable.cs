using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Scriptable", menuName = "Scriptable Objects/NPC_Scriptable")]
public class NPC_Scriptable : ScriptableObject
{
    public string npc_name;
    public string[] dialogue_line;
    public float typingspeed = 0.05f;   
    public bool[] autoprogressline;
    public float autoProgressDelay = 1.5f;

}
