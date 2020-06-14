using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPanelScript : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public ProgressBarScript progressBar;

    public Text currentLevel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

}
