using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneParis : MonoBehaviour
{
    public int levelToLoad;
void OnMouseDown()
        {
        
            SceneManager.LoadScene(levelToLoad);
        print("clik");
        }
    }
