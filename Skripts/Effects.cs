using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class effect
{

    //---------------------------------------------------------------------------------------------------
    static public void AppearText(Text[] text, float speed)
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].GetComponent<Text>().color += new Color(0, 0, 0, speed);
        }
    }
    //---------------------------------------------------------------------------------------------------
    static public void AppearImage(Image images, float speed)
    {
        images.GetComponent<Image>().color += new Color(0, 0, 0, speed);
    }
    //---------------------------------------------------------------------------------------------------
    static public void AppearImagesCildrens(Image[] imagesArray, float speed)
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            imagesArray[i].GetComponent<Image>().color += new Color(0, 0, 0, speed);
        }
    }

    //---------------------------------------------------------------------------------------------------
    static public void MoveImages(Image[] imagesArray, Vector3 vector3)
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            imagesArray[i].transform.position += vector3;

        }
    }
    //---------------------------------------------------------------------------------------------------
    static public void ScaleDownImages(Image imagesArray, float xy)
    {
        Vector3 _scale = imagesArray.transform.localScale;
        imagesArray.transform.localScale = new Vector3(_scale.x - xy, _scale.y - xy);
    }
    //---------------------------------------------------------------------------------------------------
    static public void CHECKINGForAlphaOfAllImages(Image[] imagesArray, GameObject EmptyImage)
    {
        int checkingForAlphaOfAllImages = 0;
        for (int k = 0; k < imagesArray.Length; k++)
        {
            if (imagesArray[k].GetComponent<Image>().color.a > 0.05f)
                checkingForAlphaOfAllImages++;
            else if (k == imagesArray.Length - 1 && checkingForAlphaOfAllImages <= 0)
            {
                EmptyImage.SetActive(false);
            }
        }
    }
    //---------------------------------------------------------------------------------------------------
    static public void MoveObject(GameObject gameObject, Vector3 vector3)
    {
            gameObject.transform.position += vector3;
    }
    //---------------------------------------------------------------------------------------------------
    static public void ScaleDownObject(GameObject gameObject, Vector3 vector3Scale)
    {
        gameObject.transform.localScale += vector3Scale;
    }

}
