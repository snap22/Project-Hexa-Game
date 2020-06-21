using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player { get; private set; }

    public Text goldText;
    public Text woodText;
    public Text stoneText;

    void Awake()
    {
        player = new Player();
    }
    void Start()
    {
        UpdateResourcesText();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.UpdateBuildings();
            UpdateResourcesText();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Current Buildings: ");
            player.buildings.Test();
        }
    }*/

    public void UpdateResourcesText()
    {
        goldText.text = player.goldAmount.ToString();
        woodText.text = player.woodAmount.ToString();
        stoneText.text = player.stoneAmount.ToString();
    }

    public void Turn()
    {
        player.UpdateBuildings();
        UpdateResourcesText();
    }
}
