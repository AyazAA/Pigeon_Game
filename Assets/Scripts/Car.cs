using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public int max;
    public int min;
    private int speed;
    public AudioClip hitSound;
    private bool hit = false;
    private Transform poo;
    public Text score;

    private void Start()
    {
        speed = Random.Range(min, max);
    }

    void Update()
    {
        MoveCar();
        MovePoo();
        GameOver();
        DestroyCarAndPoo();
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void GameOver()
    {
        if (transform.position.x < -0.7f && !hit)
        {
            Debug.Log("GameOver!");
            Destroy(transform.gameObject);
            score.text = "Score: " + Hero.score;
            Hero.score = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void DestroyCarAndPoo()
    {
        if (transform.position.x < -1.7f)
        {
            Destroy(transform.gameObject);
            if (poo != null)
            {
                Destroy(poo.gameObject);
            }
        }
    }

    private void MovePoo()
    {
        if (hit && poo != null)
        {
            poo.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Poo")
        {
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 1.5f, -1f), 1f);
            hit = true;
            poo = collision.transform;
            Hero.score++;
        }
    }
}
