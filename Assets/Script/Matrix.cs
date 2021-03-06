﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public Transform prefab;
    public int girdResolution = 10;
    Transform[] grid;
    
    List<Transformation> transformations;
    Matrix4x4 transformation;

    
    void Awake() // Awake is called even if the script component is not enabled.
    {
        transformations = new List<Transformation>();
        
        // creating an array of points
        grid = new Transform[girdResolution * girdResolution * girdResolution];
        for (int i = 0, z = 0; z < girdResolution; z++)
        {
            for (int y = 0; y < girdResolution; y++)
            {
                for (int x = 0; x < girdResolution; x++, i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }
    }

    
    void Update()
    {
        UpdateTransformation();
        
        for (int i = 0, z = 0; z < girdResolution; z++)
        {
            for (int y = 0; y < girdResolution; y++)
            {
                for (int x = 0; x < girdResolution; x++, i++)
                {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }

    
    // instantiate prefabs and assign every prefab a position
    Transform CreateGridPoint (int x, int y, int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        return point;
    }

    // return every point's local
    Vector3 GetCoordinates (int x, int y, int z)
    {
        return new Vector3(x - (girdResolution -1) * 0.5f, y - (girdResolution -1) * 0.5f, z - (girdResolution -1) * 0.5f);
    }

    Vector3 TransformPoint (int x, int y, int z)
    {
        Vector3 coordinates = GetCoordinates(x, y, z);
        return transformation.MultiplyPoint(coordinates); // MultiplyPoint is slower than MultiplyPoint3x4, but can handle projective transformations as well.
    }

   
   // get the first matrix and multiply it with others every update
    void UpdateTransformation () {
		GetComponents<Transformation>(transformations); // GetComponent s 
		if (transformations.Count > 0) {
			transformation = transformations[0].Matrix;
			for (int i = 1; i < transformations.Count; i++) {
				transformation = transformations[i].Matrix * transformation;
			}
		}
	}
}
