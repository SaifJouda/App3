using TMPro;
using UnityEngine;

namespace Saif.Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        //Name
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        //Score
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        //Initialiser
        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }
}
