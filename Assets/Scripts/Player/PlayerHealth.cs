using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{


    public Image healthBar;
    public float healthAmount = 100f;
    public Text healthText;
    AudioSource auch;
    

    // Start is called before the first frame update
    void Start()
    {
        auch = GetComponent<AudioSource>();
        
        
        

    }

    // Update is called once per frame
    void Update()
    {

        if (healthAmount <= 0){
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Menu");
            
        }


        if(Input.GetKeyDown(KeyCode.H)){
            Heal(5);
        }

        healthText.text = "Health: " + healthAmount;
        
    }

    public void TakeDamage(float damage){

        auch.Play();
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

    }

    public void Heal(float healingAmount) {

        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

   
}
