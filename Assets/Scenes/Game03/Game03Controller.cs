using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game03Controller : MonoBehaviour
{
    PlayerMove playercs;
    SyringeController syringcs;

    public GameObject humanpre;
    public GameObject humanPare;

    public Sprite health, mad;

    GameObject[] humans;
    int humannum = 50;

    public float[,] flameRange = new float[2, 2] { { 15f, 15f }, { -15f, -15f } };
    public float[,] CenterflameRange = new float[2, 2] { { 4f, 4f }, { -4f, -4f } };

    public Text HumanScore;


    enum mode
    {
        small,
        big
    }
    mode nowGameMode;


    private void Awake()
    {
        playercs = GetComponent<PlayerMove>();
        syringcs = GetComponent<SyringeController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playercs.First();
        MakeAllHuman();

        First();
    }

    private void First()
    {
        //�Q�[�����[�h�ݒ�
        if (Game01Controller.medicineInfo[1] == 0)
        {
            nowGameMode = mode.big;
        }
        else
        {
            nowGameMode = mode.small;
        }
        GameModeSet();
        CountHuman();
    }

    // Update is called once per frame
    void Update()
    {
        playercs.Main_Player_moving();
        switch (nowGameMode)
        {
            case mode.big:
                playercs.PlayerBigShoot();
                break;
            case mode.small:
                playercs.PlayerSmallShoot();
                break;
        }

    }

    private void GameModeSet()
    {
        switch (nowGameMode)
        {
            case mode.big:
                syringcs.BigSyring.SetActive(true);
                syringcs.SmallSyring.SetActive(false);
                break;
            case mode.small:
                syringcs.BigSyring.SetActive(false);
                syringcs.SmallSyring.SetActive(true);
                break;
        }
    }

    //�l�Ԕz�u
    private void MakeAllHuman()
    {
        humans = new GameObject[humannum];
        //50�l�Ԃ𐶂�
        for (int i = 0; i < humannum; i++)
        {
            //�����l�����߂�
            float firstx, firsty;
            do
            {
                firstx = Random.Range(flameRange[0, 0], flameRange[1, 0]);
                firsty = Random.Range(flameRange[0, 1], flameRange[1, 1]);
            } while ((firstx < CenterflameRange[0, 0] && firstx > CenterflameRange[1, 0]) && (firsty < CenterflameRange[0, 1] && firsty > CenterflameRange[1, 1]));
            //�l�ԍ쐻
            humans[i] = Instantiate(humanpre, new Vector3(firstx, firsty, 0.0f), Quaternion.identity);
            humans[i].transform.SetParent(humanPare.transform);
        }
    }

    //�l�Ԑ�����
    public void CountHuman()
    {
        humans = new GameObject[humanPare.transform.childCount];

        int sickhumannum = 0;

        for (int i = 0; i < humanPare.transform.childCount; i++)
        {
            humans[i] = humanPare.transform.GetChild(i).gameObject;
        }
        for(int i = 0; i < humans.Length; i++)
        {
            if (humans[i].transform.GetComponent<SpriteRenderer>().sprite == mad)
            {
                sickhumannum++;
            }
        }

        HumanScore.text = sickhumannum + "/" + humans.Length;
        if (sickhumannum == humans.Length)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
