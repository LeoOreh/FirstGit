using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControll : MonoBehaviour
{
    public Joystick joystick;

    public float speed;
    public float speedR;

    private void FixedUpdate()
    {

        transform.Rotate(new Vector3(0, 1, 0).normalized * joystick.Horizontal * speedR * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, 1) * joystick.Vertical * speed * Time.deltaTime);

    }

}
