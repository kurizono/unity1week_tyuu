using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    /// �{�^�����N���b�N�������̏���
    public void OnClick()
    {
        SceneManager.LoadScene("Game01");
    }
}