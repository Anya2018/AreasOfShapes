namespace ClassLibrary1
{

    public static class Program
    {
        static void Main(string[] args)
        {

            double side1 = 0;
            double side2 = 0;
            double side3 = 0;
            double radius = 0;
            double side = 0;
            double length = 0;
            double width = 0;

            UserChoice:
            Console.WriteLine("Площадь какой фигуры вы бы хотели посчитать:\n1. Квадрат\n2. Прямоугольник\n3. Треугольник\n4. Круг");
            Console.Write("Выберите номер ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Впишите сторону квадрата: ");
                    side = double.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Впишите длину прямоугольника ");
                    length = double.Parse(Console.ReadLine());
                    Console.Write("Впишите ширину прямоугольника ");
                    width = double.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Значение стороны треугольника: ");
                    side1 = double.Parse(Console.ReadLine());
                    Console.Write("Значение другой стороны треугольника: ");
                    side2 = double.Parse(Console.ReadLine());
                    Console.Write("Значение 3ей стороны треугольника: ");
                    side3 = double.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Впишите радиус ");
                    radius = double.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Попробуйте еще раз");
                    goto UserChoice;
            }

            CalculateArea Sqa = new Square();
            CalculateArea Rec = new Rectangle();
            CalculateArea Tri = new Triangle();
            CalculateArea Cir = new Circle();
            if (choice == 1)
            {
                Sqa.Area(side);
                Sqa.ShowResult();
            }
            else if (choice == 2)
            {
                Rec.Area(length, width);
                Rec.ShowResult();
            }
            else if (choice == 3)
            {
                Tri.Area(side1, side2, side3);
                Tri.ShowResult();
            }
            else
            {
                Cir.Area(radius);
                Cir.ShowResult();
            }


            ChoiceOfAnotherCalculation:
            Console.Write("\nХотите посчитать площадь другой фигуры? Ответьте Yes или NO: ");
            string choice1 = Console.ReadLine();

            switch (choice1.ToUpper())
            {
                case "YES":
                    goto UserChoice;
                case "NO":
                    break;
                default:
                    Console.WriteLine("Неправильно.Нужно ответить Yes или No");
                    goto ChoiceOfAnotherCalculation;
            }
        }
    }
    class CalculateArea
    {
        public double result;

        public virtual void Area(double side)
        {
        }
        public virtual void Area(double length, double width)
        {
        }
        public virtual void Area(double a, double b, double c)
        {
        }

        public void ShowResult()
        {
            Console.WriteLine($"Площадь фигуры: {result}");
        }
    }
    class Square : CalculateArea
    {

        public override void Area(double side)
        {
            result = side * side;
        }

    }
    class Rectangle : CalculateArea
    {
        public override void Area(double length, double width)
        {
            result = length * width;
        }
    }
    class Triangle : CalculateArea
    {

        public override void Area(double side1, double side2, double side3)
        {
            if ((side1 * side1) + (side2 * side2) == (side3 * side3) || (side1 * side1) + (side3 * side3) == (side2 * side2) || (side2 * side2) + (side3 * side3) == (side1 * side1))
            {
                Console.WriteLine("Это треугольник прямоугольный");
            }
            else
            {
                Console.WriteLine("Это треугольник HE прямоугольный");

            }
            double semiperimeter = (side1 + side2 + side3) / 2;
            result = Math.Sqrt(semiperimeter * (semiperimeter - side1) *
                (semiperimeter - side2) * (semiperimeter - side3));

        }

    }
    class Circle : CalculateArea
    {
        public override void Area(double radius)
        {
            result = 3.14159 * radius * radius;
        }
    }
}