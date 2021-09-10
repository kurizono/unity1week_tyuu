using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Game01Controller controllercs;

    Button LeftArrowButton, RightArrowButton, DecideButton;

    // Start is called before the first frame update
    void Awake()
    {
        controllercs = GetComponent<Game01Controller>();
        LeftArrowButton = controllercs.LeftArrowButton;
        RightArrowButton = controllercs.RightArrowButton;
        DecideButton = controllercs.DecideButton;
    }

    public void First()
    {
        LeftArrowButton.gameObject.SetActive(false);
        RightArrowButton.gameObject.SetActive(true);
        DecideButton.gameObject.SetActive(true);
    }

    public void LeftArrowChange(bool on)
    {
        if (on)
        {
            LeftArrowButton.gameObject.SetActive(true);
        }
        else
        {
            LeftArrowButton.gameObject.SetActive(false);
        }
    }

    public void RightArrowChange(bool on)
    {
        if (on)
        {
            RightArrowButton.gameObject.SetActive(true);
        }
        else
        {
            RightArrowButton.gameObject.SetActive(false);
        }
    }

    public void NextStage()
    {

    }

}
