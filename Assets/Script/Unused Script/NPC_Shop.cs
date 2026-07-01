using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Shop : MonoBehaviour, Iinteractable
{
    public NPC_Scriptable scriptedNPCData;
    public GameObject dialoguePanel;
    public TMP_Text nametext, dialogue_Text;

    private int dialogueindex;
    private bool isTyping, isDialogueActive;

    private void Start() 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            Debug.Log("you can interact");    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            Debug.Log("Player cannot interact with " + this.gameObject);    
    }

    public void interact()
    {
        if(scriptedNPCData == null || !isDialogueActive) return; //Please add pause later...
        if(isDialogueActive) //if already have running dialogue
        {
            NextLine();
        }
        else
        {
            Startdialogue();
        }
    }

    public bool CanInteract()
    {
        return !isDialogueActive;   
    }

    void Startdialogue()
    {
        isDialogueActive = true;
        dialogueindex = 0;

        nametext.SetText(scriptedNPCData.name);

        dialoguePanel.SetActive(true);
        //Do pause here (Later)

        StartCoroutine(Typeline());
    }

    void NextLine()
    {
        if(isTyping)
        {
            StopAllCoroutines();
            dialogue_Text.SetText(scriptedNPCData.dialogue_line[dialogueindex]);
        }
        else if(dialogueindex + 1 < scriptedNPCData.dialogue_line.Length)
        {
            StartCoroutine(Typeline());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator Typeline()
    {
        isTyping = true;
        dialogue_Text.SetText("");

        foreach(char letter in scriptedNPCData.dialogue_line[dialogueindex])
        {
            dialogue_Text.text += letter;
            yield return new WaitForSeconds(scriptedNPCData.typingspeed);
        }
        isTyping = false;

        if(scriptedNPCData.autoprogressline.Length > dialogueindex && scriptedNPCData.autoprogressline[dialogueindex])
        {
            yield return new WaitForSeconds(scriptedNPCData.autoProgressDelay);
        }

    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogue_Text.SetText("");
        dialoguePanel.SetActive(false);
        //Unpause here
    }
}
