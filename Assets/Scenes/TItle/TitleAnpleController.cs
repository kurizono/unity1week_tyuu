using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnpleController : MonoBehaviour
{
    TitleHumanMove humanmovecs;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�l�Ԃɓ�����ΐ��]�����
        if (collision.CompareTag("human"))
        {
            humanmovecs = collision.gameObject.GetComponent<TitleHumanMove>();
            humanmovecs.Change();
            //�I�u�W�F�N�g���폜
            Destroy(this.gameObject);
        }
    }
}
