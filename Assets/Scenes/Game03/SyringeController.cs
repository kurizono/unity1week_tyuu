using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeController : MonoBehaviour
{
    PlayerMove playercs;

    public GameObject BigSyring, SmallSyring;
    public GameObject BigShoot, SmallShoot;
    public GameObject BigShootPointRight, BigShootPointLeft, BigShootPointUp, BigShootPointDown;
    public GameObject SmallShootPoint;
    public GameObject BigMedicine, SmallMedicine;

    public GameObject Anples;

    float anplespeed = 20f;


    private void Awake()
    {
        playercs = GetComponent<PlayerMove>();
    }


    public void MakeBigShoot(PlayerMove.direction playerdir)
    {
        switch (playerdir)
        {
            case PlayerMove.direction.up:
                UpShoot(BigShoot, BigShootPointRight.transform.position);
                DownShoot(BigShoot, BigShootPointLeft.transform.position);
                LeftShoot(BigShoot, BigShootPointUp.transform.position);
                RightShoot(BigShoot, BigShootPointDown.transform.position);
                break;
            case PlayerMove.direction.down:
                UpShoot(BigShoot, BigShootPointLeft.transform.position);
                DownShoot(BigShoot, BigShootPointRight.transform.position);
                LeftShoot(BigShoot, BigShootPointDown.transform.position);
                RightShoot(BigShoot, BigShootPointUp.transform.position);
                break;
            case PlayerMove.direction.left:
                UpShoot(BigShoot, BigShootPointUp.transform.position);
                DownShoot(BigShoot, BigShootPointDown.transform.position);
                LeftShoot(BigShoot, BigShootPointRight.transform.position);
                RightShoot(BigShoot, BigShootPointLeft.transform.position);
                break;
            case PlayerMove.direction.right:
                UpShoot(BigShoot, BigShootPointDown.transform.position);
                DownShoot(BigShoot, BigShootPointUp.transform.position);
                LeftShoot(BigShoot, BigShootPointLeft.transform.position);
                RightShoot(BigShoot, BigShootPointRight.transform.position);
                break;
        }

    }

    public void MakeSmallShoot(PlayerMove.direction playerdir)
    {
        switch (playerdir)
        {
            case PlayerMove.direction.up:
                UpShoot(SmallShoot, SmallShootPoint.transform.position);
                break;
            case PlayerMove.direction.down:
                DownShoot(SmallShoot, SmallShootPoint.transform.position);
                break;
            case PlayerMove.direction.left:
                LeftShoot(SmallShoot, SmallShootPoint.transform.position);
                break;
            case PlayerMove.direction.right:
                RightShoot(SmallShoot, SmallShootPoint.transform.position);
                break;
        }
    }

    public void UpShoot(GameObject ShootObj, Vector3 ShootPoint)
    {
        GameObject obj = Instantiate(ShootObj, ShootPoint, Quaternion.Euler(0, 0, 0));
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * anplespeed, ForceMode2D.Impulse);
        obj.transform.SetParent(Anples.transform);

    }
    public void DownShoot(GameObject ShootObj, Vector3 ShootPoint)
    {
        GameObject obj = Instantiate(ShootObj, ShootPoint, Quaternion.Euler(0, 0, 0));
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * anplespeed, ForceMode2D.Impulse);
        obj.transform.SetParent(Anples.transform);
    }
    public void LeftShoot(GameObject ShootObj, Vector3 ShootPoint)
    {
        GameObject obj = Instantiate(ShootObj, ShootPoint, Quaternion.Euler(0, 0, 0));
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.right * anplespeed, ForceMode2D.Impulse);
        obj.transform.SetParent(Anples.transform);
    }
    public void RightShoot(GameObject ShootObj, Vector3 ShootPoint)
    {
        GameObject obj = Instantiate(ShootObj, ShootPoint, Quaternion.Euler(0, 0, 0));
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * anplespeed, ForceMode2D.Impulse);
        obj.transform.SetParent(Anples.transform);
    }

}
