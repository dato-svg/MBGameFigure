using TMPro;
using UnityEngine;

namespace BaeScripts
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreTextInGame;
        [SerializeField] private TMP_Text scoreTextInUI;
        [SerializeField] private int score;

        private void Start() =>
            UpdateUI();

        public void AddScore()
        {
            score++;
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreTextInGame.text = score.ToString();
            scoreTextInUI.text = score.ToString();
        }
           
    }
}
