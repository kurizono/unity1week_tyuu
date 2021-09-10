using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicineMaterial : MonoBehaviour
{
    Game01Controller controllercs;

    GameObject[] Mate;
    GameObject Hope, Dispair, Brave, Sad;

    Text CatTalk;

    string[] cattalkst;
    string cattalkHope = "�ӂ��邫�����ɂ�"+ "\n" +"��������ɂ�H";
    string cattalkDispair = "�������Ȃ��Ȃ邫�����ɂ�" + "\n" + "��������ɂ�H";
    string cattalkBrave = "�͂₭�Ȃ邫�����ɂ�" + "\n" + "��������ɂ�H";
    string cattalkSad = "�����������邫�����ɂ�" + "\n" + "��������ɂ�H";

    public enum medicineMate
    {
        hope,
        dispair,
        brave,
        sad,
        Count
    }
    public medicineMate nowMedicineMate;

    public void Awake()
    {
        //controllercs����l�����
        controllercs = GetComponent<Game01Controller>();

        Hope = controllercs.Hope;
        Dispair = controllercs.Dispair;
        Brave = controllercs.Brave;
        Sad = controllercs.Sad;

        CatTalk = controllercs.CatTalk;

        //���
        Mate = new GameObject[(int)medicineMate.Count];
        Mate[(int)medicineMate.hope] = Hope;
        Mate[(int)medicineMate.dispair] = Dispair;
        Mate[(int)medicineMate.brave] = Brave;
        Mate[(int)medicineMate.sad] = Sad;
        cattalkst = new string[(int)medicineMate.Count];
        cattalkst[(int)medicineMate.hope] = cattalkHope;
        cattalkst[(int)medicineMate.dispair] = cattalkDispair;
        cattalkst[(int)medicineMate.brave] = cattalkBrave;
        cattalkst[(int)medicineMate.sad] = cattalkSad;
    }

    // Start is called before the first frame update
    public void First()
    {
        End();
        nowMedicineMate = 0;
        ChangeMaterial();
    }

    public void End()
    {
        for (int i = 0; i < Mate.Length; i++)
        {
            Mate[i].SetActive(false);
        }
    }

    //�ޗ���؂�ւ�
    public void ChangeMaterial()
    {

        for (int i = 0; i < Mate.Length; i++)
        {
            Mate[i].SetActive(false);
        }
        foreach(medicineMate medicineValue in Enum.GetValues(typeof(medicineMate)))
        {
            if(nowMedicineMate == medicineValue)
            {
                Mate[(int)medicineValue].SetActive(true);
                CatTalk.text = cattalkst[(int)medicineValue];
            }
        }
    }
}
