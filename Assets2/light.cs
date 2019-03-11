using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    float rot=0f;  
    public float d = 5f;
    public Camera cam;
    public Camera cam2;

    float z = 0f;
    Vector3 temp = new Vector3(5.0f, 0, 0);
    public float time = 10.0f;
    void Start()
    {
        cam.enabled = true;
        cam2.enabled = false;
    }
    
    

    void Update()
    {
        if (rot < 32)
        {
             z = d * Time.deltaTime;
            transform.Rotate(Vector3.right, z);
            rot += z;

        }
        else
        {
            cam.enabled=false;
            cam2.enabled = true;
            if (time > 0)
                time -= Time.deltaTime;
            else
            {
                transform.Rotate(Vector3.left, rot);
                cam.enabled = true;
                cam2.enabled = false;
                time = 10.0f;
                rot = 0f;
            }

        }
    }
}

