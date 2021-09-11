using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    TitleController controllercs;

    [SerializeField]
    Button nextButton, preButton, returnButton01, returnButton02;
    [SerializeField]
    GameObject story01, story02, story03;

    private Button[] storyButton;
    private GameObject[] storyObj;

    [SerializeField]
    int storynum = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        controllercs = GetComponent<TitleController>();

        nextButton = controllercs.next_Button;
        preButton = controllercs.pre_Button;
        returnButton01 = controllercs.return_Button01;
        returnButton02 = controllercs.return_Button02;

        story01 = controllercs.story01;
        story02 = controllercs.story02;
        story03 = controllercs.story03;


        storyButton = new Button[4] { nextButton, preButton, returnButton01, returnButton02 };
        storyObj = new GameObject[3] { story01, story02, story03 };
    }
    public void Set()
    {
        storynum = 0;

        ButtonAddListener();

        Change();
    }

    public void Delete()
    {
        for (int i = 0; i < storyButton.Length; i++)
        {
            storyButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < storyObj.Length; i++)
        {
            storyObj[i].SetActive(false);
        }
    }

    public void Change()
    {
        Delete();
        switch (storynum)
        {
            case 0:
                returnButton01.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
                story01.SetActive(true);
                break;
            case 1:
                preButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
                story02.SetActive(true);
                break;
            case 2:
                preButton.gameObject.SetActive(true);
                returnButton02.gameObject.SetActive(true);
                story03.SetActive(true);
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
        storynum++;
        Change();
    }
    private void PreButtonClick()
    {
        storynum--;
        Change();
    }

    private void ReturnButtonClick()
    {
        ButtonRemoveListener();
        controllercs.DefaultMode();
    }
}
