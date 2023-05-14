
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks
{

    public class UI_Manager : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField]
        private TMP_Text _healthText;

        [SerializeField]
        private int _playerScore;

        [SerializeField]
        private int _healthAmount;

        public ConditionComponent _healthComp;
        void Start()
        {
            _scoreText.text = "Score:";
        }

      
        public void AddScore()
        {
            _playerScore++;
            _scoreText.text = " Score: " + _playerScore.ToString();
        }

        public void ShowHealth()
        {
            _healthAmount--;
            _healthText.text = "Health: " + _healthAmount.ToString();
        }
    }

}
