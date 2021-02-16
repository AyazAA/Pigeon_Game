using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCamera : MonoBehaviour
{
    public static bool on = true;
    private static bool isCreated = false;
    public static Camera mainCamera;
    public AudioSource music;

    private void Awake()
    {
        if (isCreated == false)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
            mainCamera = gameObject.GetComponent<Camera>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            music.mute = false;
        }
        else
        {
            music.mute = true;
        }
    }
}
