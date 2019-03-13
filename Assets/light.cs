using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public float angle_night = 90f;               //Угол поворота "солнца" для наступления ночи
    public float angle_day = -90f;                    //Угол поворота "солнца" для наступления утра
    float rot = 0f;              //Изменение вращения солнца по оси X
    public float speed = 25f;                 //Скорость вращения солнца
    public Camera cam;                //Камера дневной сцены
    public Camera cam2;          //Камера ночной сцены
    bool negative = false;   //Флаг перехода в отрицательный круг [-180,0]
    void Start()
    {
        cam.enabled = true;
        cam2.enabled = false;
    }   
        void Update()
    {
        
        float z = speed * Time.deltaTime;
        transform.Rotate(Vector3.right, z);
        if (negative)
            rot -= z;
        else
            rot += z;
        if (rot >= 180)// cброс полуповорота
        {
            rot -= 180;
            negative = true;
        }
        if (rot <= -180)
        {
            rot += 180;
            negative = false;
        }
        if (rot > angle_night || (rot>angle_day && negative))//ночная "дуга"
        {

            cam.enabled = false;      //переключение сцены
            cam2.enabled = true;
        }
            if (rot<angle_day&&negative|| (rot<angle_night&&negative==false))      //   "дневная" дуга
            {                
                cam.enabled = true;
                cam2.enabled = false;            
           
            }
            
        }
    }


