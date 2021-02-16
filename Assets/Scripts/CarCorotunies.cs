using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCorotunies : MonoBehaviour
{
    public GameObject[] carPrehabs = new GameObject[5];
    private int minTimeWait = 2;
    private int maxTimeWait = 4;

    void Start()
    {
        StartCoroutine(CreateCar());
    }

    IEnumerator CreateCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeWait,maxTimeWait));
            DontDestroyOnLoad(Instantiate(carPrehabs[Random.Range(0, carPrehabs.Length)]));
        }
    }
}
