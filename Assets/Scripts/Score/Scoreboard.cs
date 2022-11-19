//Saif Jouda
//This code was assisted by the following tutorial: https://www.youtube.com/watch?v=FSEbPxf0kfs
using System.IO;
using UnityEngine;

namespace Saif.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 4;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private string testEntryName = "Name";
        [SerializeField] private float testEntryScore = 0;

        //Windows Loacted in Appdata > LocalLow > DefaultCompany > *ProjectName* (in this case App1)
        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            //if(highscoresHolderTransform !=null)
            UpdateUI(savedScores);
            SaveScores(savedScores);
        }

        //Test entry
        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardEntryData()
            {
                entryName = testEntryName,
                entryScore = testEntryScore
            });
        }

        //Adds a scoreboard entry (it may not be added if it is not high enough)
        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Checks to see if score is high enough to be added
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (scoreboardEntryData.entryScore < savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            //Check to see if score can be added to end of list
            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Removes any scores past capacity
            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            //UpdateUI(savedScores);
            SaveScores(savedScores);
        }

        //Updates the scoreboard by deleting all iterations/scores and placing new ones
        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            if(highscoresHolderTransform !=null)
            {
                foreach (Transform child in highscoresHolderTransform)
                {
                    Destroy(child.gameObject);
                }

                foreach (ScoreboardEntryData highscore in savedScores.highscores)
                {
                    Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
                }
            }
        }

        //Reads Save file
        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }


            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }


        //Saves the score
        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}
