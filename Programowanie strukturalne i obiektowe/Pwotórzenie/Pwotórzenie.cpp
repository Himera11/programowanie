#include <iostream>
using namespace std;

void menu()
{
	system("cls");
	cout << "Menu\n";
	cout << "1. pole kwadratu\n";
	cout << "2. pole trojkata\n";
} 

void option()
{
	int selectedOption;
	cout << "wyierz opcje" << endl;
	cin >> selectedOption;
}

void end()
{
	if (selectedOption == 1)
	{
		Polekwadratu();
	}
	if (selectedOption == 2)
	{
		Poletrojkata();
	}
}

void mainprogram()
{
	menu();
	option();
	end();
}



int main()
{
	mainprogram();
}

