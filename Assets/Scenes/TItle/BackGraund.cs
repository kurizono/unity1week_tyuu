using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGraund : MonoBehaviour
{
    GameObject backCat;
    public GameObject ShootPoint;
    public GameObject ShootObj;

    public GameObject humanmakeObj;
    public GameObject humanObj;

    public GameObject Anples;
    public GameObject humans;

    float backCatMoveSpeed = 0.03f;
    float[] backCatMoveRange = new float[2]
    {
        -1.5f, 1.0f
    };

    float Shoottime;
    float catNextShoot = 0.5f;
    float[] catShootRange = new float[2]
    {
        0.5f, 2.0f
    };

    float anplespeed = 2f;

    float humanmaketime;
    float backHumanMoveSpeed = 2f;
    float humanNextShoot = 0.5f;
    float[] humanShootRange = new float[2]
    {
        1.0f, 2.0f
    };

    private void Awake()
    {
        backCat = this.gameObject;
        Shoottime = 0;
    }

    private void Update()
    {
        Shoottime += Time.deltaTime;
        humanmaketime += Time.deltaTime;
        if(Shoottime > catNextShoot)
        {
            GameObject obj = Instantiate(ShootObj, ShootPoint.transform.position, Quaternion.Euler(0, 0, 0));
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * anplespeed, ForceMode2D.Impulse);
            obj.transform.SetParent(Anples.transform);
            obj.gameObject.AddComponent<TitleMoveObjController>();

            catNextShoot = Random.Range(catShootRange[0], catShootRange[1]);
            Shoottime = 0;
        }
        if(humanmaketime > humanNextShoot)
        {
            GameObject obj = Instantiate(humanObj, humanmakeObj.transform.position, Quaternion.Euler(0, 0, 0));
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.up * backHumanMoveSpeed, ForceMode2D.Impulse);
            obj.transform.SetParent(humans.transform);
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            obj.gameObject.AddComponent<TitleMoveObjController>();

            humanNextShoot = Random.Range(humanShootRange[0], humanShootRange[1]);
            humanmaketime = 0;
        }
    }

    private void FixedUpdate()
    {
        backCat.transform.position = new Vector3(backCat.transform.position.x, backCat.transform.position.y + backCatMoveSpeed, backCat.transform.position.z); 
        if(backCat.transform.position.y > backCatMoveRange[1] || backCat.transform.position.y < backCatMoveRange[0])
        {
            backCatMoveSpeed = -backCatMoveSpeed;
        }
    }
}
