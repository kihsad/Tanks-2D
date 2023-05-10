using System.Collections;
using System.Collections.Generic;
using Tanks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tanks
{
    public class HealthBar : MonoBehaviour
    {

        private Transform[] _healthHearts = new Transform[3];

        private PlayerConditionComponent player;


        private void Awake()

        {
            player = FindObjectOfType<PlayerConditionComponent>();

            for (int i = 0; i < _healthHearts.Length; i++)
            {
                _healthHearts[i] = transform.GetChild(i);
            }
        }

        public void RefreshHealthHearts()
        {

            for (int i = 0; i < _healthHearts.Length; i++)
            {
                if (i < player.Lives) _healthHearts[i].gameObject.SetActive(true);
                else _healthHearts[i].gameObject.SetActive(false);
            }


        }
    }







}
