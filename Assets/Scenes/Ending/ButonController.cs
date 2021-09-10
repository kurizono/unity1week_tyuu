using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButonController : MonoBehaviour
{
    EndingController controllercs;

    private Button decideButton, restartButton, retryButton;

    private void Awake()
    {
        controllercs = GetComponent<EndingController>();
        decideButton = controllercs.decideButton;
        restartButton = controllercs.restartButton;
        retryButton = controllercs.retryButton;

        decideButton.GetComponent<Button>().onClick.AddListener(DecideClick);
        restartButton.GetComponent<Button>().onClick.AddListener(RestartClick);
        retryButton.GetComponent<Button>().onClick.AddListener(RetryClick);
    }

    private void DecideClick()
    {
        controllercs.EndStageChange();
    }
    private void RestartClick()
    {
        SceneManager.LoadScene("Title");
    }
    private void RetryClick()
    {
        SceneManager.LoadScene("Game03");
    }

}
