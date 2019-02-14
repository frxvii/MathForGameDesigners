using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [Range(0,2f * Mathf.PI)]public float theta = 0;

    public float r = 5f;
    public float speed = 3f;
    void Start()
    {
        this.transform.position = Vector3.zero;
    }


    void Update()
    {
        theta = Time.time * speed;
        this.transform.position = PointOnCircle(theta, r * Mathf.Sin(Time.time * 1.5f) );
        Vector3 newpos = this.transform.position;
        newpos.z = Time.time;
        this.transform.position = newpos;
    }

    Vector3 PointOnCircle(float angle, float radius)
    {
        return  new Vector3(radius * Mathf.Cos(angle),radius * Mathf.Sin(angle),0);
    }
}
