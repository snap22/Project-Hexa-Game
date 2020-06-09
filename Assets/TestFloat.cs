using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFloat : MonoBehaviour
{
    public GameObject prefab;
    ObjectPoolerScript pooler;
    RectTransform rect;
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
        /*Vector2 backgroundSize = new Vector2(textObj.preferredWidth, textObj.preferredHeight);
        rect = obj.GetComponent<RectTransform>();
        rect.sizeDelta = backgroundSize;*/
        LeanTween.textAlpha(rect, 0f, 1f);
        
    }
}
