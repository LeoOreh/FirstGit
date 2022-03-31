using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public float playerFullHealth;
    public float playerFullHealthPlusArmor;
    public float HP;
    float _damage;
    public GameObject HealthPlayer;

    public int plusArmor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireEnemy"))
        {
            playerFullHealthPlusArmor = playerFullHealth + plusArmor;
            other.GetComponent<BoxCollider>().enabled = false;
            _damage = other.GetComponent<FireParameters>()._DAMAGE;
            if (HP >= 0) HP = HP - _damage;
            if (HP < 0) HP = 0;
            HealthPlayer.GetComponentInChildren<Text>().text = HP + " / " + playerFullHealthPlusArmor;
            HealthPlayer.GetComponentInChildren<Image>().fillAmount = (HP / playerFullHealthPlusArmor);

        }
    }

    float oldHealth;
    void check(float hp)
    {
        oldHealth = playerFullHealthPlusArmor;
        plusArmor = gameObject.GetComponent<Armor>().ActiveArmorPrefab.GetComponent<ArmorParameters>().value;
        HP = hp + plusArmor;
        if (HP > oldHealth + plusArmor)
            HP = oldHealth + plusArmor;
        CheckHP();
    }
    void CheckHP()
    {
        HealthPlayer.GetComponentInChildren<Text>().text = HP + " / " + (oldHealth + plusArmor);
        HealthPlayer.GetComponentInChildren<Image>().fillAmount = (HP / (oldHealth + plusArmor));
    }
    void Start()
    {
        playerFullHealthPlusArmor = playerFullHealth;
        check(playerFullHealth);
    }

    public bool checks;
    public bool checksHP;
    private void Update()
    {
        if (checks)
        {
            check(HP);
            checks = false;
        }
        if(checksHP)
        {
            CheckHP();
            checksHP = false;
        }
    }

}

