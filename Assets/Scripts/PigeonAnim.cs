using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonAnim : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            anim.SetTrigger("Poop");
        }
    }
}
