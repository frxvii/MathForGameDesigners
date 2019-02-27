using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectors : MonoBehaviour
{
    public GameObject objectA, objectB;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, objectA.transform.position);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, objectB.transform.position);
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(objectA.transform.position, objectA.transform.position + objectA.transform.forward);
        Gizmos.DrawRay(objectA.transform.position, objectA.transform.forward);
        Gizmos.color = Color.black;
        Vector3 dot = Vector3.up * Vector3.Dot(objectA.transform.forward, objectB.transform.forward);
        Gizmos.DrawLine(this.transform.position, dot);

        Gizmos.color = Color.white;
        
    }
    
}
