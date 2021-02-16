using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poo : MonoBehaviour
{
    void Start()
    {
        SceneLoader.dontDestroyObjects.Add(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Road")
        {
            Destroy(transform.gameObject);
            SceneLoader.dontDestroyObjects.Remove(transform.gameObject);
        }
    }
}
