using System.Collections;
using LibNoise;
using LibNoise.Generator;
using System.IO;
using System;
using UnityEngine;

//public enum NoiseType {Perlin, Billow, RidgedMultifractal, Voronoi, Mix};

public class Demo : MonoBehaviour {
        private Noise2D m_noiseMap = null;
        private Texture2D[] m_textures = new Texture2D[3];
        public int resolution = 64; 
        public NoiseType noise = NoiseType.Perlin;
        public float zoom = 1f; 
        public float offset = 0f; 
    
    public void Start() {
    	Generate();
    }
    
    public void OnGUI() {
    	int y = 0;
    	foreach ( string i in System.Enum.GetNames(typeof(NoiseType)) ) {
    		if (GUI.Button(new Rect(0,y,100,20), i) ) {
    			noise = (NoiseType) Enum.Parse(typeof(NoiseType), i);
    			Generate();
    		}
    		y+=20;
    	}
    }
    	
    public void Generate() {	
            // Create the module network
            ModuleBase moduleBase;
            switch(noise) {
	            case NoiseType.Billow:	
            	moduleBase = new Billow();
            	break;
            	
	            case NoiseType.RidgedMultifractal:	
            	moduleBase = new RidgedMultifractal();
            	break;   
            	
	            case NoiseType.Voronoi:	
            	moduleBase = new Voronoi();
            	break;             	         	
            	
             // 	case NoiseType.Mix:            	
            	//Perlin perlin = new Perlin();
            	//RidgedMultifractal rigged = new RidgedMultifractal();
            	//moduleBase = new Add(perlin, rigged);
            	//break;
            	
            	default:
            	moduleBase = new Perlin();
            	break;
            	
            }

            // Initialize the noise map
            this.m_noiseMap = new Noise2D(resolution, resolution, moduleBase);
            this.m_noiseMap.GeneratePlanar(
            offset + -1 * 1/zoom, 
            offset + offset + 1 * 1/zoom, 
            offset + -1 * 1/zoom,
            offset + 1 * 1/zoom);

		// Generate the textures
		this.m_textures[0] = this.m_noiseMap.GetTexture(GradientPresets.Grayscale);

		this.m_textures[0].Apply();
            
            this.m_textures[1] = this.m_noiseMap.GetTexture(GradientPresets.Terrain);
            this.m_textures[1].Apply();
             
            this.m_textures[2] = this.m_noiseMap.GetNormalMap(3.0f);
			 this.m_textures[2].Apply();
			 
			 //display on plane
			 GetComponent<Renderer>().material.mainTexture = m_textures[0];
            

            //write images to disk
            File.WriteAllBytes(Application.dataPath + "/../Gray.png", m_textures[0].EncodeToPNG() );
            File.WriteAllBytes(Application.dataPath + "/../Terrain.png", m_textures[1].EncodeToPNG() );
            File.WriteAllBytes(Application.dataPath + "/../Normal.png", m_textures[2].EncodeToPNG() );
            
            Debug.Log("Wrote Textures out to "+Application.dataPath + "/../");
            
        
    }
    
}