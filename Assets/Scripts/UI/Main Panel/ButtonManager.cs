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
        public KeyCode keyCode;
        public Text hotkeyText;
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
    private int num;

    KeyCode[] keys;

    void Start()
    {
        keys = new KeyCode[buttons.Length];
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = buttons[i].keyCode;
            buttons[i].hotkeyText.text = keys[i].ToString();
            if (keys[i] == KeyCode.Escape)
                buttons[i].hotkeyText.text = "Esc";
        }
        
    }


    void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(buttons[i].keyCode))
                SetPanelActive(i);
        }
    }

    public void SetPanelActive(int index)       // todo - na treti klik rovnakeho buttonu aby to slo 
    {
        if (current == index)
            num++;
        else
            num = 0;

        if (num >= 2)
        {
            num = 0;
            current = -1;
        }
        
        buttons[index].SetPanel(true, selectedColor, normalColor);
        if (current >= 0)
            buttons[current].SetPanel(false, selectedColor, normalColor);
        

        current = index;

        
        
    }
}
