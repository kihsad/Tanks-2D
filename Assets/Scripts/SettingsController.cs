using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Tanks
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField]
        private Button _backToMenuButton;

        [SerializeField]
        private AudioSource settingsSound;

        [SerializeField]
        private AudioSource buttonSound;

        public void onBackToMenu()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1.00f;
        }

        public void OnButton()
        {
            buttonSound.Play();
        }
    }

}
