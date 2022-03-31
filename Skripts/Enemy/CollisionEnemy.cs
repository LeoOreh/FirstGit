using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionEnemy : MonoBehaviour
{
    public GameObject REDBackground;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<FireEnemy>().enabled = true;
            gameObject.tag = "ENEMY";
            REDBackground.SetActive(true);
            redAppare = true;
        }
    }

    bool redAppare;
    private void FixedUpdate()
    {
        if(redAppare)
        {
            if (REDBackground.GetComponent<Image>().color.a < 1)
                effect.AppearImage(REDBackground.GetComponent<Image>(), 0.2f);
            else this.enabled = false;
        }
    }
}
