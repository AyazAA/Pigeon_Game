using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvasController : MonoBehaviour
{
    public static GameOverCanvasController Instance;

    void Awake()
    {
        Instance = this;
        if(Car.scoreGOText == null)
            Car.scoreGOText = GameObject.FindGameObjectWithTag("ScoreGO").GetComponent<Text>();
        gameObject.SetActive(false);
    }
}
