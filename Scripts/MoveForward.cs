using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float Speed = 1;
    public float SpeedR = 100;
    public float Jump = 1;
    bool collisionin = true;

  
    void OnCollisionEnter(Collision other)
    {

            collisionin = true;
           // print("collisionEnter");

    }
    private void OnCollisionStay(Collision collision)
    {
        collisionin = true;
    }

    void FixedUpdate()
    {
        /*if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward.normalized * -Speed * Time.deltaTime);
        }*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward.normalized * Speed * Time.deltaTime);
            //______________________ANIMATOR____________________________________________________________________
            gameObject.GetComponent<Animator>().SetBool("WalkOn",true);


        }
          else  gameObject.GetComponent<Animator>().SetBool("WalkOn", false);
        //__________________________ANIMATOR END________________________________________________________________



        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0).normalized  * SpeedR * Time.deltaTime);
            //______________________ANIMATOR____________________________________________________________________
            gameObject.GetComponent<Animator>().SetBool("InRight", true);


        }
        else gameObject.GetComponent<Animator>().SetBool("InRight", false);
        //__________________________ANIMATOR END________________________________________________________________



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0).normalized * SpeedR * Time.deltaTime);
            //______________________ANIMATOR____________________________________________________________________
            gameObject.GetComponent<Animator>().SetBool("InLeft", true);


        }
        else gameObject.GetComponent<Animator>().SetBool("InLeft", false);
        //__________________________ANIMATOR END________________________________________________________________



        if (Input.GetKey(KeyCode.Space)&& collisionin == true)
        {

            GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump, 0));
                collisionin = false;
              //  print("collisionoFFFFFF222222");
        }
    }
}
