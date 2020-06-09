using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextScript : MonoBehaviour
{

    [SerializeField]
    private float time;
    
    
    void OnEnable()
    {
        StartCoroutine(GoDark());
    }

    IEnumerator GoDark()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    

    
}
