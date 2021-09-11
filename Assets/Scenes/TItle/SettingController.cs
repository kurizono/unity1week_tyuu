using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    TitleController controllercs;
    
    MusicBox musicboxcs;

    public Button changeButton;
    Button returnButton;

    public Slider BGM;
    public static Slider BGMsoundvolume;
    public Text BGMValumeText, BGMNameText;

    [SerializeField]
    GameObject setting;

    int maxvolume = 100;
    int minvolume = 0;

    // Start is called before the first frame update
    void Awake()
    {
        BGMsoundvolume = BGM;
        controllercs = GetComponent<TitleController>();
        returnButton = controllercs.return_Button02;

        setting = controllercs.setting;

        BGMsoundvolume.maxValue = maxvolume;
        BGMsoundvolume.minValue = minvolume;
        BGMValumeText.text = BGMsoundvolume.value.ToString();
    }

    private void Start()
    {
        GameObject musicbox = GameObject.FindGameObjectWithTag("MusicBox");
        musicboxcs = musicbox.GetComponent<MusicBox>();
        VolumeChange();
        BGMNameText.text = musicboxcs.BGMMusicChake();
    }


    public void Set()
    {
        setting.SetActive(true);
        returnButton.gameObject.SetActive(true);
        ButtonAddListener();
    }


    private void ButtonAddListener()
    {
        returnButton.onClick.AddListener(ReturnButtonClick);
        changeButton.onClick.AddListener(ChangeButtonClick);
    }
    private void ButtonRemoveListener()
    {
        returnButton.onClick.RemoveListener(ReturnButtonClick);
        changeButton.onClick.RemoveListener(ChangeButtonClick);
    }

    private void ChangeButtonClick()
    {
        BGMNameText.text = musicboxcs.BGMMusicChange();
    }
    private void ReturnButtonClick()
    {
        ButtonRemoveListener();
        controllercs.DefaultMode();
    }

    public void VolumeChange()
    {
        BGMValumeText.text = BGMsoundvolume.value.ToString();
        musicboxcs.BGMVolumeChange();
    }

}
