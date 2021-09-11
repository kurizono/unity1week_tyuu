using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleButton : MonoBehaviour
{
    TitleController controllercs;

    private void Awake()
    {
        GameObject controllerobj = GameObject.FindGameObjectWithTag("GameController");
        controllercs = controllerobj.GetComponent<TitleController>();
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        controllercs.RuleMode();
    }
}
