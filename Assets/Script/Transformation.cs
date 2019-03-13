using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformation : MonoBehaviour
{
    public Vector3 Apply (Vector3 point)
    {
        return Matrix.MultiplyPoint(point); // MultiplyPoint is slower than MultiplyPoint3x4, but can handle projective transformations as well.
    }
        
    

    public abstract Matrix4x4 Matrix { get; }
}
