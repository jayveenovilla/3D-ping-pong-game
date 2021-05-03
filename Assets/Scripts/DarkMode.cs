using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMode : MonoBehaviour
{
    public bool darkMode;
    public Light worldLight;
    public Light ballLight;
    public Light paddleLight1;
    public Light paddleLight2;

    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();       //script attached to button DarkMode
        btn.onClick.AddListener(onClick);
        darkMode = false;
        darkOff();              //lights off on start of play test scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void darkOn()
    {
        if (worldLight.intensity == 1 && darkMode)
        {
            worldLight.intensity = 0;       //turn on global light when ball is launched
            ballLight.intensity = 1;        //turn of point light of ball when ball is launched
            paddleLight1.intensity = 1;     //turns on all the paddle lights
            paddleLight2.intensity = 4;
        }
    }

    public void darkOff()
    {
        if (worldLight.intensity == 0)
        {
            worldLight.intensity = 1;       //turn off global light when ball is stopped
            ballLight.intensity = 0;        //turn on point light of ball when ball is stopped
            paddleLight1.intensity = 0;     //turns off all the paddle lights
            paddleLight2.intensity = 0;
        }
    }

    public void onClick()
    {
        if (darkMode)
        {
            myButton.GetComponent<Image>().color = Color.white;          //changes color of button DarkMode on click
            darkMode = false;
            darkOff();
        }
        else
        {
            myButton.GetComponent<Image>().color = Color.gray;
            darkMode = true;
            darkOn();
        }
    }
}
