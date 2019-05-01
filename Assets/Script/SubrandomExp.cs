using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using LibNoise.Generator;

public class SubrandomExp : MonoBehaviour
{
    public int randCalls = 50;
    List<float> normalVals = new List<float>();
    List<float> randVals = new List<float>();
    List<float> perlinVals = new List<float>();
    List<float> subrandomVals = new List<float>();
    List<float> curveVals = new List<float>();
    public AnimationCurve randDistro;

    // Start is called before the first frame update
    void Start()
    {
        CalcRandomLines();
        OnDrawGizmos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalcRandomLines();
        }
    }

    
    void CalcRandomLines()
    {
        normalVals.Clear();
        randVals.Clear();
        perlinVals.Clear();
        subrandomVals.Clear();
        curveVals.Clear();
        // set parttern, no randomness
        for (int i = 0; i < randCalls; i++)
        {
            normalVals.Add((float)i / (float)randCalls);
        }
        // for pure random
        for (int i = 0; i < randCalls; i++)
        {
            randVals.Add(Random.value);
        }
        // perlin noise output
        Perlin pnoise = new Perlin(0.6, 2, 0.2, 6, Random.Range(0, 10), QualityMode.Medium);
        for (int i = 0; i < randCalls; i++)
        {
            perlinVals.Add((float)pnoise.GetValue((double)i, (double)i, 0));
        }
        // subrandom values
        float subregions = 50f;
        float subrange = 1f / subregions;
        for (int i = 0; i < randCalls; i++)
        {
            subrandomVals.Add(Random.value * subrange);
            subrandomVals[i] += ((float)i % subregions) / subregions;
        }
        // curve randomness
        for (int i = 0; i < randCalls; i++)
        {
            curveVals.Add(randDistro.Evaluate(Random.value));
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            for(int i = 0; i <randCalls; i++)
            {
                // normalVals
                float offset = 25f;
                Vector3 drawfrom = new Vector3(normalVals[i] * 100f, offset, 0);
                Vector3 drawto = new Vector3(drawfrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawfrom, drawto);
                // randVals
                offset = 20f;
                drawfrom = new Vector3(randVals[i] * 100f, offset, 0);
                drawto = new Vector3(drawfrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawfrom, drawto);
                // perlinVals
                offset = 15f;
                drawfrom = new Vector3(perlinVals[i] * 100f, offset, 0);
                drawto = new Vector3(drawfrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawfrom, drawto);
                offset = 10f;
                drawfrom = new Vector3(subrandomVals[i] * 100f, offset, 0);
                drawto = new Vector3(drawfrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawfrom, drawto);
                offset = 5f;
                drawfrom = new Vector3(curveVals[i] * 100f, offset, 0);
                drawto = new Vector3(drawfrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawfrom, drawto);
            }

            
        }
    }
}
