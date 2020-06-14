using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    private enum TheThing { Sound, Music };
    public Image soundImg;
    public Sprite soundOn;
    public Sprite soundOff;
    

    public Image musicImg;
    public Sprite musicOn;
    public Sprite musicOff;

    public Slider soundSlider;
    public Slider musicSlider;
    

    private bool soundState;
    private bool musicState;

    private float currentSound;
    private float currentMusic;

    void Start()
    {
        soundState = true;
        musicState = true;
        currentSound = soundSlider.value;
        currentMusic = musicSlider.value;
        Debug.Log("start sound: " + currentSound);
    }

    public void ToogleSound()
    {
        soundState = !soundState;
        SetupIcon(soundState, TheThing.Sound);
        Debug.Log("Current sound: " + currentSound);
    }

    public void ToogleMusic()
    {
        musicState = !musicState;
        SetupIcon(musicState, TheThing.Music);
    }

    public void ChangeSound(float newValue)
    {
        //currentSound = newValue;
        if (newValue <= 0)
            SetupIcon(false, TheThing.Sound);
        else
            SetupIcon(true, TheThing.Sound);

        // changes sound
    }

    public void ChangeMusic(float newValue)
    {
        //currentMusic = newValue;
        if (newValue <= 0)
            SetupIcon(false, TheThing.Music);
        else
            SetupIcon(true, TheThing.Music);

        // changes music
    }

    private void SetupIcon(bool state, TheThing thing)
    {
        switch (thing)
        {
            case TheThing.Sound:
                if (state)
                {
                    soundImg.sprite = soundOn;
                    soundSlider.value = 0.1f;
                } 
                else
                {
                    soundImg.sprite = soundOff;
                    soundSlider.value = 0;
                }
                    
                break;

            case TheThing.Music:
                if (state)
                {
                    musicImg.sprite = musicOn;
                    musicSlider.value = 0.1f;
                }
                else
                {
                    musicImg.sprite = musicOff;
                    musicSlider.value = 0;
                }
                break;
        }
    }

}
