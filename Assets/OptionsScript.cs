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

    public Dropdown dropdown;
    private Resolution[] resolutions;
    private int offset;     //pre resolutiony aby nezacalo s malymi ako napr 320x200 atd.. zacina sa od 800x600 - čo je 7. index v podstate
    private bool wantFullScreen;
    private int selectedIndex;

    void Start()
    {
        wantFullScreen = true;
        soundState = true;
        musicState = true;
        currentSound = soundSlider.value;
        currentMusic = musicSlider.value;
        // DROPDOWN PRE RESOLUTIONS
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        offset = 6;

        for (int i = offset; i < resolutions.Length; i++)
        {
            string option = string.Format("{0} x {1}", resolutions[i].width, resolutions[i].height);
            options.Add(option);
            if (resolutions[i].Equals(Screen.currentResolution))
                currentResolutionIndex = i;
        }

        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
    }

    public void ToogleSound()
    {
        soundState = !soundState;
        SetupIcon(soundState, TheThing.Sound);
        //Debug.Log("Current sound: " + currentSound);
        if (soundState)
            soundSlider.value = 0.1f;
    }

    public void ToogleMusic()
    {
        musicState = !musicState;
        SetupIcon(musicState, TheThing.Music);
        if (musicState)
            musicSlider.value = 0.1f;
    }

    public void ChangeSound(float newValue)
    {
       
        //currentSound = newValue;
        if (newValue <= 0)
        {
            SetupIcon(false, TheThing.Sound);
            soundState = false;
        }
        else
        {
            SetupIcon(true, TheThing.Sound);
            soundState = true;
        }
            
        
        // changes sound
    }

    public void ChangeMusic(float newValue)
    {
        
        //currentMusic = newValue;
        if (newValue <= 0)
        {
            SetupIcon(false, TheThing.Music);
            musicState = false;
        }
        else
        {
            SetupIcon(true, TheThing.Music);
            musicState = true;
        }
            
        
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
                    //soundSlider.value = 0.1f;
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
                    //musicSlider.value = 0.1f;
                }
                else
                {
                    musicImg.sprite = musicOff;
                    musicSlider.value = 0;
                }
                break;
        }
    }

    public void ChangeResolution(int index)
    {
        int newIndex = index + offset;  //aby spravne ukazovalo aj vyberalo z dropdown menu
        Screen.SetResolution(resolutions[newIndex].width, resolutions[newIndex].height, this.wantFullScreen);
        this.selectedIndex = index;
        Debug.Log(string.Format("Setting the resolution for {0}x{1}. Fullscreen mode: {2}", resolutions[newIndex].width, resolutions[newIndex].height, this.wantFullScreen));
    }

    public void ChangeFullScreenMode(bool newVal)
    {
        this.wantFullScreen = newVal;
        this.ChangeResolution(this.selectedIndex);
    }

}
