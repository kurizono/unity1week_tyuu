using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftArrowButton : MonoBehaviour
{
    Game01Controller Controllercs;
    Button LeftArrow;

    // Start is called before the first frame update
    void Start()
    {
        Controllercs = GetComponent<Game01Controller>();
        LeftArrow = Controllercs.LeftArrowButton;

        LeftArrow.GetComponent<Button>().onClick.AddListener(LeftArrowClick);
    }

    private void LeftArrowClick()
    {
        Controllercs.LeftArrowClick();
    }
    

}
