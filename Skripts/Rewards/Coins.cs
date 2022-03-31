using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public GameObject Icon;
    public int amount;

    private void Start()
    {
        GetComponentInChildren<Text>().text = "" + amount;
    }

    private void FixedUpdate()
    {
        if (Take && gameObject.transform.localScale.x > 0)
        {
            effect.MoveObject(gameObject, new Vector3 (-25, 10));
            effect.ScaleDownObject(gameObject, new Vector3(-0.07f, -0.07f));
        }
        if ((Take && gameObject.transform.localScale.x <= 0))
        {
            GetComponentInChildren<ParticleSystem>().Stop();
            gameObject.SetActive(false);
        }
    }


    bool Take;
    public GameObject buttonTake;
    public GameObject player;
    public void ButtonTake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CoinBase>().COINS += amount;
        buttonTake.SetActive(false);
        Take = true;
    }
}
