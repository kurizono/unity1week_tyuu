using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Syringe : MonoBehaviour
{
    Game01Controller controllercs;
    GameObject[] Syringes;
    GameObject SyringeSmall, SyringeBig;

    Text CatTalk;

    string[] cattalkst;
    string cattalkSmall = "‚¿‚Ü‚¿‚Ü‚¤‚Â‚¿‚ã‚¤‚µ‚á‚«‚É‚á\n‚±‚ê‚Å‚¤‚Â‚É‚áH";
    string cattalkBig = "‚½‚­‚³‚ñ‚¤‚Â‚¿‚ã‚¤‚µ‚á‚«‚É‚á\n‚±‚ê‚Å‚¤‚Â‚É‚áH";

    public enum syringmate
    {
        big,
        small,
        Count
    }
    public syringmate nowSyringMate;


    // Start is called before the first frame update
    void Awake()
    {
        //controllercs‚©‚ç’l‚ğæ‚é
        controllercs = GetComponent<Game01Controller>();

        SyringeSmall = controllercs.Syringe00;
        SyringeBig = controllercs.Syringe01;
        Syringes = new GameObject[(int)syringmate.Count];
        Syringes[(int)syringmate.big] = SyringeSmall;
        Syringes[(int)syringmate.small] = SyringeBig;

        CatTalk = controllercs.CatTalk;

        cattalkst = new string[(int)syringmate.Count];
        cattalkst[(int)syringmate.big] = cattalkBig;
        cattalkst[(int)syringmate.small] = cattalkSmall;

    }

    public void First()
    {
        End();
        nowSyringMate = 0;
        ChangeSyringe();
    }
    public void End()
    {
        for (int i = 0; i < Syringes.Length; i++)
        {
            Syringes[i].SetActive(false);
        }
    }

    public void ChangeSyringe()
    {
        for (int i = 0; i < Syringes.Length; i++)
        {
            Syringes[i].SetActive(false);
        }
        foreach (syringmate syringValue in Enum.GetValues(typeof(syringmate))) {
            if (nowSyringMate == syringValue)
            {
                Syringes[(int)syringValue].SetActive(true);
                CatTalk.text = cattalkst[(int)syringValue];
            }
        }
    }

}
