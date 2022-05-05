using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    public int missedStars;
    GameObject spawn;
	GameObject forward;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindWithTag("Spawner");
		forward = GameObject.FindWithTag("Movement");
        missedStars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (missedStars >= 3) {
            spawn.GetComponent<Spawner>().easierRange();
			forward.GetComponent<ForwardMovement>().lowerMovement(0.1f);
        }

        StartCoroutine(WidenRange());
        
        
        
    }

    IEnumerator WidenRange() {
        if (missedStars == 0) {
            yield return new WaitForSeconds(5);
            spawn.GetComponent<Spawner>().defaultRange(); 
        }
    }

    public void missedStarsRow () {
		
        missedStars++;
		Debug.Log("number of missed stars in a row: " + missedStars);
		
		
	}

    public void resetStars () {
		
        missedStars = 0;
		
		
	}



    
}
