using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardCollision : MonoBehaviour
{
    public GameObject rewardCanvas;
    public GameObject rewardNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rewardCanvas.SetActive(true);
            rewardNumber.SetActive(true);
            boolingAnimAppearReward = true;

        }
    }
    private void FixedUpdate()
    {
        AnimationAppearReward();
        AnimationCloseReward();
    }



    bool boolingAnimAppearReward;
    float timeForAnimation = 0.015f;
    public GameObject ForAnimBackGround;
    Image[] imagesFromReward;
    void AnimationAppearReward()
    {
        if (boolingAnimAppearReward)
        {
            if (imagesFromReward == null)
            {
                imagesFromReward = rewardNumber.GetComponentsInChildren<Image>();
                effect.AppearImagesCildrens(imagesFromReward, -1);
            }

            timeForAnimation += 0.05f;
            if (timeForAnimation >= 1)
            {
                timeForAnimation = 1;
                boolingAnimAppearReward = false;
            }

            rewardNumber.transform.localScale = new Vector3(timeForAnimation, timeForAnimation, 1);

            effect.AppearImagesCildrens(imagesFromReward, 0.05f);

            ForAnimBackGround.GetComponentInParent<Image>().fillAmount = timeForAnimation;
            if (timeForAnimation < 0.7f)
                ForAnimBackGround.GetComponentInParent<Image>().color = new Color(1, 0, 0, timeForAnimation);
        }
    }



    static bool AnimCloseReward;
    void AnimationCloseReward()
    {
        if (AnimCloseReward)
        {

            if (rewardNumber.GetComponentInChildren<Image>().color.a > 0)
            {
                effect.AppearImagesCildrens(imagesFromReward, -0.1f);
                effect.AppearImage(ForAnimBackGround.GetComponent<Image>(), -0.1f);
            }
            else
            {
                rewardNumber.SetActive(false);
                rewardCanvas.SetActive(false);
                AnimCloseReward = false;
                Destroy(gameObject);
                Destroy(rewardCanvas);
            }
        }
    }
    public void ButtonCloseReward()
    {
        imagesFromReward = rewardNumber.GetComponentsInChildren<Image>();
        RewardCollision.AnimCloseReward = true;
    }
}
