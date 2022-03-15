using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour  {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
		public GameObject controlsUI;
		public GameObject volumeUI;
		public GameObject PauseButton;
		public GameObject StatsIndicators;

        //public AudioMixer mixer;
		//public static float volumeLevel = 1.0f;
		//private Slider sliderVolumeCtrl;

        void Awake (){
                //SetLevel (volumeLevel);
                //GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                //if (sliderTemp != null){
                        //sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        //sliderVolumeCtrl.value = volumeLevel;
                //}
        }

        void Start (){
                pauseMenuUI.SetActive(false);
				controlsUI.SetActive(false);
				volumeUI.SetActive(false);

        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                //if(Input.GetButtonDown("Pause")){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        public void Pause(){
                pauseMenuUI.SetActive(true);
				PauseButton.SetActive(false);
				StatsIndicators.SetActive(false);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
				StatsIndicators.SetActive(true);
				PauseButton.SetActive(true);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

		public void HideControls()
		{
			controlsUI.SetActive(false);
		}

		public void ShowControls()
		{
			controlsUI.SetActive(true);
		}

		public void HideVolume()
		{
			volumeUI.SetActive(false);
		}

		public void ShowVolume()
		{
			volumeUI.SetActive(true);
		}

        public void Restart(){
                Time.timeScale = 1f;
                //restart the game:
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
				//SceneManager.LoadScene ("TitleScreen");
        }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

        public void SetLevel (float sliderValue){
                //mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                //volumeLevel = sliderValue;
        }
}