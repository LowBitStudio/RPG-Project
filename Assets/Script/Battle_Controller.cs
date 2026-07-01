using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }

public class Battle_Controller : MonoBehaviour
{
    //This script is to manage the battle scene
    public BattleState State;
    [SerializeField] private TextMeshProUGUI battle_text;
    //The current player data needs to be carried here
    //The current enemy data needs to be carried here for battle purposes
    public EnemyType enemy;
    private Enemy_Battle_Data SpawnedEnemy;
    public Transform enemypos;

    void Start()
    {
        if(EnemyData_Carrier.enemytoFight != null)
        {
            enemy = EnemyData_Carrier.enemytoFight;
        }

        //Start the battle
        State = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Batlle has started!");
        battle_text.text = "The battle have started!";  
        yield return new WaitForSeconds(2f);

        GameObject enemyGO = Instantiate(enemy.Enemyprefab, enemypos.position, Quaternion.identity);  
        SpawnedEnemy = enemyGO.GetComponent<Enemy_Battle_Data>();
        battle_text.text = "The enemy approaches!";     
        yield return new WaitForSeconds(2f);
        
        State = BattleState.PlayerTurn;
        Playerturn();
    }

    void Playerturn()
    {
        battle_text.text = "What will you do?";
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("Enemy is taking damage");
        battle_text.text = "Player goes on attack!";
        yield return new WaitForSeconds(2f);

        float damagetoEnemy = 5f;

        SpawnedEnemy.takeDMG(damagetoEnemy);
        battle_text.text = "Enemy takes " + damagetoEnemy + " hits!";
        yield return new WaitForSeconds(2f);

        if(SpawnedEnemy.currenthealth <= 0)
        {
            //Player won the battle!
            State = BattleState.Won;
            battle_text.text = "You won the battle!";
        }
        else
        {
            //Giving turn back to enemy
            State = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        battle_text.text = "Enemy attack!";
        yield return new WaitForSeconds(2f);
        
        battle_text.text = "Ouch! Player received damage!";
        Debug.Log("Player is taking damage!");
        yield return new WaitForSeconds(2f);
        
        State = BattleState.PlayerTurn;
        Playerturn();
    }

    public void AttackButton()
    {
        if(State != BattleState.PlayerTurn) return;
        else StartCoroutine(PlayerAttack());
    }
}
