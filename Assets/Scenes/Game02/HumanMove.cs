using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{

    float[] movespeed = new float[2];
    float[] movespeedRange = new float[2] { 2.0f, 4.0f };

    float[,] flameRange = new float[2, 2] { { -0.8f, 5.2f }, { -9.3f, -3.2f } };


    Rigidbody2D rb;
    Vector2 lastVelocity;

    SpriteRenderer MainSpriteRenderer;
    public Sprite Health, Sick, boy;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();

        //スピードを決める
        for (int i = 0; i < movespeed.Length; i++)
        {
            movespeed[i] = Random.Range(movespeedRange[0], movespeedRange[1]);
            if(Random.Range(0,2) == 0)
            {
                movespeed[i] = movespeed[i] * (-1);
            }
        }
        rb.AddForce(transform.right * movespeed[0], ForceMode2D.Impulse);
        rb.AddForce(transform.up * movespeed[1], ForceMode2D.Impulse);


        //初期値を決める
        float firstx = Random.Range(flameRange[0, 0], flameRange[1, 0]);
        float firsty = Random.Range(flameRange[0, 1], flameRange[1, 1]);
        this.gameObject.transform.position = new Vector3(firstx, firsty);
    }

    //人間の移動
    private void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;
    }


    //クリックされれば色が変わる(注射)
    public void OnMouseDown()
    {
        MainSpriteRenderer.sprite = Sick;
    }

    //感染した人間とぶつかれば色が変わる(感染)
}
