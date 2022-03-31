using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReward : MonoBehaviour
{
    public GameObject basePrefab;
    private void Start()
    {
        GetComponentInChildren<Text>().text = "+ " + basePrefab.GetComponent<WeaponParameters>().DAMAGE;
    }
    public void ButtonTake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().ActiveWeaponPrefab = basePrefab;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().damageBase += basePrefab.GetComponent<WeaponParameters>().DAMAGE;
        gameObject.SetActive(false);
    }
}
