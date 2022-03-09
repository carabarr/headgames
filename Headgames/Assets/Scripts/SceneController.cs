using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public string nextSceneName;

	//function that loads a scene specified in the inspector window 
   public void LoadLevel1(){
        SceneManager.LoadScene(nextSceneName);
    }
	
	//can send player to a new scene based on specified collision
	//idk maybe we'll use it?
	private void OnCollisionEnter2D(Collision2D collision)
	{
	   if (collision.gameObject.CompareTag("Player"))
		  SceneManager.LoadScene(nextSceneName);
	}

	      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }
}
