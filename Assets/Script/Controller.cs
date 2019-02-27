using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnemyAI;
    public float MoveSpeed = 10.0f;
    private float distance;
    private float distX;
    private float distY;
    private float angle;
    private Transform midPoint;
    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = new Vector3(12, 0, 0);
        EnemyAI.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playercontrol();
        if (inRange())
            chasingPlayer();
    }

    private bool inRange()
    {
        distance = Vector3.Distance(Player.transform.position, EnemyAI.transform.position);
        if (distance > 10.0f)
            return false;
        else return true;

    }

    private void chasingPlayer()
    {
        
        Vector3 a = EnemyAI.transform.position - Player.transform.position;
        
        float dot = Vector3.Dot( Vector3.right, a.normalized);
        
        if (EnemyAI.transform.position.y > Player.transform.position.y)
            angle = Mathf.Acos ( dot) * Mathf.Rad2Deg;
        else
            angle = Mathf.Acos (-1 * dot) * Mathf.Rad2Deg;
        
        EnemyAI.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        EnemyAI.transform.position = Vector3.MoveTowards(EnemyAI.transform.position, Player.transform.position, 0.02f);
        Debug.Log(angle);
    }
    /*private bool lockedOn()
    {
        if(inRange())
        {
            
        }

    }*/
    private void playercontrol()
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
