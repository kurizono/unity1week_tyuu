using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove_Dinamic : MonoBehaviour
{
    Game03Controller controllercs;

    float[] movespeed = new float[2];
    float[] movespeedRange = new float[2] { 1.0f, 2.0f };



    Rigidbody2D rb;
    Vector2 lastVelocity;

    //�f�ނ�ς���
    SpriteRenderer MainSpriteRenderer;
    public Sprite Health, Sick, boy;

    private void Awake()
    {
        GameObject controllerobj = GameObject.FindGameObjectWithTag("GameController");
        controllercs = controllerobj.GetComponent<Game03Controller>();

        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //�X�s�[�h�����߂�
        for (int i = 0; i < movespeed.Length; i++)
        {
            movespeed[i] = Random.Range(movespeedRange[0], movespeedRange[1]);
            if (Random.Range(0, 2) == 0)
            {
                movespeed[i] = movespeed[i] * (-1);
            }
        }
        //rb.AddForce(transform.right * movespeed[0], ForceMode2D.Impulse);
        //rb.AddForce(transform.up * movespeed[1], ForceMode2D.Impulse);

    }

    //�l�Ԃ̈ړ�
    private void Update()
    {
        //this.lastVelocity = this.rb.velocity;
        //�ǂƂԂ���Β��˕Ԃ�
        if (this.gameObject.transform.position.x > controllercs.flameRange[0,0] || this.gameObject.transform.position.x < controllercs.flameRange[1, 0])
        {
            movespeed[0] = -movespeed[0];
        }
        if (this.gameObject.transform.position.y > controllercs.flameRange[0, 1] || this.gameObject.transform.position.y < controllercs.flameRange[1, 1])
        {
            movespeed[1] = -movespeed[1];
        }
        this.gameObject.transform.position += new Vector3(movespeed[0]*Time.deltaTime, movespeed[1] * Time.deltaTime, 0);
    }

    //�N���b�N�����ΐF���ς��(����)
    public void Change()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite != Sick)
        {
            MainSpriteRenderer.sprite = Sick;
            switch (Game01Controller.medicineInfo[0])
            {
                //������
                case 0:
                    //�l�ԍ쐻
                    GameObject human = Instantiate(this.gameObject, this.gameObject.transform.position, Quaternion.identity);
                    human.transform.SetParent(this.gameObject.transform.parent);
                    human.GetComponent<SpriteRenderer>().sprite = Sick;
                    break;
                //�����Ȃ��Ȃ�
                case 1:
                    movespeed[0] = 0;
                    movespeed[1] = 0;
                    break;
                //����
                case 2:
                    movespeed[0] = movespeed[0] * 2;
                    movespeed[1] = movespeed[1] * 2;
                    break;
                //�傫��
                case 3:
                    this.transform.localScale = this.transform.localScale * 2;
                    break;
            }
        }
        controllercs.CountHuman();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���������l�ԂƂԂ���ΐF���ς��(����)
        if (collision.CompareTag("human") 
            && collision.gameObject.GetComponent<SpriteRenderer>().sprite == Sick )
        {
            Change();
        }
    }
}
