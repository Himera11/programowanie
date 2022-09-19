#include <iostream>
using namespace std;

void menu()
{
	system("cls");
	cout << "Menu\n";
	cout << "1. pole kwadratu\n";
	cout << "2. pole trojkata\n";
	cout << "3. Historia bezdomnego\n";
	cout << "4. nieparzyste\n";
	cout << "5. ci¹g fibano\n";
	cout << "6. dzielniki\n";
	cout << "7. liczby slownie\n";
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
void liczbynieparzyste()
{
	int num;
	cout << "ile liczb ";
	cin >> num;
	for (int i = num; i >= 0 ; i--)
	{
		if (i % 2 != 0)
			cout << i << endl;
	}
}

void fibonachi()
{
	int ile;
	cout << "ile";
	cin >> ile;
	long long num1 = 0;
	long long num2 = 1;
	for (int i = 0; i < ile; i++)
	{
		cout << num1 << endl;
		num1 += num2;
		num2 = num1 - num2;
		if (num1 < 0)
		{
			cout << "nope";
		}
	}
}

void dzielniki()
{
	cout << "podaj liczbe ";
	int num;
	cin >> num;
	for (int i = 1; i <= num / 2; i++)
	{
		if (num % i == 0)
			cout << i << endl;
	}
	cout << num;
	cout << endl;
}

void numerynaslowa()
{
	system("cls");
	cout << "Podaj liczbe\n";
	int numberfromuser;
	cin >> numberfromuser;

	string arrrayofword[10] = { "zero", "jeden", "dwa", "trzy", "cztery", "piec", "szesc", "siedem", "osiem", "diewiec", };
	int number = numberfromuser;

	do
	{
		int digit = number % 10;
		number = number / 10;
	
		cout << arrrayofword[digit];
		cout << ", ";

	} while (number != 0);

	number = numberfromuser;
	string stringnumber = "";
	do
	{
		int digit = number % 10;
		number = number / 10;

		stringnumber = arrrayofword[digit] + " " + stringnumber;

	} while (number != 0);

	cout << stringnumber;
	cout << ", ";
}

void end(int selectedOption)
{
	switch (selectedOption)
	{
	case 0:
		return;
	case 1:
		Polekwadratu();
		break;
	case 2:
		Poletrojkata();
		break;
	case 3:
		Historiabezdomnego();
		break;
	case 4:
		liczbynieparzyste();
		break;
	case 5:
		fibonachi();
		break;
	case 6:
		dzielniki();
		break;
	case 7:
		numerynaslowa();
		break;
	default:
		cout << "JOE BIDEN";
	}
	system("pause");
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

