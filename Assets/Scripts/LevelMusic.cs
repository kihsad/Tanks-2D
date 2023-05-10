using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks { 

public class LevelMusic : MonoBehaviour
  {

    [SerializeField]
    public AudioSource levelMusic;

    public GameObject GameOverPanel;

    public bool isGameOver = true;

    public void StopMusic()
    {
        if (isGameOver == true)
        {
            levelMusic.Stop();
        }
    }


  }
}

