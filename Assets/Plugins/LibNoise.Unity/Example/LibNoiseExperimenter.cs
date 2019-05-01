using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using LibNoise.Generator;
using LibNoise.Operator;
using System.IO;
using System;

public enum NoiseType { Perlin, Billow, RidgedMultifractal, Voronoi, Checker, Const, Cylinders, Spheres };

public class LibNoiseExperimenter : MonoBehaviour {
	private Noise2D m_noiseMap = null;
	private Texture2D[] m_textures = new Texture2D[3];
	[Header("Texture Resolution")]
	public int resolution = 128;

	public float zoom = 1f;
	public float offset = 0f;
	[Header("Noise Paramters")]
	public int seed = 0;
	public NoiseType noise = NoiseType.Perlin;
	//public double freq = 1.0;
	//public double displac = 1.0; //voronoi only?
	//public bool dist = false; //voronoi only?
	//public double lacun = 2.0;
	//public double persist = 0.5; //not in riggedmulti or voronoi
	//public int octvs = 6;


	private string[] noiseStrings = { "Frequency", "Displace.", " ", "Lacun.", "Persist.", "Octaves" };

	double[] n_freq = new double[2] { 1, 1 };
	double[] n_displaces = new double[2] { 1, 1 };
	bool[] n_distance = new bool[2] { false, false };
	double[] n_lacun = new double[2] { 2.0, 2.0 };
	double[] n_persist = new double[2] { 0.5, 0.5 };
	int[] n_octaves = new int[2] { 6, 6 };

	private int[] selectionGridInt = new int[2];
	private string[] selectionStrings = System.Enum.GetNames(typeof(NoiseType));

	int operatorGridInt = 0;
	private string[] operatorGridStrings = { "Add", "Blend", "Max", "Min", "Multiply", "Power", "Subtract", "Terrace", "JustLeft"};

	ModuleBase[] moduleBases = new ModuleBase[2];

	public void Start() {

		moduleBases[0] = new Const();
		moduleBases[1] = new Const();

		Generate();
	}
	float timer = 0;
	private void Update() {
		timer += Time.deltaTime;
		if (timer > 1f) {
			timer = 0;
			Generate();
		}
	}

