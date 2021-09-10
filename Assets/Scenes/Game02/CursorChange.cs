using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D handCursor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("’Ê‚Á‚Ä‚é");
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }
        
    }

    private static void SetCursor(Texture2D handCursor, Vector2 zero, CursorMode auto)
    {
        throw new NotImplementedException();
    }



}
