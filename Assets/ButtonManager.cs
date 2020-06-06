using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class MainPanelButton
    {
        public Image button;
        public GameObject panel;

        public void SetPanel(bool active, Color selectedColor, Color normalColor)
        {
            if (panel != null)
                this.panel.SetActive(active);


            if (active)
                this.button.color = selectedColor;
            else
                this.button.color = normalColor;
        }



    }
    public Color selectedColor;
    public Color normalColor;

    public MainPanelButton[] buttons;

    private int current = -1;

    void Start()
    {
        
    }

    public void SetPanelActive(int index)       // todo - na treti klik rovnakeho buttonu aby to slo 
    {
        
        buttons[index].SetPanel(true, selectedColor, normalColor);
        if (current >= 0)
            buttons[current].SetPanel(false, selectedColor, normalColor);
        

        current = index;

        
        
    }
}
