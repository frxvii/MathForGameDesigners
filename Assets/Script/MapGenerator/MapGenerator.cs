using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MapGenerator : MonoBehaviour
{
    public enum  DrawMode {NoiseMap, ColorMap};
    public DrawMode drawMode;
    
    public int mapWidth;
    public int mapHeight;

    public float noiseScale;
    public int octaves;
    [Range(0,1)]public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;
    public bool autoUpdate;
    public TerrainType[] regions;


    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        
        Color[] colorMap = new Color[mapHeight * mapWidth];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentH = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentH <= regions[i].height)
                    {
                        colorMap[y * mapWidth + x] = regions[i].color; // Convert the noiseMap 2D array to a 1D color array;
                        break;
                    }
                    
                }
            }
        }

        MapDisplay display =  FindObjectOfType<MapDisplay> ();
        if (drawMode == DrawMode.NoiseMap) 
        {
            display.DrawnTexture (TexGenerator.TexFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            display.DrawnTexture (TexGenerator.TexFromColorMap(colorMap, mapWidth, mapHeight));
        }

        
        
    }

    // This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only).
    void OnValidate() 
    {
        if (mapWidth < 1) 
        {
			mapWidth = 1;
		}
		if (mapHeight < 1) 
        {
			mapHeight = 1;
		}
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }


    
}
[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
    
}
