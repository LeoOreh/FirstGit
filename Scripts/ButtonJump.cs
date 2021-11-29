using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonJump : MonoBehaviour
{
    public Button buttonJump;

    public float Jump = 1;
    bool collisionin = true;


    void OnCollisionEnter(Collision other)
    {

        collisionin = true;
      //  print("collisionEnter");

    }


    public void ClickButton()
    {
        if (collisionin==true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump, 0));
            collisionin = false;
     //       print("ClickButton");
        }

    }


}
