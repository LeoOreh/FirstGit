using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionStar : MonoBehaviour
{
    public GameObject StarCnavas;
    public GameObject objectStarH;



    private void OnTriggerEnter(Collider other)
    {
      //  print("collider in star");

        StarCnavas.SetActive(true);
        objectStarH.SetActive(false);
    }




}
