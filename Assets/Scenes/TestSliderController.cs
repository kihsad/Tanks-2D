using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestSliderController : MonoBehaviour
{

    [SerializeField]
    private Slider  testSlider;

    [SerializeField]
    private TMP_Text testSliderText;

    public void TestSlider (float volume)
    {
        testSliderText.text = volume.ToString();

        testSlider.value = volume;

    }



}
