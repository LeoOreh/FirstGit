using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAt : MonoBehaviour
{
     public GameObject who;
     public GameObject lookAt;

    void FixedUpdate()
    {
        who.transform.LookAt(lookAt.transform);
    }

}
