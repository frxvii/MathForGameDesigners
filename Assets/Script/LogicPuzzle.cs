using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicPuzzle : MonoBehaviour
{
    public Button[] characters = new Button[5];
    private bool[] characterID = new bool[5];
    public int[] buttonOnClick = new int[5]{0, 0, 0, 0, 0};
    
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

    void Update()
    {
        Debug.Log(buttonOnClick[0]);
        Debug.Log(buttonOnClick[1]);
        Debug.Log(buttonOnClick[2]);
        Debug.Log(buttonOnClick[3]);
        Debug.Log(buttonOnClick[4]);
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
        int total = buttonOnClick[0] + buttonOnClick[1] + buttonOnClick[2] + buttonOnClick[3] +buttonOnClick[4];
        characters[0].onClick.AddListener(Button0);
        
        characters[1].onClick.AddListener(Button1);
        
        characters[2].onClick.AddListener(Button2);
        
        characters[3].onClick.AddListener(Button3);
        
        characters[4].onClick.AddListener(Button4);
    }

    void Button0()
    {
        buttonOnClick[0] = 1;
    }
    void Button1()
    {
        buttonOnClick[1] = 1;
    }
    void Button2()
    {
        buttonOnClick[2] = 1;
    }
    void Button3()
    {
        buttonOnClick[3] = 1;
    }
    void Button4()
    {
        buttonOnClick[4] = 1;
    }
}
