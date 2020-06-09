using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPoolerScript pooler;

    public GameObject floatingText;

    Vector3 pos;

    void Start()
    {
        pooler = ObjectPoolerScript.Instance;
        pooler.SetupPool(floatingText, 10);
    }


    

    public void SpawnText(Vector3 position, string text, Color color)
    {
        GameObject obj = pooler.SpawnObject(floatingText, position);
        if (obj == null)
            return;

        Text t = obj.GetComponent<Text>();
        t.text = text;
        t.color = color;

        Debug.Log("Hi");
    }
 
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            SpawnText(pos, "Hello bitch", Color.red);
        }
    }
}
