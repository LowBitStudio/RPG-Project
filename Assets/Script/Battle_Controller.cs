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

    void Start()
    {
        //Start the battle
        State = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Batlle has started!");
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

        battle_text.text = "Enemy received damage!";
        yield return new WaitForSeconds(2f);

        State = BattleState.EnemyTurn;
        StartCoroutine(EnemyTurn());
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
        StartCoroutine(PlayerAttack());
    }
}
