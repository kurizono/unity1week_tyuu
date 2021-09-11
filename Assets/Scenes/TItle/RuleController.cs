using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleController : MonoBehaviour
{
    TitleController controllercs;

    [SerializeField]
    Button nextButton, preButton, returnButton01, returnButton02;
    [SerializeField]
    GameObject rule01, rule02, rule03;

    private Button[] ruleButton;
    private GameObject[] ruleObj;
    [SerializeField]
    int rulenum = 0;

    private void Awake()
    {
        controllercs = GetComponent<TitleController>();

        nextButton = controllercs.next_Button;
        preButton = controllercs.pre_Button;
        returnButton01 = controllercs.return_Button01;
        returnButton02 = controllercs.return_Button02;

        rule01 = controllercs.rule01;
        rule02 = controllercs.rule02;
        rule03 = controllercs.rule03;


        ruleButton = new Button[4] { nextButton, preButton, returnButton01, returnButton02 };
        ruleObj = new GameObject[3] { rule01, rule02, rule03 };
    }

    public void Set()
    {
        rulenum = 0;

        ButtonAddListener();

        Change();
    }

    public void Delete()
    {
        for (int i = 0; i < ruleButton.Length; i++)
        {
            ruleButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ruleObj.Length; i++)
        {
            ruleObj[i].SetActive(false);
        }
    }

    public void Change()
    {
        Delete();
        switch (rulenum) {
            case 0:
                returnButton01.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
                rule01.SetActive(true);
                break;
            case 1:
                preButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
                rule02.SetActive(true);
                break;
            case 2:
                preButton.gameObject.SetActive(true);
                returnButton02.gameObject.SetActive(true);
                rule03.SetActive(true);
                break;
        }

    }

    private void ButtonAddListener()
    {
        nextButton.onClick.AddListener(NextButtonClick);
        preButton.onClick.AddListener(PreButtonClick);
        returnButton01.onClick.AddListener(ReturnButtonClick);
        returnButton02.onClick.AddListener(ReturnButtonClick);
    }
    private void ButtonRemoveListener()
    {
        nextButton.onClick.RemoveListener(NextButtonClick);
        preButton.onClick.RemoveListener(PreButtonClick);
        returnButton01.onClick.RemoveListener(ReturnButtonClick);
        returnButton02.onClick.RemoveListener(ReturnButtonClick);
    }

    private void NextButtonClick()
    {
        rulenum++;
        Change();
    }
    private void PreButtonClick()
    {
        rulenum--;
        Change();
    }

    private void ReturnButtonClick()
    {
        ButtonRemoveListener();
        controllercs.DefaultMode();
    }
}
