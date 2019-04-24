#include <iostream>


using namespace std;

bool Mission(int teamMember1, int teamMember2, int teamMember3)
{

    if (teamMember1 + teamMember2 + teamMember3 >= 2)
    {
        cout << "Mission Succeed" << endl;
        return true;
    }
    else
    {
        cout << "Mission Failed" << endl;
        return false;
    }
}

void WhoAreSpies(int teamMember1, int teamMember2)
{
    if (teamMember1 + teamMember2 == 0)
    {
        cout << "Congrats，you are right!" << endl;

    }
    else
    {
        cout << "You are wrong." << endl;

    }
}

int main()
{
    int player[5] = {0, 1, 1, 0, 1};

    int teamMember1, teamMember2, teamMember3;
    cout << "You are on the 1st Mission" << endl;
    cout << "Select 1st Team Member(0-4)" << endl;
    cin >> teamMember1;

    cout << "Select 2nd Team Member(0-4)" << endl;
    cin >> teamMember2;

    cout << "Select 3rd Team Member(0-4)" << endl;
    cin >> teamMember3;
    Mission(player[teamMember1], player[teamMember2], player[teamMember3]);

    cout << "You are on the 2nd Mission" << endl;
    cout << "Select 1st Team Member(0-4)" << endl;
    cin >> teamMember1;

    cout << "Select 2nd Team Member(0-4)" << endl;
    cin >> teamMember2;

    cout << "Select 3rd Team Member(0-4)" << endl;
    cin >> teamMember3;
    Mission(player[teamMember1], player[teamMember2], player[teamMember3]);

    cout << "You are on the 3rd Mission" << endl;
    cout << "Select 1st Team Member(0-4)" << endl;
    cin >> teamMember1;

    cout << "Select 2nd Team Member(0-4)" << endl;
    cin >> teamMember2;

    cout << "Select 3rd Team Member(0-4)" << endl;
    cin >> teamMember3;
    Mission(player[teamMember1], player[teamMember2], player[teamMember3]);

    cout << "You are on the 4th Mission" << endl;
    cout << "Select 1st Team Member(0-4)" << endl;
    cin >> teamMember1;

    cout << "Select 2nd Team Member(0-4)" << endl;
    cin >> teamMember2;

    cout << "Select 3rd Team Member(0-4)" << endl;
    cin >> teamMember3;
    Mission(player[teamMember1], player[teamMember2], player[teamMember3]);

    cout << "You are on the 5th Mission" << endl;
    cout << "Select 1st Team Member(0-4)" << endl;
    cin >> teamMember1;

    cout << "Select 2nd Team Member(0-4)" << endl;
    cin >> teamMember2;

    cout << "Select 3rd Team Member(0-4)" << endl;
    cin >> teamMember3;
    Mission(player[teamMember1], player[teamMember2], player[teamMember3]);

    cout << "So who is the a spy ? (0-4)" << endl;
    cin >> teamMember1;

    cout << "Who is the other spy ? (0-4)" << endl;
    cin >> teamMember2;
    WhoAreSpies(player[teamMember1], player[teamMember2]);







    return 0;
}
