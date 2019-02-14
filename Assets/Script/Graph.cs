using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    public Transform pointPrefab;
    [Range(0,1f)]public float amplitude = 0.5f ;
    [Range(10,50)]public int resolution = 10;
    Transform[] points;
    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        
        points = new Transform[resolution * resolution];
        for (int i = 0, z = 0; z < resolution; z++) 
        {
            position.z = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++) {
                Transform point = Instantiate(pointPrefab);
                position.x = (x + 0.5f) * step - 1f;

                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform, false);
                points[i] = point;
            }
        }
    }
    void Update () {
    
        float t = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition; 
            position.y = SineWaveFunction(position.x, position.z, t);
            point.localPosition = position;
        }
    }
    
    float SineWaveFunction (float x, float z, float t) 
    {

        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(Mathf.PI * (z + t));
        y = y * 0.5f * amplitude; 
        return y;
    }
}