﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public ButtonManager btn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleOptions()
    {
        bool shouldShow = !optionsPanel.activeSelf;
        optionsPanel.SetActive(shouldShow);
    }

    public void ResumeGame()
    {
        btn.SetPanelActive(3);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        //quit game
    }

    public void BackToMenu()
    {
        //return to menu
    }

    void OnDisable()
    {
        optionsPanel.SetActive(false);
    }

}
