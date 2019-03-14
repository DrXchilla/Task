using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunset : MonoBehaviour
{
    public Light sun;
    public float radius;
    public float lenght;
    public float day_time = 10f;
    public float night_time = 3f;
    public float rot = 0f;
    float z;
    public float sun_speed;
    public Camera cam;
    public Camera cam2;
    void Start()
    {

        day_time *= Time.deltaTime/3;
        night_time *= Time.deltaTime/3;
        radius = sun.transform.position.y;
        lenght = radius * radius * 3.14f / 2 * Time.deltaTime; 
        sun_speed = lenght / day_time*Time.deltaTime*Time.deltaTime;
        cam.enabled = true; 
        cam2.enabled = false;
    }
    void Update()
    {
        if (rot >= 360)
            rot -= 360;
        z = sun_speed * Time.deltaTime;
        transform.Rotate(Vector3.right, z);
        rot += z;
        if (rot > 90)
        {
            cam.enabled = false;
            cam2.enabled = true;
            sun_speed = lenght / night_time * Time.deltaTime* Time.deltaTime;
            
        }
        if (rot>270)
        {
            cam.enabled = true;
            cam2.enabled = false;
            sun_speed = lenght / day_time *Time.deltaTime * Time.deltaTime;            
        }
        
    }
}


