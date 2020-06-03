using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public float speed = 3f;
    private float boostSpeed = 1f;
    Camera cam;

    Vector2 movement;
    private Rigidbody2D rb;

    Transform camTransform;

    private float zoom;

    float actual;
    [SerializeField] float minZoom = 1f;
    [SerializeField] float maxZoom = 5f;

    [SerializeField] Vector2 minLocation = new Vector2(-50f, -50f);
    [SerializeField] Vector2 maxLocation = new Vector2(50f, 50f);

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        camTransform = cam.transform;

        zoom = cam.orthographicSize;
        cam.orthographicSize = 20;
    }

   
    void Update()
    {
        
        ZoomCamera();
        MoveCamera();
    }


    // Stara sa o pohyb kamery
    private void MoveCamera()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        //Kontrola ci hrac "nevysiel z mapy "
        if (movement.x > 0 && transform.position.x >= maxLocation.x)
        {
            return;
        }
        if (movement.x < 0 && transform.position.x <= minLocation.x)
        {
            return;
        }
        if (movement.y > 0 && transform.position.y >= maxLocation.y)
        {
            return;
        }
        if (movement.y < 0 && transform.position.y <= minLocation.y)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boostSpeed = speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boostSpeed = 1f;
        }
        rb.MovePosition(rb.position + movement * boostSpeed * speed * Time.fixedDeltaTime);
    }

    //  Stara sa o zoom kamery
    private void ZoomCamera()
    {
        actual = Input.GetAxis("Mouse ScrollWheel"); 
        
        if (actual > 0 && zoom <= minZoom)
        {
            return;
        }

        if (actual < 0 && zoom >= maxZoom)
        {
            return;
        }

        zoom -= actual;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * speed);
    }
}
