using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{

    public float zoomSpeed = 100f;
    public float minZoom = -100f;
    public float maxZoom = 100f;
    private float currentZoom = 10f;

    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        x = Camera.main.transform.position.x;
        y = Camera.main.transform.position.y;
        z = Camera.main.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        Camera.main.transform.position = new Vector3(x, y, z + currentZoom);
    }
}
