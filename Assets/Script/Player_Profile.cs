using UnityEngine;

[CreateAssetMenu(fileName = "Player_Profile", menuName = "Scriptable Objects/Player_Profile")]
public class Player_Profile : ScriptableObject
{
    [SerializeField] public string player_Name {get; private set;}
    [SerializeField] public float max_Health {get; private set;}
    [SerializeField] public float current_Health {get; private set;}
}
