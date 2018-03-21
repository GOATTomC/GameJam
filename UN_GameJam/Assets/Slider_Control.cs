using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slider_Control : MonoBehaviour
{
    public float volume_input;
    public Slider volume_Slider;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        volume_Slider.value = 0.5f;
        sound.Play();
    }
    

    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        volume_input = volume_Slider.value;
        sound.volume = volume_input;
    }
}