	public void OnGUI() {
		//int y = 0;
		//foreach (string i in System.Enum.GetNames(typeof(NoiseType))) {
		//	if (GUI.Button(new Rect(0, y, 100, 20), i)) {
		//		noise = (NoiseType)Enum.Parse(typeof(NoiseType), i);
		//		//Generate();
		//	}
		//	y += 20;
		//}

		selectionGridInt[0] = GUI.SelectionGrid(new Rect(5, 5, 120, 25* selectionStrings.Length), selectionGridInt[0], selectionStrings, 1);
		selectionGridInt[1] = GUI.SelectionGrid(new Rect(130, 5, 120, 25 * selectionStrings.Length), selectionGridInt[1], selectionStrings, 1);
		operatorGridInt = GUI.SelectionGrid(new Rect(265, 5, 120, 25 * operatorGridStrings.Length), operatorGridInt, operatorGridStrings, 1);

		for (int n = 0; n <= 1; n++) {
			for (int i = 0; i < noiseStrings.Length; i++) {
				// { Perlin, Billow, RidgedMultifractal, Voronoi, Checker, Const, Cylinders, Spheres };

				//public double freq = 1.0;
				//public double displac = 1.0; //voronoi only?
				//public bool dist = false; //voronoi only?
				//public double lacun = 2.0;
				//public double persist = 0.5; //not in riggedmulti or voronoi
				//public int octvs = 6;
				if (selectionGridInt[n] > 4 && i == 0) {
					GUI.Label(new Rect(5 + (n * 125), (40 * i) + 30 + (25 * selectionStrings.Length), 100, 30), noiseStrings[i]);
				} else if (selectionGridInt[n] == 3 && (i >= 0 && i <= 2)) {
					GUI.Label(new Rect(5 + (n * 125), (40 * i) + 30 + (25 * selectionStrings.Length), 100, 30), noiseStrings[i]);
				} else if (selectionGridInt[n] == 2 && i != 1 && i != 2 && i != 4) {
					GUI.Label(new Rect(5 + (n * 125), (40 * i) + 30 + (25 * selectionStrings.Length), 100, 30), noiseStrings[i]);
				} else if (selectionGridInt[n] < 2 && i != 1 && i != 2) {
					GUI.Label(new Rect(5 + (n * 125), (40 * i) + 30 + (25 * selectionStrings.Length), 100, 30), noiseStrings[i]);
				}
			}

			if (selectionGridInt[n] != 4) {
				n_freq[n] = GUI.HorizontalSlider(new Rect(5 + (n * 125), 20 + (40 * 0) + 30 + (25 * selectionStrings.Length), 100, 30), (float)n_freq[n], 0.0f, 5.0f);
				GUI.Label(new Rect(80 + (n * 125), 0 + (40 * 0) + 30 + (25 * selectionStrings.Length), 100, 30), n_freq[n].ToString("0.00"));
			}
			if (selectionGridInt[n] == 3) {
				n_displaces[n] = GUI.HorizontalSlider(new Rect(5 + (n * 125), 20 + (40 * 1) + 30 + (25 * selectionStrings.Length), 100, 30), (float)n_displaces[n], 0.5f, 5.0f);
				n_distance[n] = GUI.Toggle(new Rect(5 + (n * 125), 20 + (40 * 2) + 30 + (25 * selectionStrings.Length), 100, 30), n_distance[n], "Distance");
				GUI.Label(new Rect(80 + (n * 125), 0 + (40 * 1) + 30 + (25 * selectionStrings.Length), 100, 30), n_displaces[n].ToString("0.00"));
				//n_distance[n] = GUI.Label(new Rect(5 + (n * 125), 20 + (40 * 2) + 30 + (25 * selectionStrings.Length), 100, 30), n_distance[n], "Distance");
			}
			if (selectionGridInt[n] <= 2) {
				n_lacun[n] = GUI.HorizontalSlider(new Rect(5 + (n * 125), 20 + (40 * 3) + 30 + (25 * selectionStrings.Length), 100, 30), (float)n_lacun[n], 0.0f, 10.0f);
				n_octaves[n] = (int)GUI.HorizontalSlider(new Rect(5 + (n * 125), 20 + (40 * 5) + 30 + (25 * selectionStrings.Length), 100, 30), (float)n_octaves[n], 1f, 8f);
				GUI.Label(new Rect(80 + (n * 125), 0 + (40 * 3) + 30 + (25 * selectionStrings.Length), 100, 30), n_lacun[n].ToString("0.00"));
				GUI.Label(new Rect(80 + (n * 125), 0 + (40 * 5) + 30 + (25 * selectionStrings.Length), 100, 30), n_octaves[n].ToString("0"));
			}
			if (selectionGridInt[n] <= 1) {
				n_persist[n] = GUI.HorizontalSlider(new Rect(5 + (n * 125), 20 + (40 * 4) + 30 + (25 * selectionStrings.Length), 100, 30), (float)n_persist[n], 0.1f, 4.0f);
				GUI.Label(new Rect(80 + (n * 125), 0 + (40 * 4) + 30 + (25 * selectionStrings.Length), 100, 30), n_persist[n].ToString("0.00"));

			}

		}

	}




