using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public  static bool PauseInGame = false;

    public void PauseGame()
    {
        if (!PauseInGame)
        {
            Time.timeScale = 0;
            PauseInGame = true;
            Destroy(SceneLoader.dontDestroyObjects[SceneLoader.dontDestroyObjects.Count - 1]);
        }
        else
        {
            PauseInGame = false;
            Time.timeScale = 1;
        }
    }
}
