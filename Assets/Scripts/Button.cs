using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string sceneName = " ";

    public void ChangeScene() {
        Debug.Log("Pressed");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
