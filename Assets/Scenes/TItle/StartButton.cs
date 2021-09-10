using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        SceneManager.LoadScene("Game01");
    }
}