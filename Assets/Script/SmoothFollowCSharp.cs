// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden

using UnityEngine;
using System.Collections;

// Place the script in the Camera-Control group in the component menu
[AddComponentMenu("Camera-Control/Smooth Follow CSharp")]

public class SmoothFollowCSharp : MonoBehaviour
{
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public static float distance = 5.0f;
    // the height we want the camera to be above the target
    public float maxdistance = 10.0f;
    // How much we 
    public float mindistance = 0.0f;

    public float sensitivity = 100;

    public float ScrollWheelspeed = 60.0f;
    //public float horizontalRotation = 5.0f;

    float z = 10;

    public float x;
    public float y;

    Vector3 offset;

    Quaternion rotationEuler;

    private bool Rhit;

    private float h;

    void Start()
    {
        target = GameObject.Find("camera_t").transform;
    }
    void LateUpdate()
    {
        cameraRay();
        // Early out if we don't have a target
        if (!target)
            return;
        if (target)
        {
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity * z;
                y -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity * z;
            }

            if (x > 360)
            {
                x -= 360;
            }
            else if (x < 0)
            {
                x += 360;
            }

            float d = distance - Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Lerp(distance, d, z);
            distance = Mathf.Clamp(distance, mindistance, maxdistance);

            rotationEuler = Quaternion.Euler(y, x, 0);

            if (!Rhit)
            { offset = rotationEuler * new Vector3(0, 0, -distance) + target.position; }
            if (Rhit)
            { offset = rotationEuler * new Vector3(0, 0, -h) + target.position; }

            transform.position = Vector3.Lerp(transform.localPosition, offset, Time.deltaTime * ScrollWheelspeed);
            transform.rotation = rotationEuler;


            transform.LookAt(target);

        }
    }

    void cameraRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.TransformDirection(-Vector3.forward), out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                h = hit.distance / 2;
                Rhit = true;
            }
        }
        else
        {
            Rhit = false;
        }

        if (h > distance && Rhit == true)
        {
            Rhit = false;
        }
    }
}
