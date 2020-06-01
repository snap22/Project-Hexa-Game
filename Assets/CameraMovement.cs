using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 3f;

    Vector2 movement;
    private Rigidbody2D rb;

    public CinemachineVirtualCamera x;


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
