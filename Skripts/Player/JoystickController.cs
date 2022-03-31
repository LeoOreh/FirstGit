using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{

    public float _SpeedJ = 1;
    public Joystick _joystick;


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(_joystick.Horizontal * _SpeedJ, 0, _joystick.Vertical * _SpeedJ);
        if ((_joystick.Horizontal != 0 || _joystick.Vertical != 0))
        {
            transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
            this.GetComponent<Animator>().SetBool("walk", true);
        }
        else this.GetComponent<Animator>().SetBool("walk", false);

    }
}
