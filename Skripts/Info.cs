using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject icon;
    public GameObject infoWindow;
    public GameObject health;
    Image[] images;
    Text[] texts;
    Image[] imagesHealth;
    Text[] textsHealth;
    private void Start()
    {
        images =  infoWindow.GetComponentsInChildren<Image>();
        texts = infoWindow.GetComponentsInChildren<Text>();
        imagesHealth = health.GetComponentsInChildren<Image>();
        textsHealth = health.GetComponentsInChildren<Text>();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].GetComponent<Image>().color -= new Color(0, 0, 0, 1);
        }
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].GetComponent<Text>().color -= new Color(0, 0, 0, 1);
        }
    }

    private void FixedUpdate()
    {
        if (buttonEffects)
        {
            effect.AppearImagesCildrens(imagesHealth, -0.3f);
            effect.AppearText(textsHealth, -0.3f);
            effect.AppearImagesCildrens(images, 0.3f);
            effect.AppearText(texts, 0.3f);
            effect.AppearImage(infoWindow.GetComponent<Image>(), -0.1f);
            if (infoWindow.GetComponent<Image>().color.a > 0.7f)
                infoWindow.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);
            if (images[1].GetComponent<Image>().color.a>=1)
            {
                buttonEffects = false;
            }
        }
        if (buttonClose)
        {
            effect.AppearImagesCildrens(imagesHealth, 0.3f);
            effect.AppearText(textsHealth, 0.3f);
            effect.AppearImagesCildrens(images, -0.3f);
            infoWindow.GetComponent<Image>().color += new Color(0, 0, 0, 0.1f);
            effect.AppearText(texts, -0.3f);
            if (images[1].GetComponent<Image>().color.a <= 0)
            {
               buttonClose = false;
                infoWindow.SetActive(false);
            }
        }
    }

    bool buttonEffects;
    public void ButtonInfo()
    {
        icon.SetActive(false);
     //   health.SetActive(false);
        infoWindow.SetActive(true);
        buttonEffects = true;
        BuildInfo();
    }

    public GameObject weaponInfo;
    public GameObject armorInfo;
    public GameObject healthInfo;
    public GameObject coinsInfo;
    public GameObject player;
    void BuildInfo()
    {
        weaponInfo.GetComponent<Image>().sprite = player.GetComponent<Weapon>().ActiveWeaponPrefab.GetComponent<WeaponParameters>().IconWeapon.sprite;
        weaponInfo.GetComponentInChildren<Text>().text ="" +  player.GetComponent<Weapon>().damageBase;

        armorInfo.GetComponent<Image>().sprite = player.GetComponent<Armor>().ActiveArmorPrefab.GetComponent<ArmorParameters>().IconArmor.sprite;
        armorInfo.GetComponentInChildren<Text>().text = "" + player.GetComponent<Armor>().ActiveArmorPrefab.GetComponent<ArmorParameters>().value;

        healthInfo.GetComponentInChildren<Text>().text = "" + player.GetComponent<LifePlayer>().playerFullHealthPlusArmor;
        coinsInfo.GetComponentInChildren<Text>().text = "" + player.GetComponent<CoinBase>().COINS;

    }

    bool buttonClose;
    public void ButtonInfoClose()
    {
        icon.SetActive(true);
       // health.SetActive(true);
        buttonClose = true;
    }
}
