using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.W))
        {
            
            Player.transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey (KeyCode.S))
        {
            Player.transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey (KeyCode.A))
        {
            Player.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey (KeyCode.D))
        {
            Player.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
        }
    }
}
