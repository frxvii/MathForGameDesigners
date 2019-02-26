using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class TrigExample : MonoBehaviour
{
    LineRenderer myline;
    public float lengthA = 4f;
    public float speedA = 1f;
    public float lengthB = 5f;
    public float speedB = 2f;

    public float lengthC = 1f;
    public float speedC = 8f;
    public GameObject trailobj;
    List<Vector3> positionlist = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
       myline = GetComponent<LineRenderer>(); 

       myline.positionCount = 0;
       positionlist.Add(Vector3.zero);
       positionlist.Add(Vector3.zero);
       positionlist.Add(Vector3.zero);
       positionlist.Add(Vector3.zero);
       


       
    }

    // Update is called once per frame
    void Update()
    {
        positionlist[1] = (PointOnCircle(Time.time * speedA, lengthA));
        positionlist[2] = positionlist[1] + (PointOnCircle(Time.time * speedB, lengthB));
        positionlist[3] = positionlist[2] + (PointOnCircle(Time.time * speedC, lengthC));
        UpdatePoints();
        trailobj.transform.position = positionlist[positionlist.Count -1];
    }

    Vector3 PointOnCircle(float angle, float radius)
    {
        return  new Vector3(radius * Mathf.Cos(angle),radius * Mathf.Sin(angle), 0);
    }

    //void DrawLine(float )

    void UpdatePoints()
    {
        myline.positionCount = positionlist.Count; 
        myline.SetPositions(positionlist.ToArray());
    }
}
