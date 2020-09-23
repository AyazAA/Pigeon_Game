using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static int score = 0;
    public Text number;
    public GameObject poo;
    public Transform poopPoint;
    private float fireTime;
    private float fireNext = 0.5f;
    public AudioClip poopSound;
    
    void Update()
    {
        Poop();
        number.text = score.ToString();
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
                    Instantiate(poo, poopPoint.position, poopPoint.rotation);
                    AudioSource.PlayClipAtPoint(poopSound, new Vector3(0, 1.5f, -1f),1f);
                }

                fireTime = Time.time + fireNext;
            }
        }
    }
}
