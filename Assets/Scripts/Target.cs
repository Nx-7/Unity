using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour, IDamageable 
{
    
    public float health = 100f;
    public GameObject boneco;
    private AiLocomotion aiLocomotion;

    private void Start()
    {
        aiLocomotion = GetComponent<AiLocomotion>();
    }


    public void Damage(float damage){

        health -= damage;
        if (health <= 0){
            boneco.GetComponent<Animator>().Play("Died");
            GameObject Player = GameObject.FindWithTag("Player");
            if (Player != null){
                PlayerScore score = Player.GetComponent<PlayerScore>();

                if(score != null){
                    score.kills += 1;
                    Debug.Log(score.kills);
                }
            }

            aiLocomotion.agent.isStopped = true;
            Debug.Log(aiLocomotion.agent.isStopped);
            GetComponent<AiLocomotion>().agent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(DestroyAfterDelay());

        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(2f); 
        Destroy(gameObject);



    }

}
