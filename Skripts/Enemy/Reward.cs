using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public GameObject rewardCanvas;
    GameObject[] imageSlot;
    public GameObject[] resSlot;
    public int[] changeResSlot;
    
    private void Start()
    {
        imageSlot = rewardCanvas.GetComponent<RewardLink>().slot4;

        for (int i = 0; i < resSlot.Length; i++)
        {

            if (resSlot[i].tag == "ResCoin")
            {
                ResCoin(i);
            }
            if (resSlot[i].tag == "ResHealthPlus")
            {
                ResHealthPlus(i);
            }
            if (resSlot[i].tag == "ResArmor")
            {
                ResArmor(i);
            }
            if (resSlot[i].tag == "FirePlayer")
            {
                ResWeapon(i);
            }
        }
    }

    void ResCoin(int index)
    {
        Instantiate(resSlot[index], imageSlot[index].transform);
        imageSlot[index].GetComponentInChildren<Coins>().amount = changeResSlot[index];

    }
    void ResHealthPlus(int index)
    {
        Instantiate(resSlot[index], imageSlot[index].transform);
        imageSlot[index].GetComponentInChildren<HealthPlus>().value = changeResSlot[index];
    }
    void ResArmor(int index)
    {
        GameObject z=  Instantiate(resSlot[index], imageSlot[index].transform);
        z.GetComponentInChildren<ArmorParameters>().replacePrefab = resSlot[index].gameObject;
        //changeResSlot[index] = imageSlot[index].GetComponentInChildren<ArmorParameters>().value;
    }
      void ResWeapon(int index)
    {
        Instantiate(resSlot[index].GetComponent<WeaponParameters>().weaponInfo, imageSlot[index].transform).SetActive(true);
    }
}
