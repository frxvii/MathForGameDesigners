using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deviation : MonoBehaviour
{
    public GameObject agent;
    public float radius = 3f;
    [Range(1,500)]public int numberOfSpawns;
    List<GameObject> _allAgents = new List<GameObject>();
    List<float> height = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            height.Add(Random.Range(0,10));
            _allAgents.Add(Instantiate(agent, new Vector3(i * 1.5f, height[i], 0), Quaternion.identity, transform));
        }
        StandardDeviation(height);
        Debug.Log(StandardDeviation(height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float StandardDeviation(List<float> sample)
    {
        float sum = 0;
        float sumTemp = 0;
        float[] temp = new float[numberOfSpawns];
        foreach (int item in sample)
        {
            sum += item;
        }
        float avg = sum / sample.Count;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            temp[i] = (sample[i] - avg) * (sample[i] - avg);
        }

        foreach (int item in temp)
        {
            sumTemp += item;
        }
        float avgTemp = sumTemp / sample.Count;
        return Mathf.Sqrt(avgTemp);
    }
}
