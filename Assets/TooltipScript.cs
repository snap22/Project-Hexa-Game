using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour
{
    public static TooltipScript Instance;
    private Text tooltipText;
    private Image image;
    private RectTransform rect;
    private Vector3 offset = new Vector3(1f, 1f, 0f);
    
    void Awake()
    {
        Instance = this;
        tooltipText = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
        rect = GetComponent<RectTransform>();
    }

    void Start()
    {
        
    }

    public void ShowToolTip(string text)
    {
        transform.position = Input.mousePosition + offset;
        gameObject.SetActive(true);

        tooltipText.text = text;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight);
        rect.sizeDelta = backgroundSize;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
