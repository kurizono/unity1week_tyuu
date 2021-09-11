using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    TitleController controllercs;

    [SerializeField]
    Button returnButton;
    [SerializeField]
    GameObject credit;

    Button[] creditButton;
    GameObject[] creditObj;

    private void Awake()
    {
        controllercs = GetComponent<TitleController>();

        returnButton = controllercs.return_Button02;
        credit = controllercs.credit;

        creditButton = new Button[] { returnButton };
        creditObj = new GameObject[] { credit };
    }

    public void Set()
    {

        ButtonAddListener();

        Change();
    }

    public void Delete()
    {
        for (int i = 0; i < creditButton.Length; i++)
        {
            creditButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < creditObj.Length; i++)
        {
            creditObj[i].SetActive(false);
        }
    }

    private void Change()
    {
        Delete();
        credit.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    private void ButtonAddListener()
    {
        returnButton.onClick.AddListener(ReturnButtonClick);
    }
    private void ButtonRemoveListener()
    {
        returnButton.onClick.RemoveListener(ReturnButtonClick);
    }

    private void ReturnButtonClick()
    {
        ButtonRemoveListener();
        controllercs.DefaultMode();
    }
}
