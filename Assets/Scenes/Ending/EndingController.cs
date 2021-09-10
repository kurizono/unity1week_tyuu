using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    EndingText endtextcs;

    public Text endingText;
    public Button decideButton, restartButton, retryButton;
    public GameObject EndingPage00, EndingPage01, EndingPage02, EndingPage03, EndingPage10;
    public GameObject[] EndingPage;

    int endstage = 0;


    private void Awake()
    {
        endtextcs = GetComponent<EndingText>();
        EndingPage = new GameObject[4]
        {
            EndingPage00, EndingPage01, EndingPage02, EndingPage03
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        EndMode();

    }

    public void EndStageChange()
    {
        endstage++;
        EndMode();
    }
    public void EndMode()
    {
        endtextcs.TextChange(Game01Controller.medicineInfo[0], endstage);
        for (int i = 0; i < EndingPage.Length; i++)
        {
            EndingPage[i].SetActive(false);
        }
        switch (endstage)
        {
            case 0:
                decideButton.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(false); 
                retryButton.gameObject.SetActive(false);
                EndingPage[Game01Controller.medicineInfo[0]].SetActive(true); 
                EndingPage10.SetActive(false);
                break;
            case 1:
                decideButton.gameObject.SetActive(false);
                restartButton.gameObject.SetActive(true);
                retryButton.gameObject.SetActive(true);
                EndingPage10.SetActive(true);
                break;
        }
    }
}
