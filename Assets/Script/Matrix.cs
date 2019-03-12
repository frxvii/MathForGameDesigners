using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public Transform prefab;
    public int girdResolution = 10;
    Transform[] grid;
    
    List<Transformation> transformations;
    Matrix4x4 transformation;
    
    
    
    
    
    
    
    
    void Awake()
    {
        transformations = new List<Transformation>();
        
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
        GetComponents<Transformation>(transformations); // GetComponent s 

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

    Transform CreateGridPoint (int x, int y, int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        return point;
    }

    Vector3 GetCoordinates (int x, int y, int z)
    {
        return new Vector3(x - (girdResolution -1) * 0.5f, y - (girdResolution -1) * 0.5f, z - (girdResolution -1) * 0.5f);
    }

    Vector3 TransformPoint (int x, int y, int z)
    {
        Vector3 coordinates = GetCoordinates(x, y, z);
        for (int i = 0; i < transformations.Count; i++)
        {
            coordinates = transformations[i].Apply(coordinates);
        }
        return transformation.MultiplyPoint(coordinates);
    }

    void UpdateTransformation () {
		GetComponents<Transformation>(transformations);
		if (transformations.Count > 0) {
			transformation = transformations[0].Matrix;
			for (int i = 1; i < transformations.Count; i++) {
				transformation = transformations[i].Matrix * transformation;
			}
		}
	}
}
