using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformation : Transformation
{
    public  Vector3 scale;
    public override Matrix4x4 Matrix {
			get {
			Matrix4x4 matrix = new Matrix4x4();
			matrix.SetRow(0, new Vector4(Mathf.Sin(Time.time / 2f) * 3f, 0f, 0f, 0f)); // Sets a row of the matrix.
			matrix.SetRow(1, new Vector4(0f, Mathf.Sin(Time.time / 2f) * 3f, 0f, 0f)); // scale x, y, z axis by using sin function
			matrix.SetRow(2, new Vector4(0f, 0f, Mathf.Sin(Time.time / 2f) * 5f, 0f));
			matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			return matrix;
		}
	}
}
