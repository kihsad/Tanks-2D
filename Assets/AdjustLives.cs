using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Tanks
{

    public class AdjustLives : MonoBehaviour
    {

        public TMP_Text LivesText;

        public Slider livesSlider;

        private PlayerConditionComponent _playerLivesAmount;



        public void SetLives(float livesAmount)
        {
            _playerLivesAmount = FindObjectOfType<PlayerConditionComponent>();

            LivesText.text = livesAmount.ToString();
            livesSlider.value = _playerLivesAmount._health;

        }
    }
}
