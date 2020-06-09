using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableScript : MonoBehaviour
{
    Camera cam;

    bool shouldMove;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shouldMove = true;
        }

        if (Input.GetMouseButtonUp(0))
            shouldMove = false;

        if (shouldMove)
            transform.position = Input.mousePosition;

    }

    void DragAndMove()
    {
        transform.position = Input.mousePosition;
    }
}
