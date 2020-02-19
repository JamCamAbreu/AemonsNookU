using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 TargetPos;

    public int MapHeight;
    public int MapWidth;

    public int tileDimension;
    public float SmoothingSpeed;

    public float minZoom = 3.5f;
    public float maxZoom;

    public float panSpeed;
    public float panBorderThickness;
    public float scrollSpeed;

    public float targetZoom;

    private const float LARGEST_MAX_ZOOM = 24f;
    private const float SMALLEST_MAX_ZOOM = 10f;

        // Start is called before the first frame update
    void Start()
    {
        TargetPos = transform.position;
        //panSpeed += (float)MapWidth * 0.25f;
        //scrollSpeed += (float)MapWidth * 0.5f;

        targetZoom = GetComponent<Camera>().orthographicSize;
        //CenterCamera();
    }


    // Update is called once per frame
    void Update()
    {
        maxZoom = Mathf.Clamp(MapWidth / 3.5f, SMALLEST_MAX_ZOOM, LARGEST_MAX_ZOOM);

        //if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        if (Input.GetKey("w"))
        {
            TargetPos.y += panSpeed * Time.deltaTime;
        }

        //if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        if (Input.GetKey("s"))
        {
            TargetPos.y -= panSpeed * Time.deltaTime;
        }

        //if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        if (Input.GetKey("d"))
        {
            TargetPos.x += panSpeed * Time.deltaTime;
        }

        //if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        if (Input.GetKey("a"))
        {
            TargetPos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scroll * scrollSpeed * 40f * Time.deltaTime;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        float curZoom = GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize = GlobalMethods.Ease(curZoom, targetZoom, SmoothingSpeed);


        TargetPos.x = Mathf.Clamp(TargetPos.x, 0, MapWidth);
        TargetPos.y = Mathf.Clamp(TargetPos.y, 0, MapHeight);


        transform.position = GlobalMethods.Ease(transform.position, this.TargetPos, SmoothingSpeed);
    }

    public void CenterCamera()
    {
        float centerX = MapWidth / 2;
        float centerY = MapHeight / 2;

        this.TargetPos = new Vector3(centerX, centerY, -10);
    }
}
