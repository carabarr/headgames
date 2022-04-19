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

    // Start is called before the first frame update
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
				SceneManager.LoadScene("GameOver");
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}