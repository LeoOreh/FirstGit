using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStarAll : MonoBehaviour
{
    public GameObject StarAllOpen;
    public Button buttonJump;
    bool activeStarAll;

    private void Update()
    {
        activeStarAll = StarAllOpen.activeInHierarchy;
    }
    public void ClickButton()
    {
        if (activeStarAll==false)
        {
            StarAllOpen.SetActive(true);
           // print("clikStarOpen");
        }
        if (activeStarAll == true)
        {
            StarAllOpen.SetActive(false);
           // print("clikStarClose");
        }
    }

}
