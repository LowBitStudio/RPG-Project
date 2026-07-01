using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class NPC_General : MonoBehaviour, Iinteractable
{
    public NPC_Scriptable DialogueData; //Take the dialogue data of the attached scriptable object
    public GameObject DialoguePanel; //Get the panel
    [Header("NPC Text")]
    public TMP_Text nametext, dialogue_Text;

    private int dialogueIndex = 0;
    private bool isTyping, isDialogueActive;
    
    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    //This script controls is the general dialogue setup for NPCs.
    public void interact()
    {
        //Debug.Log("Do some interaction with NPC");
        //If the dialogue data is null or the dialogue is not active this will not happen
        //if(DialogueData == null || !isDialogueActive){return;} //Please add pause later...
        //idk why if I have that condition it'll just not activate ^
        //Probably OR bool is not active as part of the condition
        
        if(isDialogueActive) //if already have running dialogue
        {
            //If the the dialogue is already on going
            //Then move forward to the next line ()
            Nextline();
        }
        else
        {
            //Once the player interact for the first time
            //Dialogue will start
            Startdialogue();
        }
    }

    //Function to start the dialogue
    void Startdialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;
        nametext.SetText(DialogueData.npc_name);

        DialoguePanel.SetActive(true);
        //Do pause here (Later)

        //Will start the dialogue with letter coming one by one
        StartCoroutine(TypeLine());
    }

    void Nextline()
    {
        if(isTyping)
        {
            StopAllCoroutines();
            dialogue_Text.SetText(DialogueData.dialogue_line[dialogueIndex]);
            isTyping = false;
        }
        else if(++dialogueIndex < DialogueData.dialogue_line.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogue_Text.SetText("");
        DialoguePanel.SetActive(false);
        //Add pause here don't forget
    }

    //This will make the letter to appear one by one like typing
    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogue_Text.SetText("");

        foreach(char letter in DialogueData.dialogue_line[dialogueIndex])
        {
            dialogue_Text.text += letter;
            yield return new WaitForSeconds(DialogueData.typingspeed);
        }

        isTyping = false;

        if(DialogueData.autoprogressline.Length > dialogueIndex && DialogueData.autoprogressline[dialogueIndex])
        {
            yield return new WaitForSeconds(DialogueData.autoProgressDelay);
        }
    }
}
