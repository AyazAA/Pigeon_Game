using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Threading;

public class Car : MonoBehaviour
{
    public int max;
    public int min;
    private int speed;
    private float volume = 1f;
    private bool hit = false;
    private const float gameOverPosX = -3.5f;
    private const float destroyPosX = -4.5f;
    public AudioClip hitSound;
    public AudioClip gameOverSound;
    private Transform poo;
    public static bool isRecord = false;
    public static Text scoreText;
    public static Text textBeforeScore;
    public static Text scoreGOText;



    private void Start()
    {
        speed = Random.Range(min, max);
        SceneLoader.dontDestroyObjects.Add(this.gameObject);
        isRecord = false;
        StartCoroutine(GameOver());
        StartCoroutine(DestroyCarAndPoo());
    }

    void Update()
    {
        MoveCar();
        MovePoo();
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private IEnumerator GameOver()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (transform.position.x < gameOverPosX && !hit)
            {
                Destroy(transform.gameObject);
                if (Hero.score > PlayerPrefs.GetInt("BestScore"))
                {
                    PlayerPrefs.SetInt("BestScore", Hero.score);
                    isRecord = true;
                    scoreGOText.text = $"Новый рекорд: {Hero.score}";
                }
                else
                    scoreGOText.text = $"Счёт: {Hero.score}";

                if (SceneLoader.dontDestroyObjects != null)
                {
                    foreach (var item in SceneLoader.dontDestroyObjects)
                    {
                        Destroy(item);
                    }
                }
                Time.timeScale = 0;
                Pause.PauseInGame = true;
                Hero.score = 0;
                GameCanvasController.Instance.gameObject.SetActive(false);
                GameOverCanvasController.Instance.gameObject.SetActive(true);
                AudioSource.PlayClipAtPoint(gameOverSound, new Vector3(0, 1.5f, -1f), volume);
            }
        }
        
    }

    private IEnumerator DestroyCarAndPoo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (transform.position.x < destroyPosX)
            {
                Destroy(transform.gameObject);
                SceneLoader.dontDestroyObjects.Remove(transform.gameObject);
                if (poo != null)
                {
                    Destroy(poo.gameObject);
                    SceneLoader.dontDestroyObjects.Remove(poo.gameObject);
                }
            }
        }
    }

    private void MovePoo()
    {
        if (poo != null)
        {
            poo.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Poo")
        {
            if (Hero.musicPlay && (poo == null))
            {
                AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 1.5f, -1f), volume);
            }
            hit = true;
            if(poo == null)
            {
                Hero.score++;
                if (Hero.score > PlayerPrefs.GetInt("BestScore"))
                {
                    textBeforeScore.text = "Новый рекорд: ";
                }
                scoreText.text = Hero.score.ToString();
            }
            poo = collision.transform;
            poo.localScale = new Vector3(0.3f, 0.15f, 0.6f);
        }
    }
}
