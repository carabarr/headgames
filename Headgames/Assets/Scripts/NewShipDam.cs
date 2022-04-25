using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewShipDam : MonoBehaviour
{
    public GameObject[] health;
	private int life;
	private int maxLives; 
	private GameObject player;
	
	
	private bool is_invincible = false;
	private MeshRenderer r;
	private GameObject trails;
	

    void Start()
    {
        life = health.Length;
		maxLives = health.Length;
		player = GameObject.FindWithTag("Player");
		
		trails = this.transform.GetChild(0).gameObject;
		r = this.GetComponent<MeshRenderer>();
    }

    public void TakeDamage(int damage)
	{
		if (is_invincible == false){
			if (life >= 1 && life <= maxLives)
			{
				life -= damage;
				//make flash effect
				Destroy(health[life].gameObject);
				StartCoroutine(DoBlinks(.5f, 0.1f));

				if (life < 1)
				{
					//Debug.Log("YOU DIED!! SAD!");
					SceneManager.LoadScene("GameOver");
				}
			}
		}
	}

     IEnumerator DoBlinks(float duration, float blinkTime) {
         while (duration > 0f) {
            duration -= Time.deltaTime;
      
            //toggle renderer
            r.enabled = !r.enabled;
			trails.SetActive(false);
			is_invincible = true; 
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
         }
  
         //make sure renderer is enabled when we exit
         r.enabled = true;
		is_invincible = false;
		 trails.SetActive (true);
     }
}
 
