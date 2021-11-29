using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScen : MonoBehaviour
{
    float sec;
    void FixedUpdate()
    {
        sec = sec + Time.deltaTime;
        if (sec>3f)
        {

            SceneManager.LoadScene(1);
            print("загрузка 0 сцены");
        }
    }

}
