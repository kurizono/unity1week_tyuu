using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float time;
    float move_speed = 8f;
    public GameObject viewCamera, player;

    Game03Controller controllercs;
    SyringeController Syringecs;

    float[] wall_x = new float[2] { -15, 15 };
    float[] wall_y = new float[2] { -15, 15 };

    //向き
    public enum direction {
        right,
        left,
        up,
        down
    }

    direction playerdir;

    private void Awake()
    {
        controllercs = GetComponent<Game03Controller>();
        Syringecs = GetComponent<SyringeController>();
    }

    //プレイヤーとカメラが動く
    public void First()
    {
        Mathf.Clamp(player.transform.position.x, wall_x[0], wall_x[1]);
        Mathf.Clamp(player.transform.position.y, wall_y[0], wall_y[1]);
    }


    //カメラを十字キーで動かす
    public void Main_Player_moving()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (viewCamera.transform.position.y + new Vector3(0, -move_speed, 0).y * Time.deltaTime > wall_y[0])
            {
                viewCamera.transform.position += new Vector3(0, -move_speed, 0) * Time.deltaTime;
            }
            player.transform.rotation = Quaternion.Euler(0, 0, 270);
            playerdir = direction.down;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            if (viewCamera.transform.position.y + new Vector3(0, -move_speed, 0).y * Time.deltaTime < wall_y[1])
            {
                viewCamera.transform.position += new Vector3(0, move_speed, 0) * Time.deltaTime;
            }
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
            playerdir = direction.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (viewCamera.transform.position.x + new Vector3(0, -move_speed, 0).x * Time.deltaTime > wall_x[0])
            {
                viewCamera.transform.position += new Vector3(-move_speed, 0, 0) * Time.deltaTime;
            }
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerdir = direction.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (viewCamera.transform.position.x + new Vector3(0, -move_speed, 0).x * Time.deltaTime < wall_x[1])
            {
                viewCamera.transform.position += new Vector3(move_speed, 0, 0) * Time.deltaTime;
            }
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerdir = direction.right;
        }
    }

    //大きいバージョン
    public void PlayerBigShoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Syringecs.MakeBigShoot(playerdir);
        }
    }
    //小さいバージョン
    public void PlayerSmallShoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Syringecs.MakeSmallShoot(playerdir);
        }
    }
}
