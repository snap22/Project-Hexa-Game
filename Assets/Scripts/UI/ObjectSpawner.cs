﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;
    ObjectPoolerScript pooler;
    RectTransform rect;

    public Color basicColor;
    public Color errorColor;
    void Start()
    {
        pooler = ObjectPoolerScript.Instance;
        pooler.SetupPool(prefab, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Input.mousePosition;
            Spawn(pos, "+ 5 xp", Color.red);
        }
    }

    void Spawn(Vector3 position, string newText, Color color)
    {
        GameObject obj = pooler.SpawnObject(prefab, position);
        Text textObj = obj.GetComponent<Text>();
        textObj.text = newText;
        textObj.color = color;
        Vector2 backgroundSize = new Vector2(textObj.preferredWidth, textObj.preferredHeight);
        rect = obj.GetComponent<RectTransform>();
        rect.sizeDelta = backgroundSize;
        
        
        LeanTween.textAlpha(rect, 0f, 1.5f).setEase(LeanTweenType.easeInCirc);
        
    }

    public void SetInfoText(Vector3 position, string text)
    {
        Spawn(position, text, basicColor);
    }

    public void SetErrorText(Vector3 position, string text)
    {
        Spawn(position, text, errorColor);
    }

}
