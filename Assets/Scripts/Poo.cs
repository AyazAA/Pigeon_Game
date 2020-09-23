using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//разобраться в чем разница в интер OnCollisionEnter2D,OnTriggerEnter2D
    {
        if (collision.transform.tag == "Road")
        {
            Destroy(transform.gameObject);
        }
    }
}
