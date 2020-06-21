using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public Image bar;
    private PlayerManager player;

    [SerializeField]
    private int fixedTime;
    private float currentTime;

    void Start()
    {
        player = GetComponent<PlayerManager>();
        currentTime = 0;

        bar.fillAmount = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTime >= fixedTime)
        {
            currentTime = 0f;
            player.Turn();
            bar.fillAmount = 0f;
        }
        else
        {
            currentTime += Time.fixedDeltaTime;
            
            bar.fillAmount = currentTime / fixedTime;
        }
    }
}
