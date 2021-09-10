using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecideButton : MonoBehaviour
{
    Game01Controller Controllercs;
    Button Decide;

    // Start is called before the first frame update
    void Awake()
    {
        Controllercs = GetComponent<Game01Controller>();
        Decide = Controllercs.DecideButton;

        Decide.GetComponent<Button>().onClick.AddListener(DecideClick);
    }

    private void DecideClick()
    {
        Controllercs.DecideClick();
    }
}
