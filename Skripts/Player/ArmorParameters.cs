using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorParameters : MonoBehaviour
{
    public Image IconArmor;
    public int value;

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int oldValue = player.GetComponent<Armor>().ActiveArmorPrefab.GetComponent<ArmorParameters>().value;
        GetComponentInChildren<Text>().text = "+ " + value;
    }

    public GameObject replacePrefab;
    public void ButtonTake()
    {
        player.GetComponent<Armor>().ActiveArmorPrefab = replacePrefab;
        player.GetComponent<LifePlayer>().checks = true;
        gameObject.SetActive(false);
    }
}
