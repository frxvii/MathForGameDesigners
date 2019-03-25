using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPuzzle : MonoBehaviour
{
    public GameObject[] characters = new GameObject[5];
    private bool[] characterID = new bool[5];
    private bool member1;
    private bool member2;
    private bool member3;

    
    
    
    
    void Start()
    {
        ShuffleTheDeck();
        SelectTeamMember();
        MissionFor2(member1, member2);
        SelectTeamMember();
        MissionFor3(member1, member2, member3);
        SelectTeamMember();
        MissionFor2(member1, member2);
        SelectTeamMember();
        MissionFor3(member1, member2, member3);
        SelectTeamMember();
        MissionFor3(member1, member2, member3);

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
    }

    // Mission succeed only if there is no spy in the team
    bool MissionFor3(bool teamMember1, bool teamMember2, bool teamMember3)
    {
        if (teamMember1 && teamMember2 && teamMember3 == true)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

    bool MissionFor2(bool teamMember1, bool teamMember2)
    {
        if (teamMember1 && teamMember2 == true)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

    void SelectTeamMember()
    {

    }
}
