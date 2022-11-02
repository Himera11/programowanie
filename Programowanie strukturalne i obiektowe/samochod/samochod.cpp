#include <iostream>
using namespace std;
#pragma region struktury
struct Gps
{
    int x, y;
};

struct Direction
{
    int x, y;

};

#pragma endregion

class Car
{
public:
    #pragma region Konstruktory
    Car(string name)
    {
        this->name = name;
        gps.x = 0;
        gps.y = 0;
        direction.x = 1;
        direction.y = 0;
    }
    Car(string name, int x, int y)
    {
        this->name = name;
        gps.x = x;
        gps.y = y;
    }
#pragma endregion

#pragma region voidy
    void showinfo()
    {
        cout << "*****************************************************\n";
            cout << "samochód o nazwie" << name << '\n';
        cout << "Pozycja(" << gps.x <<" : " << gps.y << ")\n";
        cout << "*****************************************************\n";
    }
    void moveForvard()
    {
        gps.x += direction.x;
        gps.y += direction.y;

    } 
    void turnleft()
    {
        int tmpX = direction.x;
        direction.x = -direction.y;
        direction.y = tmpX;
    }

    void turnright()
    {

    }

    void turnback()
    {

    }
   #pragma endregion

protected:

private:
    string name;
    Gps gps;
    Direction direction;
};

int main()
{
    setlocale(LC_CTYPE, "polish");
    Car carv1("JoeBiden");
    Car carv2("JoeBiden.v2", 10, 10);

    carv1.moveForvard();
    carv1.turnleft();
    carv1.moveForvard();

        carv1.showinfo();
        carv2.showinfo();
}
