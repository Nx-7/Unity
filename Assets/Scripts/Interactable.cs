using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool useEvents;
    [SerializeField]
    public string prompMessage;

    public virtual string OnLook(){
        return prompMessage;
    }

    public void BaseInteract(){

        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact(){

    }
   
}
