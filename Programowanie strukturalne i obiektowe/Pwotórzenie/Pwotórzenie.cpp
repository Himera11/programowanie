#include <iostream>
using namespace std;

void menu()
{
	system("cls");
	cout << "Menu\n";
	cout << "1. pole kwadratu\n";
	cout << "2. pole trojkata\n";
	cout << "3. Historia bezdomnego\n";

	cout << "0. zamknij program\n";
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
	cout << "poda pan bok biednemu: ";
	cin >> a;
	cout << "Dzieki ci panie a twe pole wynosi: " << a * a << endl;
}
void Poletrojkata()
{
	float a;
	float b;
	cout << "Poda pan wysokosc dla mnie ubogiego biedneo zlituj sie panie \n";
	cin >> a;
	cout << "bok panie tez daj bo ja biedny taki bardzo tu \n";
	cin >> b;
	cout << "dzieki ci panie niech bogowie beda ci przychylni " << 0.5 * a * b<< endl;
}
void Historia()
{
	system("cls");
	cout << "no mialem se dom i juz nie mam co ja mam powiedziec z domu mnie wykopali bo za duzo kasy na lola wydalem to wiecie, okolo 40 kola wyszlo na lola a no i bronza mialem oczywiscie\n";
}
void koniecHistori()
{
	system("cls");

	cout << "smieciem jestes ja smutny teraz.\n";
}
void Historiabezdomnego()
{
	system("cls");

	cout << "Chcesz us³yszec moja historie:   wybierz liczbe   1_tak/2_nie\n";
	int wybor;
	cin >> wybor;
	
	if (wybor == 1)
	{
		Historia();
	}
	if (wybor == 2)
	{
		koniecHistori();
	}
}


void end(int selectedOption)
{
	switch (selectedOption)
	{
	case 1:
		Polekwadratu();
		break;
	case 2:
		Poletrojkata();
		break;
	case 3:
		Historiabezdomnego();
		break;
	case 0:
		return;
	default:
		cout << "JOE BIDEN";
	}
	if (selectedOption != 0 )
	{
		system("pause");
	}
}

void mainprogram()
{
	int selected;
	do
	{
		menu();
	 selected = option();
	end(selected);
	} while (selected != 0);
}



int main()
{
	mainprogram();
}

