using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnpleController : MonoBehaviour
{
    TitleHumanMove humanmovecs;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //人間に当たれば洗脳される
        if (collision.CompareTag("human"))
        {
            humanmovecs = collision.gameObject.GetComponent<TitleHumanMove>();
            humanmovecs.Change();
            //オブジェクトを削除
            Destroy(this.gameObject);
        }
    }
}
