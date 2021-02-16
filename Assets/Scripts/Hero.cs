using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static bool musicPlay = true;
    public static int score = 0;
    private float volume = 1f;
    private float fireTime;
    private float fireNext = 0.5f;
    public GameObject poo;
    public Transform poopPoint;
    public AudioClip poopSound;

    private void Start()
    {
        InitialCarTexts();
    }


    void Update()
    {
        if (!Pause.PauseInGame)
        {
            Poop();
        }
    }

    void Poop()
    {
        if (Input.touchCount > 0)
        {
            if (Time.time > fireTime)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    DontDestroyOnLoad(Instantiate(poo, poopPoint.position, poopPoint.rotation));
                    if (musicPlay)
                    {
                        AudioSource.PlayClipAtPoint(poopSound, new Vector3(0, 1.5f, -1f), volume);
                    }
                }
                fireTime = Time.time + fireNext;
            }
        }
        //if (Input.GetMouseButtonDown(0))//для отладки
        //{
        //    DontDestroyOnLoad(Instantiate(poo, poopPoint.position, poopPoint.rotation));
        //    if (musicPlay)
        //    {
        //        AudioSource.PlayClipAtPoint(poopSound, new Vector3(0, 1.5f, -1f), volume);
        //    }
        //}
    }
    
    private void InitialCarTexts()
    {
        if (Car.scoreText == null)
        {
            Car.scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            Car.textBeforeScore = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            Car.scoreText.text = Hero.score.ToString();
            if (Hero.score > PlayerPrefs.GetInt("BestScore"))
            {
                Car.textBeforeScore.text = "Новый рекорд: ";
            }
            else
            {
                Car.textBeforeScore.text = "Счёт: ";
            }
        }
    }
}
