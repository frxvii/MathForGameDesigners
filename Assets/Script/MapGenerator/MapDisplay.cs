using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer texRender;


    public void DrawnTexture(Texture2D texture)
    {

        texRender.sharedMaterial.mainTexture = texture; // Show the map int Editor, using .sharedMaterial instead of .material
        texRender.transform.localScale = new Vector3(texture.width, 1, texture.height);

    }
}
