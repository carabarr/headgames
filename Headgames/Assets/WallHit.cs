using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    public int missedStars;
    GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindWithTag("Spawner");
        missedStars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (missedStars >= 3) {
            spawn.GetComponent<Spawner>().easierRange();

        }

        if (missedStars == 0) {
            Debug.Log("starting coroutine to make range wider");
            StartCoroutine(WidenRange());
        }
        
    }

    IEnumerator WidenRange() {
        yield return new WaitForSeconds(5);
        spawn.GetComponent<Spawner>().defaultRange();
    }

    public void missedStarsRow () {
		
        missedStars++;
		Debug.Log("number of missed stars in a row: " + missedStars);
		
		
	}

    public void resetStars () {
		
        missedStars = 0;
		
		
	}



    
}
