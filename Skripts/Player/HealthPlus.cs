using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlus : MonoBehaviour
{
    public Image IconHealthPlus;
    public int value;

    public bool change;
    LifePlayer lifePlayer;
    private void Start()
    {
        lifePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayer>();
        GetComponentInChildren<Text>().text = "+ " + value;
    }
    private void Update()
    {
        if(change)
        {
            lifePlayer.HP += value;
            if (lifePlayer.HP > lifePlayer.playerFullHealth + lifePlayer.plusArmor)
                lifePlayer.HP = lifePlayer.playerFullHealth + lifePlayer.plusArmor;
            lifePlayer.checksHP = true;
            change = false;
            gameObject.SetActive(false);
        }
    }

    public void ButtonTake()
    {
        change = true;
    }
}
