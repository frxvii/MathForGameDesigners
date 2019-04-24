
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LogicPuzzle : MonoBehaviour
{
    public Toggle[] players = new Toggle[5];
    private bool[] characterID;
    public List<bool> togglesOn = new List<bool>();
    
    private bool member1;
    private bool member2;
    private bool member3;

    private int member1Index =5 , member2Index =5, member3Index =5;
    
    
    
    void Start()
    {
        bool[] characterID = new bool[5]{true, true, true, true, true};
        int i = Random.Range(0, 5);
        characterID[i] = false;
        int n = Random.Range(0, 5);
        while (n == i)
        {
            n = Random.Range(0, 5);
        }
        characterID[n] = false;
        //Debug.Log(characterID[0]);
        //Debug.Log(characterID[1]);
        //Debug.Log(characterID[2]);
        //Debug.Log(characterID[3]);
        //Debug.Log(characterID[4]);
        Select1stTeamMembers();
        
        
        Select2ndTeamMembers();
        
        if (member1Index < 5 && member2Index <5)
        {
            MissionOne(characterID[member1Index],characterID[member2Index]);
        }

        
        
        //MissionTwo(member1, member2, member3);
        
        //MissionThree(member1, member2);
        
        //MissionFour(member1, member2, member3);
        
        //MissionFive(member1, member2, member3);
        
        

    }

    void Update()
    {

    }


    
    // Randomly assign role to 5 characters, true = Resistance, false = Spy
    // Make sure when the game starts, we always have 3 Resistance, 2 spies.
    void ShuffleTheDeck()
    {
        bool[] characterID = new bool[5]{true, true, true, true, true};
        int i = Random.Range(0, 5);
        characterID[i] = false;
        int n = Random.Range(0, 5);
        while (n == i)
        {
            n = Random.Range(0, 5);
        }
        characterID[n] = false;
        Debug.Log(characterID[0]);
        Debug.Log(characterID[1]);
        Debug.Log(characterID[2]);
        Debug.Log(characterID[3]);
        Debug.Log(characterID[4]);
    }

    // Mission succeed only if there is no spy in the team
    

    bool MissionOne(bool teamMember1, bool teamMember2)
    {
        if (teamMember1 && teamMember2 == true)
        {
            Debug.Log("Mission One Secceed");
            return true;
        }
        else
        {
            Debug.Log("Mission One Failed");
            return false;
        } 
    }
    bool MissionTwo(bool teamMember1, bool teamMember2, bool teamMember3)
    {
        System.Console.WriteLine("Select your team members");
        
        if (teamMember1 && teamMember2 && teamMember3 == true)
        {
            Debug.Log("Mission Two Secceed");
            return true;
        }
        else
        {
            Debug.Log("Mission Two Failed");
            return false;
        } 
    }
    bool MissionThree(bool teamMember1, bool teamMember2)
    {
        if (teamMember1 && teamMember2 == true)
        {
            Debug.Log("Mission Three Secceed");
            return true;
        }
        else
        {
            Debug.Log("Mission Three Failed");
            return false;
        } 
    }
    bool MissionFour(bool teamMember1, bool teamMember2, bool teamMember3)
    {
        System.Console.WriteLine("Select your team members");
        
        if (teamMember1 && teamMember2 && teamMember3 == true)
        {
            Debug.Log("Mission Four Secceed");
            return true;
        }
        else
        {
            Debug.Log("Mission Four Failed");
            return false;
        } 
    }
    bool MissionFive(bool teamMember1, bool teamMember2, bool teamMember3)
    {
        System.Console.WriteLine("Select your team members");
        
        if (teamMember1 && teamMember2 && teamMember3 == true)
        {
            Debug.Log("Mission Five Secceed");
            return true;
        }
        else
        {
            Debug.Log("Mission Five Failed");
            return false;
        } 
    }

    void Select1stTeamMembers()
    {
        Debug.Log("Select 1st Team Members by pressing 0-4");
        
        if (Input.GetKey (KeyCode.Alpha0))
        {
            member1Index = 0;
        }
        if (Input.GetKey (KeyCode.Alpha1))
        {
            member1Index = 1;
        }
        if (Input.GetKey (KeyCode.Alpha2))
        {
            member1Index = 2;
        }
        if (Input.GetKey (KeyCode.Alpha3))
        {
            member1Index = 3;
        }
        if (Input.GetKey (KeyCode.Alpha4))
        {
            member1Index = 4;
        }
        
        Debug.Log("Your Choice is " + member1Index);
    }
    void Select2ndTeamMembers()
    {
        Debug.Log("Select 2nd Team Members by pressing 0-4");
        if (Input.GetKey (KeyCode.Alpha0))
        {
            member2Index = 0;
        }
        if (Input.GetKey (KeyCode.Alpha1))
        {
            member2Index = 1;
        }
        if (Input.GetKey (KeyCode.Alpha2))
        {
            member2Index = 2;
        }
        if (Input.GetKey (KeyCode.Alpha3))
        {
            member2Index = 3;
        }
        if (Input.GetKey (KeyCode.Alpha4))
        {
            member2Index = 4;
        }
        Debug.Log("Your Choice is " + member2Index);
    }
    void Select3rdTeamMembers()
    {
        Debug.Log("Select 3rd Team Members by pressing 0-4");
        if (Input.GetKey (KeyCode.Alpha0))
        {
            member3Index = 0;
        }
        if (Input.GetKey (KeyCode.Alpha1))
        {
            member3Index = 1;
        }
        if (Input.GetKey (KeyCode.Alpha2))
        {
            member3Index = 2;
        }
        if (Input.GetKey (KeyCode.Alpha3))
        {
            member3Index = 3;
        }
        if (Input.GetKey (KeyCode.Alpha4))
        {
            member3Index = 4;
        }
        Debug.Log("Your Choice is " + member3Index);
        
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }

}
