using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    public float MoveSpeed =10f;
    public float RotateSpeed =10f;
    public float CamHight = 10f; // vertical distance between player and the camera
    public float followDistance = 20f; // horizontal distance between player and the camera
    private Vector3 camFollowPos;
    private float camFollowSpeed;
    
    
    
    void Start()
    {
        
        Player.transform.position = new Vector3(0, 0, 0);
        
    }

    
    void Update()
    {
        playercontrol();
        followPlayer();     
    }

    private void followPlayer()
    {
        Camera.transform.LookAt(Player.transform.position); // Camera always look at the player object
        // caculate the camera's relative position by adding two vectors
        camFollowPos = -Player.transform.forward * followDistance + Vector3.up * CamHight + Player.transform.position;

        // if player is turing around, let the camera move closer to the player
        if (uTurn())
        {
            camFollowSpeed = 0.9f;
        }
        else
        {
            camFollowSpeed = 0.3f;
        }
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, camFollowPos, camFollowSpeed);
        //Debug.Log(camFollowPos);
    }

    
    // Use dot product to detect whether the player is turning around
    private bool uTurn()
    {
        float dot = Vector3.Dot(Player.transform.forward, Camera.transform.forward);
        Debug.Log(dot);
        if (dot < 0.3f)
        {
            return true;
        }
        else return false;
    }

    private void playercontrol()
    {
        if (Input.GetKey (KeyCode.W))
        { 
            Player.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey (KeyCode.S))
        {
            Player.transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey (KeyCode.A))
        {
            Player.transform.Rotate(0, -1 * Time.deltaTime * RotateSpeed, 0);
        }
        if (Input.GetKey (KeyCode.D))
        {
            Player.transform.Rotate(0, Time.deltaTime * RotateSpeed, 0);
        }
    }
}
