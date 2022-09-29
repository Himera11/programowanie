#include <iostream>
using namespace std;

void coordinateTestV1()
{
	int x, y;
	
	cout << "podaj x\n";
	cin >> x;
	cout << "podaj y\n";
	cin >> y;
	double d = sqrt(x*x + y*y);
	
	cout << "odleglosc od (0,0) wynosi " << d;
}

int main()
{
	coordinateTestV1();
}
