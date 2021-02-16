using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    public static GameCanvasController Instance;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(true);
    }
}
