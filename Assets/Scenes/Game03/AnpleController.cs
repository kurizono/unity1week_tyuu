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
        //�l�Ԃɓ�����ΐ��]�����
        if (collision.CompareTag("human"))
        {
            humanmovecs = collision.gameObject.GetComponent<HumanMove_Dinamic>();
            humanmovecs.Change();
            //�I�u�W�F�N�g���폜
            Destroy(this.gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        //�O�̃t���[���ɓ��������Ƃ�
        if (collision.CompareTag("OutFlame"))
        {
            //�I�u�W�F�N�g���폜
            Destroy(this.gameObject);
        }
    }

}
