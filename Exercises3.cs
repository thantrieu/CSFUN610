/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.20</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace ExercisesLesson610
{
    class Exercises3
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Shape2D circle = new Circle(0, 0, 20);
            Shape2D triangle = new Triangle(0, 0, 30, 40, 50);
            Shape2D rect = new Rectangle(0, 0, 30, 40);
            Shape2D diamond = new Diamond(0, 0, 50, 70, 40);
            Shape2D trap = new Trapezium(0, 0, 70, 40, 45, 60, 30);
            // hiện thông tin của từng hình 2D
            ShowInfo(circle);
            ShowInfo(triangle);
            ShowInfo(rect);
            ShowInfo(diamond);
            ShowInfo(trap);
        }

        private static void ShowInfo(Shape2D shape)
        {
            Console.WriteLine(shape);
            Console.WriteLine("Chu vi: " + shape.Perimeter());
            Console.WriteLine("Diện tích: " + shape.Area());
        }
    }

    // lớp cha trừu tượng
    abstract class Shape2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Shape2D()
        {
            X = 0;
            Y = 0;
        }

        public Shape2D(int x, int y) { X = x; Y = y; }

        public abstract double Area(); // tính chu vi
        public abstract double Perimeter(); // tính diện tích

        public override string ToString()
        {
            return $"Shape[X={X}, Y={Y}]";
        }
    }

    // lớp mô tả thông tin đường tròn
    class Circle : Shape2D
    {
        public double Radius { get; set; }

        public Circle()
        {
            Radius = 0;
        }

        public Circle(int x, int y, double radius) : base(x, y) { Radius = radius; }

        public override double Area()
        {
            return Radius * Math.PI * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle[X={X}, Y={Y}, Radius={Radius}]";
        }
    }

    // lớp mô tả thông tin hình chữ nhật
    class Rectangle : Shape2D
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle()
        {
            Width = 0;
            Height = 0;
        }

        public Rectangle(int x, int y, double width, double height) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Rectangle[X={X}, Y={Y}, Width={Width}, Height={Height}]";
        }
    }

    // lớp mô tả hình tam giác
    class Triangle : Shape2D
    {
        public double EdgeA { get; set; }
        public double EdgeB { get; set; }
        public double EdgeC { get; set; }

        public Triangle()
        {
            EdgeA = 0;
            EdgeB = 0;
            EdgeC = 0;
        }

        public Triangle(int x, int y, double edgeA, double edgeB, double edgeC) : base(x, y)
        {
            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;
        }

        public override double Area()
        {
            var p = 0.5 * (EdgeA + EdgeB + EdgeC);
            return Math.Sqrt(p * (p - EdgeA) * (p - EdgeB) * (p - EdgeC));
        }

        public override double Perimeter()
        {
            return EdgeA + EdgeB + EdgeC + EdgeC;
        }

        public override string ToString()
        {
            return $"Triangle[X={X}, Y={Y}, EdgeA={EdgeA}, " +
                $"EdgeB={EdgeB}, EdgeC={EdgeC}]";
        }
    }

    // lớp mô tả thông tin hình thang
    class Trapezium : Shape2D
    {
        public double EdgeA { get; set; }
        public double EdgeB { get; set; }
        public double EdgeC { get; set; }
        public double EdgeD { get; set; }
        public double Height { get; set; }

        public Trapezium()
        {
            EdgeA = 0;
            EdgeB = 0;
            Height = 0;
        }

        public Trapezium(int x, int y, double edgeA, double edgeB,
            double edgeC, double edgeD, double height) : base(x, y)
        {
            EdgeB = edgeB;
            EdgeA = edgeA;
            EdgeC = edgeC;
            EdgeD = edgeD;
            Height = height;
        }

        public override double Area()
        {
            return EdgeA + EdgeB + EdgeC + EdgeD;
        }

        public override double Perimeter()
        {
            return (EdgeA + EdgeB) * Height * 0.5;
        }

        public override string ToString()
        {
            return $"Trapezium[X={X}, Y={Y}, EdgeA={EdgeA}, EdgeB={EdgeB}, " +
                $"EdgeC={EdgeC}, EdgeD={EdgeD}, Height={Height}]";
        }
    }

    // lớp mô tả thông tin hình thoi
    class Diamond : Shape2D
    {
        public double DiagonaLine1 { get; set; }
        public double DiagonaLine2 { get; set; }
        public double Edge { get; set; }

        public Diamond()
        {
            Edge = 0;
            DiagonaLine1 = 0;
            DiagonaLine2 = 0;
        }

        public Diamond(int x, int y, double edge, double diag1, double diag2) : base(x, y)
        {
            Edge = edge;
            DiagonaLine1 = diag1;
            DiagonaLine2 = diag2;
        }

        public override double Area()
        {
            return 0.5 * DiagonaLine1 * DiagonaLine2;
        }

        public override double Perimeter()
        {
            return 4 * Edge;
        }

        public override string ToString()
        {
            return $"Diamond[X={X}, Y={Y}, Edge={Edge}, " +
                $"DiagonaLine1={DiagonaLine1}, DiagonaLine2={DiagonaLine2}]";
        }
    }
}
