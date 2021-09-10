using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    EndingController controllercs;

    string[,] Ending = new string[4, 2]
    {
        {
            "�l�ނ͊�]������܂����B"+ "\n" +
            "�����邱�Ƃ͂悢���Ƃ�"+ "\n" +
            "�q�����Ă���̂ł��B"+ "\n" +
            "�n�����g�����l��������"+ "\n" +
            "�S�Ă������Ƃ�"+ "\n" +
            "�O�G��Ȃ̂ł��B"+ "\n\n" +
            "�΂��ł��ˁB",
            "����͂����Ƃ��āA"+ "\n" +
            "�ɂႠ�����͍�����"+ "\n" +
            "�����������炵�Ă��܂��B"+ "\n" +
            "�߂ł����߂ł����B"
        },
        {
            "�l�ނ͐�]��"+ "\n" +
            "�N����܂����B"+ "\n" +
            "�������ƂȂ�"+ "\n" +
            "�������܂���B"+ "\n" +
            "�����Ă��ɂ�"+ "\n" +
            "�������Ȃ��Ȃ�܂����B"+ "\n" +
            "��l�c�炸�s�N���Ƃ�"+ "\n" +
            "�����Ȃ��Ȃ�܂����B"+ "\n\n" +
            "���ǂ��ł��ˁB",
            "����͂����Ƃ��āA"+ "\n" +
            "�ɂႠ�����͍�����"+ "\n" +
            "�Ȃ��悭���炵�Ă��܂��B"+ "\n" +
            "�߂ł����߂ł����B" },
        {
            "�l�ނ͗E�C��"+ "\n" +
            "�������܂����B"+ "\n" +
            "�������������Ǝv�����Ƃ�"+ "\n" +
            "�����Ȃ����H�ł���悤��"+ "\n" +
            "�Ȃ�܂����B"+ "\n" +
            "�ł��l�ނ͋����Ȃ̂ŁA"+ "\n" +
            "�����̈ӌ���"+ "\n" +
            "�����ʂ����߂�"+ "\n" +
            "�푈���N�����܂����B"+ "\n\n" +
            "�ɂ��₩�ł��ˁB",
            "����͂����Ƃ��āA" + "\n" +
            "�ɂႠ�����͍�����" + "\n" +
            "���a�ł��B�B" + "\n" +
            "�߂ł����߂ł����B"
        },
        {
            "�l�ނ͉��a�ɂȂ�܂����B"+ "\n" +
            "���ɂ͑��̐l�̔ߖ�" + "\n" +
            "�ߖ�������悤�ɂȂ�" + "\n" +
            "���E�͔ߖ̑升����" + "\n" +
            "��܂�܂����B" + "\n\n" +
            "�y�������ł��ˁB",
            "����͂����Ƃ��āA" + "\n" +
            "�ɂႠ�����͍�����" + "\n" +
            "�y�������炵�Ă��܂��B" + "\n" +
            "�߂ł����߂ł����B"
        },
    };
    private void Awake()
    {
        controllercs = GetComponent<EndingController>();
    }

    public void TextChange(int endnum, int endstage)
    {
        controllercs.endingText.text = Ending[endnum, endstage];
    }
}