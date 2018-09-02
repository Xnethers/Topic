using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform mainCameraT;
    private Transform CameraD;
    public CharacterController _player;
    public float speed = 3.0f;


    // Use this for initialization
    void Start()
    {
        mainCameraT = Camera.main.gameObject.transform;
        GameObject CameraD_object = new GameObject();
        CameraD_object.transform.parent = transform;
        CameraD_object.transform.localPosition = Vector3.zero;
        CameraD_object.name = "Direction";
        CameraD = CameraD_object.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCameraT)
        {
            CameraD.eulerAngles = new Vector3(0, mainCameraT.eulerAngles.y, 0);
        }
        float Vertical = Input.GetAxis("Vertical");
        float v = Mathf.Clamp(Vertical, -10f, 10f);
        float Horizontal = Input.GetAxis("Horizontal");
        float h = Mathf.Clamp(Horizontal, -10f, 10f);
        _player.Move(CameraD.forward * v * Time.deltaTime * speed);
        _player.Move(CameraD.right * h * Time.deltaTime * speed);
        if (Input.GetMouseButton(1))
        {
            transform.eulerAngles = CameraD.eulerAngles;
        }
        if (v > 0)
        {
            SmoothRotation(CameraD.eulerAngles.y);
        }
        else if (v < 0)
        { SmoothRotation(CameraD.eulerAngles.y); }

        if (h > 0)
        { SmoothRotation(CameraD.eulerAngles.y + 90); }
        else if (h < 0)
        { SmoothRotation(CameraD.eulerAngles.y - 90); }
    }

    public void SmoothRotation(float a)
    {
        float y = 0.0f;
        float rotateSpeed = 0.05f;
        transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, a, ref y, rotateSpeed), 0);
    }
}
