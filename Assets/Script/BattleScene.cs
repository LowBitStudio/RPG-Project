using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    public EnemyType enemyEncounter; //This is for passing on what enemy will be spawned at the battle scene
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EnemyData_Carrier.enemytoFight = enemyEncounter;
            //Place the player on the battle scene with the enemy
            SceneManager.LoadScene("Battle Scene");
        }
    }
}
