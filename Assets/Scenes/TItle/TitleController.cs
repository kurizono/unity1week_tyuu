using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    StoryController storycs;
    RuleController rulecs;
    CreditController creditcs;
    SettingController settingcs;

    public Button gameStart_Button, story_Button,  rule_Button, setting_Button, credit_Button, next_Button, pre_Button, return_Button01, return_Button02;
    public GameObject rule01, rule02, rule03, story01, story02, story03, credit, setting, Title;

    private GameObject[] allObj;
    private GameObject[] defaultObj;

    private void Awake()
    {
        storycs = GetComponent<StoryController>();
        rulecs = GetComponent<RuleController>();
        creditcs = GetComponent<CreditController>();
        settingcs = GetComponent<SettingController>();

        allObj = new GameObject[]
        {
             gameStart_Button.gameObject, story_Button.gameObject, rule_Button.gameObject, setting_Button.gameObject, credit_Button.gameObject,
             next_Button.gameObject, pre_Button.gameObject,return_Button01.gameObject, return_Button02.gameObject,

             rule01, rule02, rule03, story01, story02, story03, credit, setting, Title
        };

        defaultObj = new GameObject[6]
        {
            gameStart_Button.gameObject, story_Button.gameObject, rule_Button.gameObject, setting_Button.gameObject, credit_Button.gameObject, Title
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        DefaultMode();
    }

    public void AllDelete()
    {
        for(int i = 0; i < allObj.Length; i++)
        {
            allObj[i].SetActive(false);
        }
    }

    public void DefaultMode()
    {
        AllDelete();
        for (int i = 0; i < defaultObj.Length; i++)
        {
            defaultObj[i].SetActive(true);
        }
    }

    public void StoryMode()
    {
        AllDelete();
        storycs.Set();
    }

    public void RuleMode()
    {
        AllDelete();
        rulecs.Set();
    }

    public void CreditMode()
    {
        AllDelete();
        creditcs.Set();
    }

    public void SettingMode()
    {
        AllDelete();
        settingcs.Set();
    }

}
