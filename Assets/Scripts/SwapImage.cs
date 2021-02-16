using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    public Sprite pic1;
    public Sprite pic2;
    private Image im;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
        im.sprite = pic1;
    }
    
    public void SwapImages()
    {
        if(im.sprite == pic1)
        {
            im.sprite = pic2;
        }
        else if(im.sprite == pic2)
        {
            im.sprite = pic1;
        }
    }
}
