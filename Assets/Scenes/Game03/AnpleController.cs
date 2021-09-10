using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnpleController : MonoBehaviour
{
    Game03Controller controllercs;
    HumanMove_Dinamic humanmovecs;

    private void Awake()
    {
        GameObject controllerobj = GameObject.FindGameObjectWithTag("GameController");
        controllercs = controllerobj.GetComponent<Game03Controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //人間に当たれば洗脳される
        if (collision.CompareTag("human"))
        {
            humanmovecs = collision.gameObject.GetComponent<HumanMove_Dinamic>();
            humanmovecs.Change();
            //オブジェクトを削除
            Destroy(this.gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        //外のフレームに当たったとき
        if (collision.CompareTag("OutFlame"))
        {
            //オブジェクトを削除
            Destroy(this.gameObject);
        }
    }

}
