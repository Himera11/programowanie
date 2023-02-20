using ShapeConsoleApp.Shapes;
using System;


namespace ShapeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle firstRectangle = new Rectangle("Prostokąt 1");
            firstRectangle.ShowInfo();

            Rectangle secondRectangle = new Rectangle("Prostokąt 2", 54, 99);
            secondRectangle.ShowInfo();
            

            Square firstSquare = new Square("Kwadrat Marcin");
            firstSquare.ShowInfo();
        }
    }
}
