using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PixelDraw : MonoBehaviour
{
    public RawImage myimage;
    Texture2D drawimage;
    
    // Start is called before the first frame update
    void Start()
    {
        drawimage = new Texture2D(1000,1000, TextureFormat.ARGB32, false);
        drawimage.filterMode = FilterMode.Point;
        Color defaultcolor = Color.black;
        
        Color[] colorArray = new Color[drawimage.height * drawimage.height];
        
        for (int i = 0; i < colorArray.Length; i++)
        {
            colorArray[i] = defaultcolor;
        }
        
        drawimage.SetPixels(colorArray);
        drawimage.Apply();

        myimage.texture = drawimage;
        //DrawLine(drawimage, Color.red, 1, 1, 45, 45);
        
    }

    void RandomColors()
    {
        Color[] colorArray = new Color[drawimage.height * drawimage.height];
        
        for (int i = 0; i < colorArray.Length; i++)
        {
            colorArray[i] = new Color(Random.value, Random.value, Random.value);
        }
        
        drawimage.SetPixels(colorArray);
        drawimage.Apply();
    }
    
    
    /*void DrawLine(Texture2D tex, Color col, int x1, int y1, int x2, int y2)
    {
        
        tex.SetPixel(x1, y1, col);
        tex.SetPixel(x2, y2, col);
        tex.Apply();
    }*/
    
    void DrawLine(Texture2D tex, Color col, int x, int y)
    {

        
        tex.SetPixel(x,y,col);
        
        tex.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        //float x1 = Time.frameCount;
        //int x = (int) x1;
        
        
        int r = 250;
        float x1 = 500 + Mathf.Sin(2*Mathf.PI / 360 * r);
        float y1 = 500 + Mathf.Cos(2*Mathf.PI / 360 * r);
        int x = (int) x1;
        int y = (int) y1;
        
        DrawLine(drawimage, Color.white, x, y );
        

        
        //int y = Mathf.Round(y1, 0);
        //print(y);
        //print(y1);
        //int x = Time.frameCount;
        //int y = x;
        
        //DrawLine(drawimage, Color.white, x+ 500, y +500);
    }
}
