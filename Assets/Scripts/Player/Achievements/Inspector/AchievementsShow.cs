﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsShow : MonoBehaviour
{
    public static AchievementsShow Instance;
    void Awake()
    {
        Instance = this;
    }

    public PlayerManager playerManager;
    public GameObject prefab;

    public Sprite[] images;

    public Color lockedNameColor;
    public Color lockedDescriptionColor;
    public Color unlockedColor;

    public Transform parentObject;

    public Announcement announcement;


    private Dictionary<Achievement, GameObject> holders;
    void Start()
    {
        AchievementsHolder.OnAchievementCompleted += Unlock;
        holders = new Dictionary<Achievement, GameObject>();

        foreach (Achievement achievement in playerManager.player.achievements.GetAchievements())
        {
            GenerateAchievementHolder(achievement);
        }



        //StartCoroutine(LateStart(1f));
    }

    private void GenerateAchievementHolder(Achievement achievement)
    {
        GameObject obj = Instantiate(prefab, parentObject);
        Text nameText = obj.GetComponentInChildren<NameTextScript>().GetComponent<Text>();
        Text descriptionText = obj.GetComponentInChildren<DescriptionTextScript>().GetComponent<Text>();
        Image icon = obj.GetComponentInChildren<ImageTextScript>().GetComponent<Image>();

        icon.sprite = this.GetImage(achievement);
        nameText.text = achievement.name;
        descriptionText.text = achievement.GetDescription();


        Color nameColor = lockedNameColor;
        Color descriptionColor = lockedDescriptionColor;
        /*if (achievement.IsCompleted())
        {
            nameColor = unlockedColor;
            descriptionColor = unlockedColor;
        }*/

        holders.Add(achievement, obj);
        
    }

    public void CheckAllAchievements()
    {
        foreach (Achievement achievement in this.holders.Keys)
        {
            if (achievement == null)
                continue;

            Unlock(achievement);
        }
    }

    public void UnlockCompleted(List<Achievement> achievs)
    {
        for (int i = 0; i < achievs.Count; i++)
        {
            Unlock(achievs[i]);
        }
    }

    public void UnlockCompleted(Achievement achiev)
    {
        Unlock(achiev);
        Debug.Log("Called to unlock for: " + achiev.name);
    }

    private void Unlock(Achievement achievement)
    {
        if (!achievement.IsCompleted())
            return;

        GameObject obj = this.holders[achievement];
        if (obj == null)
            return;

        obj.GetComponentInChildren<NameTextScript>().GetComponent<Text>().color = unlockedColor;
        obj.GetComponentInChildren<DescriptionTextScript>().GetComponent<Text>().color = unlockedColor;
        obj.GetComponentInChildren<ImageTextScript>().GetComponent<Image>().sprite = GetImage(achievement);

        announcement.Call("Achievement unlocked", achievement.name);

    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Achievements: ");
            foreach (Achievement achievement in this.holders.Keys)
            {

                Debug.Log(achievement.name);
                //CheckAchievement(achievement);
            }
        }
    }*/

    private Sprite GetImage(Achievement achiev)
    {
        if (!achiev.IsCompleted())
            return this.images[0];

        switch (achiev.GetAchievType())
        {
            case AchievType.Bronze:
                return this.images[1];
            case AchievType.Silver:
                return this.images[2];
            case AchievType.Gold:
                return this.images[3];
        }

        return null;
    }

    IEnumerator LateStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        /*foreach (Achievement achievement in playerManager.player.achievements.GetAchievements())
        {
            GenerateAchievementHolder(achievement);
        }*/
    }

    
}
