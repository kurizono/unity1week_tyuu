using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game02Controller : MonoBehaviour
{
    //�Q�[�����[�h���K�v
    int gamemode;

    public GameObject humanpre;
    public GameObject humanPare;
    GameObject[] humans;

    // Start is called before the first frame update
    void Start()
    {
        humans = new GameObject[50];
        //10�l�Ԃ𐶂�
        for(int i = 0; i < 10; i++)
        {
            humans[i] = Instantiate(humanpre);
            humans[i].transform.SetParent(humanPare.transform);
        }   

        //�Q�[�����[�h�ݒ�

    }

    // Update is called once per frame
    void Update()
    {
    }
}
