using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public KeyCode keyToPress = KeyCode.P;
    public string sceneToLoad = "MainScene 1st Person";
    public string sceneToLoad2 = "SecondScene 3rd Person";

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (SceneManager.GetActiveScene().name == "MainScene 1st Person")
            {
                SceneManager.LoadScene(sceneToLoad2);
            }
            else if (SceneManager.GetActiveScene().name == "SecondScene 3rd Person")
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
