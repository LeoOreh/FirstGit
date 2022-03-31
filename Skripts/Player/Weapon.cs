using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject ActiveWeaponPrefab;
    public int damageBase;
    private void Start()
    {
        damageBase = ActiveWeaponPrefab.GetComponent<WeaponParameters>().DAMAGE;
    }
}
