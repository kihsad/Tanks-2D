using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

namespace Tanks

{
    public class MenuController : MonoBehaviour
    {

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private AudioSource _buttonSound;

        [SerializeField]
        private AudioSource menuMusic;


        public void OnRestart()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        public void OnSettings()
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1.0f;
        }

        public void OnExit()
        {
            EditorApplication.isPlaying = false;
            Time.timeScale = 1.0f;
        }

        public void OnButton()
        {
            _buttonSound.Play();
        }

    }
}
