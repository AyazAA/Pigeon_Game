using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public int speed;
    public float distance;
    public float delta;
    public Transform fon;

    void Update()
    {
        MoveBG();
    }
    
    private void MoveBG()
    {
        fon.Translate(Vector3.left * speed * Time.deltaTime);
        if (fon.position.x < distance)
        {
            fon.position += new Vector3(delta, 0, 0);
        }
    }
}