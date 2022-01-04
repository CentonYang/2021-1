using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string SceneName;
    public void ChangeScene()
    {
        GameManager.SceneToChange(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
