using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace Tanks 
{ 


public class AdjustVolume : MonoBehaviour
  {
        public AudioMixer mixer;

        public TMP_Text VolumeText;

    public Slider slider;

        public void Start()
        {
            slider.value = PlayerPrefs.GetFloat("MusicVolume", 5f);
        }

        public void AdjustLevel (float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

        VolumeText.text = volume.ToString();
        slider.value = volume;


        }


    }
}
