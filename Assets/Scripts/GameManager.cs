using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class GameManager
{
    static public int Score;
    static public int MaxScore = 10;

    static public void SceneToChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
