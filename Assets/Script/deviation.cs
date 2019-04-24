using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deviation : MonoBehaviour
{
    public GameObject agent;
    private GameObject deviationBar; // the bar can show the standard deviation    
    [Range(1,500)]public int numberOfSpawns;
    List<GameObject> _allAgents = new List<GameObject>(); // list of prefabs
    List<float> height = new List<float>(); // store the y position of each prefab
    List<float> timeOffset = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        deviationBar = GameObject.Find("DeviationBar");
        for (int i = 0; i < numberOfSpawns; i++)
        {
            height.Add(0);
            timeOffset.Add(Random.Range(0f, 15f));
            _allAgents.Add(Instantiate(agent, new Vector3(i - numberOfSpawns / 2f, height[i], 0), Quaternion.identity, transform)); // instantiate prefabs at the start
        }
        
        deviationBar.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < numberOfSpawns; i++)
        {    
            height[i] = Mathf.Sin(Time.time * 3f + timeOffset[i]) * timeOffset[i]; // every agent has a time offset so they will not move at the same frequency
            _allAgents[i].transform.position = new Vector3(i - numberOfSpawns / 2f, height[i], 0); // add sin function to each agent, so its y position will changing between certain numbers
        }
        StandardDeviation(height); // calculate the standard deviation of agents' y position
        deviationBar.transform.localScale = new Vector3(StandardDeviation(height) * 15f, 1, 1); // visualize the standard deviation every frame by scaling its x axis
        Debug.Log(StandardDeviation(height));
    }
     // calculate the Standard Deviation
    float StandardDeviation(List<float> sample)
    {
        float sum = 0;
        float sumTemp = 0;
        float[] temp = new float[numberOfSpawns];
        foreach (int item in sample)
        {
            sum += item;
        }
        float mean = sum / sample.Count;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            temp[i] = (sample[i] - mean) * (sample[i] - mean);
        }

        foreach (int item in temp)
        {
            sumTemp += item;
        }
        float avgTemp = sumTemp / sample.Count;
        return Mathf.Sqrt(avgTemp);
    }
}
