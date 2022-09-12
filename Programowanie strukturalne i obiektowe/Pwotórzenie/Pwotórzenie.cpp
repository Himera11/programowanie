#include <iostream>
using namespace std;

void menu()
{
	system("cls");
	cout << "Menu\n";
	cout << "1. pole kwadratu\n";
	cout << "2. pole trojkata\n";
} 

int option()
{
	cout << "wyierz opcje" << endl;
	int selectedOption;
	cin >> selectedOption;
	return selectedOption;
}

void Polekwadratu()
{
	float a;
	cout << "poda pan bok biednemu: \n";
	cin >> a;
	cout << "Dzieki ci panie a twe pole wynosi: " << a * a;
}
void Poletrojkata()
{
	float a;
	float b;
	cout << "Poda pan wysokosc dla mnie ubogiego biedneo zlituj sie panie \n";
	cin >> a;
	cout << "bok panie tez daj bo ja biedny taki bardzo tu \n";
	cin >> b;
	cout << "dzieki ci panie niech bogowie beda ci przychylni " << 0.5 * a * b;
}

void end(int selectedOption)
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
	
	int selected = option();
	end(selected);
}



int main()
{
	mainprogram();
}

