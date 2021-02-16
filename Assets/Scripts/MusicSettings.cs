using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    private void Start()
    {
        if(gameObject.GetComponent<Toggle>().name == "ToggleMusic")
        {
            if (SettingCamera.on == true)
            {
                gameObject.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                gameObject.GetComponent<Toggle>().isOn = false;
            }
        }
        else if (gameObject.GetComponent<Toggle>().name == "ToggleSound")
        {
            if (Hero.musicPlay == true)
            {
                gameObject.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                gameObject.GetComponent<Toggle>().isOn = false;
            }
        }
    }

    public void changeMusicStatus()
    {
        if(gameObject.GetComponent<Toggle>().isOn == true)
        {
            SettingCamera.on = true;
            gameObject.GetComponentInChildren<Text>().text = "Вкл музыка";
        }
        else
        {
            SettingCamera.on = false;
            gameObject.GetComponentInChildren<Text>().text = "Выкл музыка";
        }
    }

    public void changeSoundStatus()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            Hero.musicPlay = true;
            gameObject.GetComponentInChildren<Text>().text = "Вкл звуковые эффекты";
        }
        else
        {
            Hero.musicPlay = false;
            gameObject.GetComponentInChildren<Text>().text = "Выкл звуковые эффекты";
        }
    }
}