	void Generate() {
		// { Perlin, Billow, RidgedMultifractal, Voronoi, Checker, Const, Cylinders, Spheres };
		for (int n = 0; n <= 1; n++) {
			switch ((NoiseType)selectionGridInt[n]) {
				case NoiseType.Perlin:
					moduleBases[n] = new Perlin(n_freq[n], n_lacun[n], n_persist[n], n_octaves[n], n, QualityMode.Medium);
					break;
				case NoiseType.Billow:
					moduleBases[n] = new Billow(n_freq[n], n_lacun[n], n_persist[n], n_octaves[n], n, QualityMode.Medium);
					break;
				case NoiseType.RidgedMultifractal:
					moduleBases[n] = new RidgedMultifractal(n_freq[n], n_lacun[n], n_octaves[n], n, QualityMode.Medium);
					break;
				case NoiseType.Voronoi:
					moduleBases[n] = new Voronoi(n_freq[n], n_displaces[n], n, n_distance[n]);
					break;
				case NoiseType.Checker:
					moduleBases[n] = new Checker();
					break;
				case NoiseType.Const:
					moduleBases[n] = new Const(n_freq[n]);
					break;
				case NoiseType.Cylinders:
					moduleBases[n] = new Cylinders(n_freq[n]);
					break;
				case NoiseType.Spheres:
					moduleBases[n] = new Spheres(n_freq[n]);
					break;
			}
		}
		ModuleBase moduleBase = new Const();
		// { "Add", "Blend", "Max", "Min", "Multiply", "Power", "Select", "Subtract", "Terrace"};
		switch (operatorGridInt) {
			case 0:
				moduleBase = new Add(moduleBases[0], moduleBases[1]);
				break;
			case 1:
				moduleBase = new Blend(moduleBases[0], moduleBases[1], new Perlin());
				break;
			case 2:
				moduleBase = new Max(moduleBases[0], moduleBases[1]);
				break;
			case 3:
				moduleBase = new Min(moduleBases[0], moduleBases[1]);
				break;
			case 4:
				moduleBase = new Multiply(moduleBases[0], moduleBases[1]);
				break;
			case 5:
				moduleBase = new Power(moduleBases[0], moduleBases[1]);
				break;
			case 6:
				moduleBase = new Subtract(moduleBases[0], moduleBases[1]);
				break;
			case 7:
				moduleBase = new Terrace(false, moduleBases[0]);
				break;
			case 8:
				moduleBase = moduleBases[0];
				break;
		}


		//case NoiseType.Mix:
		//	Perlin perlin = new Perlin(freq, lacun, persist, octvs, seed, QualityMode.High);
		//	RidgedMultifractal rigged = new RidgedMultifractal(freq, lacun, octvs, seed, QualityMode.High);
		//	Cylinders cyls = new Cylinders(freq);
		//	//moduleBase = new Add(perlin, rigged);
		//	moduleBase = new Blend(perlin, rigged, new Billow());
		//	break;

		// Initialize the noise map
		//moduleBase = new Scale(2, 2, 2, moduleBase);
		//moduleBase = new Translate(-1, -1, -1, moduleBase);
		this.m_noiseMap = new Noise2D(resolution, resolution, moduleBase);
		this.m_noiseMap.GeneratePlanar(
		offset + -1 * 1 / zoom,
		offset + offset + 1 * 1 / zoom,
		offset + -1 * 1 / zoom,
		offset + 1 * 1 / zoom);

		// Generate the textures
		this.m_textures[0] = this.m_noiseMap.GetTexture(GradientPresets.Grayscale);
		this.m_textures[0].filterMode = FilterMode.Point;
		//this.m_textures[0] = this.m_noiseMap.GetTexture(LibNoise.Unity.Gradient.Terrain);

		this.m_textures[0].Apply();

		this.m_textures[1] = this.m_noiseMap.GetTexture(GradientPresets.Terrain);
		this.m_textures[1].Apply();

		this.m_textures[2] = this.m_noiseMap.GetNormalMap(3.0f);
		this.m_textures[2].Apply();

		//display on plane
		GetComponent<Renderer>().material.mainTexture = m_textures[0];


		//write images to disk
		//File.WriteAllBytes(Application.dataPath + "/../Gray.png", m_textures[0].EncodeToPNG());
		//File.WriteAllBytes(Application.dataPath + "/../Terrain.png", m_textures[1].EncodeToPNG());
		//File.WriteAllBytes(Application.dataPath + "/../Normal.png", m_textures[2].EncodeToPNG());

	}
}
