using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonUpDownScreen : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float speedR = 5f;

    private Vector3 _position;

    private void Start()
    {
        _position = target.InverseTransformPoint(transform.position);
    }

    private void Update()
    {
        var currentPosition = target.TransformPoint(_position);
        transform.position = Vector3.Lerp(transform.position, currentPosition, speed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speedR * Time.deltaTime);
    }

    //---------------------------------------------BUTTON-----------------
    public GameObject findP;
    public Joystick joystick;
    public float speedJ = 1f;
    private float RotX;


    public void FixedUpdate()
    {
        RotX = findP.transform.rotation.x;

        if (RotX > -30 && RotX < 30)
        { findP.transform.Rotate(new Vector3(-1, 0, 0).normalized * joystick.Vertical * speedJ * Time.deltaTime); }

    }


}
