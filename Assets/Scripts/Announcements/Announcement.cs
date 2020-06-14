using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announcement : MonoBehaviour
{



    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color hiddenColor;


    private RectTransform rect;
    
    void Start()
    {
        rect = GetComponent<RectTransform>();
        Player.OnAnnouncement += Call;
        AchievementsHolder.OnAnnouncement += Call;

        Reset();
    }
    public void Call(string nameText, string descriptionText)
    {
        LeanTween.color(rect, normalColor, 0.1f);
        this.nameText.text = nameText;
        this.descriptionText.text = descriptionText;

        StartCoroutine(WaitAndReset(1f));

    }
    public void Call(IAnnouncable announcement)
    {
        LeanTween.color(rect, normalColor, 0.1f);
        this.nameText.text = announcement.GetAnnouncementName();
        this.descriptionText.text = announcement.GetAnnouncementDescription();

        StartCoroutine(WaitAndReset(1f));

    }

    private void Reset()
    {
        this.nameText.text = "";
        this.descriptionText.text = "";
        //LeanTween.textAlpha(rect, 0f, 2f).setEase(LeanTweenType.easeInCirc);
        LeanTween.color(rect, hiddenColor, 0.1f).setEase(LeanTweenType.easeInCirc);
        //Debug.Log("Reseting");
    }

    IEnumerator WaitAndReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        Reset();
    }
}
