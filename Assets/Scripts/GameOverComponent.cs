
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Tanks
{
    public class GameOverComponent : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;

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
    }

}
