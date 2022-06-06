using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 firstPos;
    Vector3 endPos;

    public float speed;
    public float forwardSpeed=3.0f;
    void Update()
    {
        transform.Translate(0,0,forwardSpeed/100);

        if(Input.GetMouseButtonDown(0)){
            firstPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            endPos =Input.mousePosition;

            float diffX = endPos.x-firstPos.x;


            transform.Translate(diffX*Time.fixedDeltaTime*speed/100,0,0);
            Debug.Log("girdi");
        }

        if(Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
