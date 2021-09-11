using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game01Controller : MonoBehaviour
{
    MedicineMaterial medicinecs;
    ButtonController buttoncs;
    Syringe syringcs;

    //継承する値
    public static int[] medicineInfo = new int[2];

    public Button LeftArrowButton, RightArrowButton, DecideButton;

    public GameObject Hope, Dispair, Brave, Sad;
    public GameObject Syringe00, Syringe01;

    public Text　Order, CatTalk;

    public int GameStage = 0;

    string[] orderStr = new string[2] { "ちゅうしゃするきもちをえらぶにゃ！", "ちゅうしゃきをえらぶにゃ！" };


    // Start is called before the first frame update
    void Start()
    {
        medicinecs = GetComponent<MedicineMaterial>();
        buttoncs = GetComponent<ButtonController>();
        syringcs = GetComponent<Syringe>();

        First();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && LeftArrowButton.gameObject.activeSelf)
        {
            LeftArrowClick();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RightArrowButton.gameObject.activeSelf)
        {
            RightArrowClick();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && DecideButton.gameObject.activeSelf)
        {
            DecideClick();
        }
    }


    //最初は希望
    void First()
    {
        ModeChange(GameStage);
    }

    //左矢印
    public void LeftArrowClick()
    {
        switch (GameStage)
        {
            case 0:
                Stage0();
                break;
            case 1:
                Stage1();
                break;
        }

        void Stage0()
        {
            medicinecs.nowMedicineMate--;

            buttoncs.RightArrowChange(true);
            if (medicinecs.nowMedicineMate == 0)
            {
                buttoncs.LeftArrowChange(false);
            }
            medicinecs.ChangeMaterial();
        }
        void Stage1()
        {
            syringcs.nowSyringMate--;

            buttoncs.RightArrowChange(true);
            if(syringcs.nowSyringMate == 0)
            {
                buttoncs.LeftArrowChange(false);
            }
            syringcs.ChangeSyringe();
            
        }
    }

    //右矢印
    public void RightArrowClick()
    {
        switch (GameStage)
        {
            case 0:
                Stage0();
                break;
            case 1:
                Stage1();
                break;
        }


        void Stage0()
        {
            medicinecs.nowMedicineMate++;

            buttoncs.LeftArrowChange(true);
            if (medicinecs.nowMedicineMate == MedicineMaterial.medicineMate.Count - 1)
            {
                buttoncs.RightArrowChange(false);
            }
            medicinecs.ChangeMaterial();
        }
        void Stage1()
        {
            syringcs.nowSyringMate++;

            buttoncs.LeftArrowChange(true);
            if (syringcs.nowSyringMate == Syringe.syringmate.Count - 1)
            {
                buttoncs.RightArrowChange(false);
            }
            syringcs.ChangeSyringe();
        }
    }

    //決定ボタン
    public void DecideClick()
    {
        GameStage++;
        ModeChange(GameStage);
    }

    public void ModeChange(int mode)
    {
        switch (mode)
        {
            case 0:
                buttoncs.First();
                medicinecs.First();
                syringcs.End();
                Order.text = orderStr[0];
                break;
            case 1:
                medicineInfo[0] = (int)medicinecs.nowMedicineMate;
                buttoncs.First();
                medicinecs.End();
                syringcs.First();
                Order.text = orderStr[1];
                break;
            case 2:
                medicineInfo[1] = (int)syringcs.nowSyringMate;
                SceneManager.LoadScene("Game03");
                break;
                
        }
    }
}
