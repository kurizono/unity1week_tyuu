using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMoveObjController : MonoBehaviour
{
    float time;
    float deletetime = 10;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > deletetime)
        {
            Destroy(this.gameObject);
        }
    }
}
