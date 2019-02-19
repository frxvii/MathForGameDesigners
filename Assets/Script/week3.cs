using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week3 : MonoBehaviour
{
    float theta = 0;

    public float r = 60f;
    public float speed = 3f;
    public float distance = 3f;
    //private float startAngle = 18;
    private Transform[] points = new Transform[24];
    public Transform pointPrefab;
    void Awake()
    {
        Vector3 position;
        for (int i = 0; i < points.Length; i++)
        {
        Transform point = Instantiate(pointPrefab); //make new object
        position = PointOnCircle(2f * Mathf.PI /360f * i * 15f, r); //new object Evenly distributed on a circle
        point.position = position;
        points[i] = point;
        }
        
    }


    void Update()
    {
        theta = Time.time * speed;
        for (int i = 0; i < points.Length; i++) 
        {
			Transform point = points[i];
            point.position = PointOnCircle(2f * Mathf.PI /360f * i * 15f + theta, r - Time.time * Time.time);
			//objects start draw the circle in different position
            //radius first become smaller, after reach 0, it become larger
            Vector3 position = point.position;
			position.y =  -1f * distance * Mathf.Sin(Time.time * Time.time);//add a sine funtion to y
			point.position = position;
		}
        
        
        
    }

    Vector3 PointOnCircle(float angle, float radius)
    {
        return  new Vector3(radius * Mathf.Cos(angle),0,radius * Mathf.Sin(angle));
    }
}
