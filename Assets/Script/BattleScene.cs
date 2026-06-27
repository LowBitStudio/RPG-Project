using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Place the player on the battle scene with the enemy
            SceneManager.LoadScene("Battle Scene");
        }
    }
}
