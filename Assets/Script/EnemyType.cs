using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField] public string enemy_Name;
    [SerializeField] public float max_Health;
    [SerializeField] public GameObject Enemyprefab;
}
