using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextScript : MonoBehaviour
{

    private float currentY;

    [SerializeField]
    private float distance;
    [SerializeField]
    private float time;
    Text shit;

    RectTransform fuck;
    
    void Start()
    {
        
        //LeanTween.moveY(gameObject, currentY + distance, time).setEase(LeanTweenType.easeInCirc);
        //LeanTween.alphaText(fuck, 0f, time).setEase(LeanTweenType.easeInCirc);
        
    }

    void OnEnable()
    {
        FadeAway();
    }

    void OnDisable()
    {
        //shit.color.a = 1f;
    }

    void FadeAway()
    {
        shit = GetComponent<Text>();
        fuck = GetComponent<RectTransform>();
        currentY = transform.position.y;
        LeanTween.moveY(gameObject, currentY + distance, time).setEase(LeanTweenType.easeInCirc);
        LeanTween.alphaText(fuck, 0f, time).setEase(LeanTweenType.easeInCirc);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(time);

        Color color = new Color(0, 0, 0, 1f);
        shit.color = color;
        gameObject.SetActive(false);
    }

    
}
