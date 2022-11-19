using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Saif.Scoreboards
{
    public class GameController : MonoBehaviour
    {

        public static bool GamePaused = false;

        public GameObject pauseMenuUI;

        public GameObject endMenuUI;

        private bool GameEnded =false;

        public TextMeshProUGUI endTimeText;

        public TextMeshProUGUI nameFieldText;

        private float gameEndTime;

        private string nameEntered;

        private bool scoreEntered=false;

        void Start()
        {
            TimerController.instance.BeginTimer();
        }
        

        
        void Update()
        {
            if(!GamePaused)
                TimerController.instance.ContinueTimer();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(GamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            if(Input.GetKeyDown(KeyCode.M))
            {
                GameEnd();
            }
        }


        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

        public void LoadMenu()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
            SceneManager.LoadScene("MainMenu");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }

        public void QuitGame()
        {
            Debug.Log("Quiting");
            Application.Quit();
        }

        public void Restart()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GameEnd()
        {
            endMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
            GameEnded = true;
            //Get and save time to scoreboard
            gameEndTime=gameObject.GetComponent<TimerController>().elapsedTime;
            TimeSpan timePlaying = TimeSpan.FromSeconds(gameEndTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            endTimeText.text=timePlayingStr;

            scoreEntered=false;
        }

        public void SaveScore()
        {
            if(scoreEntered==false)
            {
                if(nameFieldText.text.Length >0)
                    nameEntered=nameFieldText.text;
                else  
                    nameEntered="No name";
                    
                gameObject.GetComponent<Scoreboard>().AddEntry(new ScoreboardEntryData()
                    {
                        entryName = nameEntered,
                        entryScore = Mathf.Round(gameEndTime * 100.0f) * 0.01f
                    });
                scoreEntered=true;
            }
        }
    }
}