using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slider_Control : MonoBehaviour
{
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        volume_Slider.value = 0.5f;
        sound.Play();
    }
    public Slider volume_Slider;

    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        sound.volume = volume_Slider.value;
    }
}