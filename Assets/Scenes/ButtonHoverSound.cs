using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverSound : MonoBehaviour
{
    [SerializeField]
    public AudioSource buttonSound;

    [SerializeField]
    public AudioClip buttonHover;

    public void OnHoverButton()
    {
        buttonSound.PlayOneShot(buttonHover);
    }



}
