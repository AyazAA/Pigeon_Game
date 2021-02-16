using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCanvas : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = SettingCamera.mainCamera;
    }
}
