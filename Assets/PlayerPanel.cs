using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public ProgressBarScript progressBar;
    public PlayerManager playerManager;

    public Text[] texts;

    public Text levelText;

    private Player player;

    void Start()
    {
        player = playerManager.player;
        Player.OnPanelUpgrade += UpdateUI;
        UpdateUI(player);
    }

    public void UpdateUI(Player p)
    {
        UpdateCurrent(player.NumberOfBuildings);
        UpdateBuilt(player.totalBuilt);
        UpdateRemoved(player.totalRemoved);
        levelText.text = player.Level.ToString();
        progressBar.Upgrade(player.levelHandler.currentXp, player.levelHandler.requiredXp);
    }


    // updatetovanie textov
    private void UpdateText(int index, int number)
    {
        if (index >= texts.Length)
            return;

        texts[index].text = number.ToString();
    }


    public void UpdateCurrent(int amount) => UpdateText(0, amount);
    public void UpdateBuilt(int amount) => UpdateText(1, amount);
    public void UpdateRemoved(int amount) => UpdateText(2, amount);
    




}
