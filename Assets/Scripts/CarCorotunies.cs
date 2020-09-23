using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCorotunies : MonoBehaviour
{
    public GameObject carPrehab;
    public int minTimeWait = 2;
    public int maxTimeWait = 4;

    void Start()
    {
        StartCoroutine("CreateCar");
    }
    
    void Update()
    {
        
    }

    IEnumerator CreateCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeWait,maxTimeWait));
            Instantiate(carPrehab);
        }
    }
}
