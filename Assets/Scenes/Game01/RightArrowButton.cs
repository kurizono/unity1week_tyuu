using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightArrowButton : MonoBehaviour
{
    Game01Controller Controllercs;
    Button RightArrow;

    // Start is called before the first frame update
    void Awake()
    {
        Controllercs = GetComponent<Game01Controller>();
        RightArrow = Controllercs.RightArrowButton;

        RightArrow.GetComponent<Button>().onClick.AddListener(RightArrowClick);
    }

    private void RightArrowClick()
    {
        Controllercs.RightArrowClick();
    }
}
