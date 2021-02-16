using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static string sceneNameBeforeSettings;
    public static List<GameObject> dontDestroyObjects = new List<GameObject>();
    

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void StartSettings()
    {
        sceneNameBeforeSettings = SceneManager.GetActiveScene().name;
        if(sceneNameBeforeSettings == "Game")
        {
            Time.timeScale = 0;
            Pause.PauseInGame = true;
            if (dontDestroyObjects.Count > 0)
            {
                Destroy(dontDestroyObjects[dontDestroyObjects.Count - 1]);
            }
            SceneManager.LoadScene("Settings");
            foreach (var item in dontDestroyObjects)
            {
                if (item != null)
                {
                    item.SetActive(false);
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Settings");
        }
    }

    public void Back()
    {
        switch (sceneNameBeforeSettings)
        {
            case "Start_Scene":
                SceneManager.LoadScene("Start_Scene");
                return ;
            case "Game":
                SceneManager.LoadScene("Game");
                foreach (var item in dontDestroyObjects)
                {
                    if (item != null)
                    {
                        item.SetActive(true);
                    }
                }
                Time.timeScale = 1;
                Pause.PauseInGame = false;
                return;
        }
    }
}
