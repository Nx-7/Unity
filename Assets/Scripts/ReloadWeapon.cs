using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeapon : MonoBehaviour
{

    public Animator rigController;
    public WeaponAnimationEvents animationEvents;
    //public ActiveWeapon activeWeapon;
    public Transform leftHand;
    

    GameObject magazineHand;

    // Start is called before the first frame update
    void Start()
    {
        animationEvents.WeaponAnimationEvent.AddListener(OnAnimationEvent);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)){
            
            rigController.SetTrigger("reload_weapon");
        }
        
    }

    void OnAnimationEvent(string eventName){
        Debug.Log(eventName);
        switch (eventName) {
            case "detach_magazine":
                DetachMagazine();
                break;
            case "drop_magazine":
                DropMagazine();
                break;
            case "refill_magazine":
                RefillMagazine();
                break;
            case "attach_magazine":
                AttachMagazine();
                break;
    }

    void DetachMagazine(){



        

    }

    void DropMagazine(){

    }

    void RefillMagazine(){

    }

    void AttachMagazine(){


    }





    }
}
