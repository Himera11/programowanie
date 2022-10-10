#include <iostream>
using namespace std;

int globalvariable = 7;

void AnotherFuction(int parametr)
{
    int anotherLocalVariableInFuction = 6;
    parametr = 12;
    globalvariable = 8;
}

void TestFunction()
{
    int localVariableInFunction = 5;
    AnotherFuction(localVariableInFunction);
    globalvariable = 40;
}

int main()
{


    /*int localVariableInMain = 8;
    TestFunction
    globalvariable = 77;*/
    int number = 77;

    int* wsk = new int;
    cout << wsk << endl;
    *wsk = 7;

    cout << wsk << endl;
    // number bedszie równy 14.
    number = *wsk * 2;
    cout << number << endl;

    delete wsk;
    wsk = NULL;

    
    cout << "#######################################################" << endl;
    int tab[3];
    tab[0] = 5;
    *(tab + 0) = 5;
    tab[1] = 15;
    *(tab + 1) = 15;
    tab[2] = 15;
    *(tab + 2) = 15;
    cout << "Adres zerowego elementu tablicy \t"<< tab << endl;
    cout << "Adres pierwszego elementu tablicy \t" << tab + 1 << endl;

    int tab2[14];
    const int rozmiar = 5;
    // int tab3[number];
    int tab4[rozmiar];

    int* tab5 = new int[number];
    tab5[7] = 15;
    *(tab5 + 7) = 15;

    delete tab5;
    tab5 = new int[number];
    delete tab5;
}

