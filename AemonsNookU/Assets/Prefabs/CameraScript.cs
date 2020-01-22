using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods
{
    public static float Ease(float curVal, float targetVal, float speed)
    {
        return curVal + (targetVal - curVal) * speed;
    }

    public static int Ease(int curVal, int targetVal, float speed)
    {
        return (int)(curVal + (targetVal - curVal) * speed);
    }

    public static double Ease(double curVal, double targetVal, float speed)
    {
        return (double)(curVal + (targetVal - curVal) * speed);
    }


    public static Vector3 Ease(Vector3 curVal, Vector3 targetVal, float speed)
    {
        return (Vector3)(curVal + (targetVal - curVal) * speed);
    }

}

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 TargetPos;



    public int MapHeight;
    public int MapWidth;

    public int tileDimension;
    public float SmoothingSpeed;

    public float minZoom = 3.5f;
    public float maxZoom;

    public float panSpeed;
    public float panBorderThickness;
    public float scrollSpeed;

    private float targetZoom;

        // Start is called before the first frame update
    void Start()
    {
        TargetPos = transform.position;
        maxZoom = (float)MapWidth * 1.5f;
        panSpeed += (float)MapWidth * 0.15f;
        scrollSpeed += (float)MapWidth * 0.25f;

        targetZoom = GetComponent<Camera>().orthographicSize;
        //CenterCamera();
    }


    // Update is called once per frame
    void Update()
    {

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
        float curZoom = GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize = GlobalMethods.Ease(curZoom, targetZoom, SmoothingSpeed);


        //TargetPos.x = Mathf.Clamp(TargetPos.x, 0, MapHeight*tileDimension);
        //TargetPos.z = Mathf.Clamp(TargetPos.z, 0, MapWidth*tileDimension);
        //TargetPos.y = Mathf.Clamp(TargetPos.y, minZoom, maxZoom);

        transform.position = GlobalMethods.Ease(transform.position, this.TargetPos, SmoothingSpeed);
    }

    public void CenterCamera()
    {
        float centerX = MapWidth / 2;
        float centerY = MapHeight / 2;
        float centerZ = (float)MapWidth * 0.8f;

        this.TargetPos = new Vector3(centerX, centerY, centerZ);
    }
}
