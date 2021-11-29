using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHoriz : MonoBehaviour
{
    public Joystick joystick;
    public GameObject plaeyrr;
    public float speed= 10f;
    private void FixedUpdate()
    {
        plaeyrr.transform.Rotate( new Vector3(0, 1, 0).normalized * joystick.Horizontal * speed * Time.deltaTime);
    }

}
