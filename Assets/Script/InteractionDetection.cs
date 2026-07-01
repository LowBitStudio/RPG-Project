using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetection : MonoBehaviour
{
    private Iinteractable interactable_obj = null; //Not yet detected interacted object
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        //Press E to interact
        if(context.performed)
        {
            //This will start the dialogue
            interactable_obj?.interact();
            //Debug.Log("Pressed E");
        }
    }

    //It can detect the NPC so that's nice :)
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Detect the NPC or object
        if(collision.TryGetComponent(out Iinteractable interactable) && interactable.CanInteract())
        {
            interactable_obj = interactable;
            Debug.Log("you can interact");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //Outside of interaction object
        if(collision.TryGetComponent(out Iinteractable interactable) && interactable == interactable_obj)
        {
            interactable_obj = null;
            Debug.Log("you cannot interact");
        }
    }
}
