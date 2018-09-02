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


    [SerializeField, Range(1.0f, 10.0f)]
    public float distance = 5.0f;
    // the height we want the camera to be above the target
    public float maxdistance = 10.0f;
    // How much we 
    public float mindistance = 0.0f;
    public float sensitivity = 100;
    public float ScrollWheelspeed = 60.0f;
    //public float horizontalRotation = 5.0f;
    float z = 100;
    public float x;
    public float y;
    Vector3 offset;
    Quaternion rotationEuler;
    private bool Rhit;
    private float h;
    private int MaxY = 80;
    private int MyLayerMask = 0;
    void Start()
    {
        MyLayerMask = (1 << LayerMask.NameToLayer("Wall")) + (1 << LayerMask.NameToLayer("Ground"));
    }
    void LateUpdate()
    {

        cameraRay();
        Near_to_player();
        // Early out if we don't have a target
        if (!target)
            return;
        if (target)
        {
            //if (Input.GetMouseButton(1))
            {
                float x1 = x + Input.GetAxis("Mouse X");
                x = Mathf.LerpAngle(x, x1, Time.deltaTime * sensitivity * z);
                float y1 = y - Input.GetAxis("Mouse Y");
                y = Mathf.LerpAngle(y, y1, Time.deltaTime * sensitivity * z);

                y = Mathf.Clamp(y, -MaxY, MaxY);
                /*transform.RotateAround(target.position, Vector3.up, x * horizontalRotation);
                if (transform.position.z < target.position.z)
                    transform.RotateAround(target.position, -Vector3.right, y * horizontalRotation);
                else
                    transform.RotateAround(target.position, Vector3.right, y * horizontalRotation);*/
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
        if (Physics.Raycast(target.position, transform.TransformDirection(-Vector3.forward), out hit, maxdistance, MyLayerMask))
        //Physics.SphereCast(target.position, 2, new Vector3(0, 0, 0), out hit, 1 << LayerMask.NameToLayer("Wall")))
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
    void Near_to_player()
    {
        float d = Vector3.Distance(target.position, transform.position);
        if (d < 1)
        { y = Mathf.Lerp(y, MaxY, z); }
    }

}
