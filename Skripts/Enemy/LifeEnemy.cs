using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeEnemy : MonoBehaviour
{
    public float HPmax = 60;
    public float HP;

    void Start()
    {
        HP = HPmax;
        GetComponentInChildren<Text>().text = HP + " / " + HPmax;
    }

    public int damage;
    bool end;
    public GameObject rewardForClone;
    public GameObject revards;
    public GameObject rewardPrefab;
    GameObject NewRewards;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("FirePlayer"))
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().ActiveWeaponPrefab.GetComponent<WeaponParameters>().DAMAGE;
            if (HP > 0)
                HP = HP - damage;
            if (HP <= 0)
            {
                gameObject.GetComponent<Reward>().enabled = true;
                GetComponent<FireEnemy>().enabled = false;
                HP = 0;
                end = true;
                GameObject Reward = Instantiate(rewardForClone);
                NewRewards = Instantiate(rewardPrefab, revards.transform);
                Reward.GetComponent<RewardCollision>().rewardCanvas = NewRewards;
                Reward.GetComponent<RewardCollision>().rewardNumber = NewRewards.GetComponent<RewardLink>().rewardNamber;
                Reward.GetComponent<RewardCollision>().ForAnimBackGround = NewRewards.GetComponent<RewardLink>().Background;
                GetComponent<Reward>().rewardCanvas = NewRewards;
                Reward.transform.position = gameObject.transform.position;
                Reward.SetActive(true);
                Reward.transform.LookAt(GameObject.FindGameObjectWithTag("Camera").transform);
                GetComponent<SphereCollider>().enabled = false;
            }
             GetComponentInChildren<Text>().text = HP + " / " + HPmax;
        }
    }
    public GameObject ps;
    public GameObject bodyMaterial;
    public GameObject REDBackground;
    private void FixedUpdate()
    {
        if (end)
        {
            effect.AppearText(gameObject.GetComponentsInChildren<Text>(), -0.2f);
            effect.AppearImagesCildrens(gameObject.GetComponentsInChildren<Image>(), -0.2f);
            Material _material = bodyMaterial.GetComponent<Renderer>().material;
            Color a = _material.color;
            Color b = new Color(1, 1, 1, 0);
            _material.color = Color.Lerp(a, b, 0.15f);
            effect.AppearImage(REDBackground.GetComponent<Image>(), -0.2f);
            if (ps != null)
            {
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play(true);
                ps = null;
            }

            if (_material.color.a <= 0.01f)
            {
                //GameObject reward = Instantiate(_reward);
                //reward.transform.position = gameObject.transform.position;
                //reward.SetActive(true);
                REDBackground.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
