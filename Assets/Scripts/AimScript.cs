using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimScript : MonoBehaviour
{

    public GameObject Gun;
    public Image crosshairImage;



    // Start is called before the first frame update
    void Start()
    {

        crosshairImage.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(1)){
            crosshairImage.enabled = false;
            Gun.GetComponent<Animator>().Play("AimingAnimation");
        }

        if(Input.GetMouseButtonUp(1)){
            crosshairImage.enabled = true;
            Gun.GetComponent<Animator>().Play("Idle");
        }



        
    }
}
