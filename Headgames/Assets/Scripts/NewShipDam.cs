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
	public ParticleSystem impactParticles;

	// speed up stuff
	public int starsCollected;
	GameObject forward;

	

    void Start()
    {
		starsCollected = 0;
        life = health.Length;
		maxLives = health.Length;
		player = GameObject.FindWithTag("Player");
		forward = GameObject.FindWithTag("Movement");
		
		trails = this.transform.GetChild(0).gameObject;
		r = this.GetComponent<MeshRenderer>();
    }


	void Update () {

		StartCoroutine(updateSpeedAfter10sec());
		
	}

	IEnumerator updateSpeedAfter10sec() {
		yield return new WaitForSeconds(10);
		if (starsCollected > 5) {
			Debug.Log("FAST");
			forward.GetComponent<ForwardMovement>().fastenMovement();
			player.GetComponent<NewShipDam>().resetStars();
			yield return new WaitForSeconds(10);
		} 
		//else {
		//	Debug.Log("SLOW DOWn");
		//	forward.GetComponent<ForwardMovement>().lowerMovement(0.1f);
		//} 
    }

    public void TakeDamage(int damage)
	{
		if (is_invincible == false){
			if (life >= 1 && life <= maxLives)
			{
				starsCollected = 0;
				life -= damage;
				//make flash effect
				Destroy(health[life].gameObject);
				Instantiate (impactParticles, this.transform.position, Quaternion.identity);
				StartCoroutine(DoBlinks(0.1f, 0.1f));

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


	public void collectedStarsRow () {
		
        starsCollected++;
		Debug.Log("COLLECTED STARS: " + starsCollected);
		
		
	}


	public void resetStars () {
		
        starsCollected = 0;
		
	}
}
 
