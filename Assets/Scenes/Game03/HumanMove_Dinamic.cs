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

    //素材を変える
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
        //スピードを決める
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

    //人間の移動
    private void Update()
    {
        //this.lastVelocity = this.rb.velocity;
        //壁とぶつかれば跳ね返る
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

    //クリックされれば色が変わる(注射)
    public void Change()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite != Sick)
        {
            MainSpriteRenderer.sprite = Sick;
            switch (Game01Controller.medicineInfo[0])
            {
                //増える
                case 0:
                    //人間作製
                    GameObject human = Instantiate(this.gameObject, this.gameObject.transform.position, Quaternion.identity);
                    human.transform.SetParent(this.gameObject.transform.parent);
                    human.GetComponent<SpriteRenderer>().sprite = Sick;
                    break;
                //動かなくなる
                case 1:
                    movespeed[0] = 0;
                    movespeed[1] = 0;
                    break;
                //早い
                case 2:
                    movespeed[0] = movespeed[0] * 2;
                    movespeed[1] = movespeed[1] * 2;
                    break;
                //大きい
                case 3:
                    this.transform.localScale = this.transform.localScale * 2;
                    break;
            }
        }
        controllercs.CountHuman();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //感染した人間とぶつかれば色が変わる(感染)
        if (collision.CompareTag("human") 
            && collision.gameObject.GetComponent<SpriteRenderer>().sprite == Sick )
        {
            Change();
        }
    }
}
