using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMatrix : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    public Matrix4x4 original_camProjMatrix;
    public Vector3 shearing;
    Matrix4x4 Xshearing = Matrix4x4.identity; 
    Matrix4x4 Yshearing = Matrix4x4.identity;
    Matrix4x4 MatrixRotate = Matrix4x4.identity;
    public float theta;

    void Start()
    {
        cam = GetComponent<Camera>();
        original_camProjMatrix = cam.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        Xshearing[0,1] = shearing.x;
        Yshearing[1,0] = shearing.y;

        MatrixRotate[0, 0] = Mathf.Cos(theta);
        MatrixRotate[0, 1] = Mathf.Sin(theta);
        MatrixRotate[1, 0] = -1 * Mathf.Sin(theta);
        MatrixRotate[1, 1] = Mathf.Cos(theta);

        cam.projectionMatrix = original_camProjMatrix * Xshearing * Yshearing * MatrixRotate;
    }
}
