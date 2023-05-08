using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private Button _backToMenuButton;

    public void onBackToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.00f;
    }
}
