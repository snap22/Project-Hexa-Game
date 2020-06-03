using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolButtonScript : MonoBehaviour
{
    public Color selectedColor;
    public Color normalColor;

    public Image[] buttons;

    private int selectedButtonIndex = 0;
    void Start()
    {
        SetButtonActive(0);
    }

    // zmeni farbu buttonu podla zadaneho indexu
    public void SetButtonActive(int index)
    {
        buttons[selectedButtonIndex].color = normalColor;
        buttons[index].color = selectedColor;
        selectedButtonIndex = index;
    }
}
