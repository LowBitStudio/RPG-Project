using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField] public string enemy_Name {get; private set;}
    [SerializeField] public float max_Health {get; private set;}
    [SerializeField] public GameObject Enemyprefab {get; private set;}
}
