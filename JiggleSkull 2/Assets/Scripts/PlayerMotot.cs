using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotot : MonoBehaviour
{
    public Rigidbody rigid;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 CameraRotation = Vector3.zero;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    public void RotateCamera(Vector3 _cameraRotation)
    {
        CameraRotation = _cameraRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    void PerformMovement ()
    {
        if (velocity != Vector3.zero)
        {
            rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
        }
    }
    void PerformRotation()
    {
        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-CameraRotation);
        }
    }
}
