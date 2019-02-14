using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphWK2 : MonoBehaviour
{
    public GraphFunctionName function;
    public delegate Vector3 GraphFunction(float u, float v, float t);
    public Transform pointPrefab;
    [Range(0,4)]public int rotation = 0 ;
    
    [Range(10,100)]public int resolution = 10;
    Transform[] points;
    static GraphFunction[] functions = {
        Cylinder
    };
    void Awake () {
        
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        
        points = new Transform[resolution * resolution];

        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }
    void Update () {
    
        //float t = Time.time;
        float t = rotation / 4f;
        
        float step = 2f / resolution;
        GraphFunction f = functions[(int)function];
        for (int i = 0, z = 0; z < resolution; z++) {
            float v = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++) {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, t);
            }
        }
    }
    
   
    
    static Vector3 Sphere (float u, float v, float t) {
        Vector3 p;
        float r = Mathf.Cos(Mathf.PI * 0.5f * v);
        p.x = r * Mathf.Sin(Mathf.PI * u); 
        p.y = Mathf.Sin(Mathf.PI * 0.5f * v);
        p.z = r * Mathf.Cos(Mathf.PI * u);
        return p;
    }
    
    static Vector3 Cylinder (float u, float v, float t) {
        Vector3 p;
     
        float r;
        if (t == 0)
        {
            r = 0.8f + Mathf.Sin(Mathf.PI * (4 * t * u + 2f * v + Time.time)) * 0.2f;
        }
        else
        {
            r = 0.8f + Mathf.Sin(Mathf.PI * (4 * t * u + 2 * t * v + Time.time)) * 0.2f;
        }
        
        p.x = r * Mathf.Sin(Mathf.PI * u);
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * u);
        return p;    
        
    }
    
}