using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDamage : MonoBehaviour
{
	//array of health objects/ life describes how many lives remaining
	public GameObject[] health;
	private int life;
	private int maxLives; 
	private GameObject player;
  

    void Start()
    {
		life = health.Length;
		maxLives = health.Length;
		player = GameObject.FindWithTag("Player");
    }

	public void TakeDamage(int damage)
	{
		if (life >= 1 && life <= maxLives)
		{
			life -= damage;
			Destroy(health[life].gameObject);

			if (life < 1)
			{
				//Debug.Log("YOU DIED!! SAD!");
				StartCoroutine(toDie());
			}
		}
	}

  public void PickupHealthLife(int damage){
    //life += health ;
    if(life < maxLives){
      life += damage;
      health[life - 1].gameObject.SetActive(true);
    }
  }

	public void DamageAndRespawn(int damage)
	{
		TakeDamage(damage);
		if (life > 0){
			StartCoroutine(toDie());
		}
	}

	IEnumerator tearHeart(){
	
		yield return new WaitForSeconds(0.6f);
		health[life].gameObject.SetActive(false); 
	}
  
  IEnumerator toDie(){

    yield return new WaitForSeconds(1f);
	//TODO change to end screen with score
    SceneManager.LoadScene("MainMenu");
  }
}
	

