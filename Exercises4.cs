/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.20</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace ExercisesLesson610
{
    class Exercises4
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Shape3D sphere = new Sphere(0, 0, 0, 20);
            Shape3D rect = new Rectangular(0, 0, 0, 30, 40, 50);
            Shape3D cylinder = new Cylinder(0, 0, 0, 50, 20);
            Shape3D trip = new TriangularPrism(0, 0, 0, 60, 30);
            // hiện thông tin của từng hình 2D
            ShowInfo(sphere);
            ShowInfo(cylinder);
            ShowInfo(rect);
            ShowInfo(trip);
        }

        private static void ShowInfo(Shape3D shape)
        {
            Console.WriteLine(shape);
            Console.WriteLine("Diện tích xung quanh: " + shape.SuroundingArea());
            Console.WriteLine("Thể tích: " + shape.Volume());
        }
    }

    // lớp cha trừu tượng
    abstract class Shape3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Shape3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Shape3D(int x, int y, int z) { X = x; Y = y; Z = z; }

        public abstract double SuroundingArea(); // tính diện tích xung quanh
        public abstract double Volume(); // tính thể tích

        public override string ToString()
        {
            return $"Shape[X={X}, Y={Y}, Z={Z}]";
        }
    }

    // lớp mô tả thông tin mặt cầu
    class Sphere : Shape3D
    {
        public double Radius { get; set; }

        public Sphere()
        {
            Radius = 0;
        }

        public Sphere(int x, int y, int z, double radius) : base(x, y, z) { Radius = radius; }

        public override double SuroundingArea()
        {
            return 4 * Radius * Math.PI * Radius;
        }

        public override double Volume()
        {
            return 4 * Math.PI * Radius * Radius * Radius / 3;
        }

        public override string ToString()
        {
            return $"Sphere[X={X}, Y={Y}, Z={Z}, Radius={Radius}]";
        }
    }

    // lớp mô tả thông tin hình hộp chữ nhật
    class Rectangular : Shape3D
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public Rectangular()
        {
            Width = 0;
            Height = 0;
        }

        public Rectangular(int x, int y, int z, double width, double length, double height) : base(x, y, z)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public override double SuroundingArea()
        {
            return 2 * (Width + Length) * Height;
        }

        public override double Volume()
        {
            return Width * Height * Length;
        }

        public override string ToString()
        {
            return $"Rectangle[X={X}, Y={Y}, Z={Z}, Length={Length}, Width={Width}, Height={Height}]";
        }
    }

    // lớp mô tả hình trụ đứng
    class Cylinder : Shape3D
    {
        public double Height { get; set; }
        public double Radius { get; set; }

        public Cylinder()
        {
            Radius = 0;
            Height = 0;
        }

        public Cylinder(int x, int y, int z, double radius, double height) : base(x, y, z)
        {
            Radius = radius;
            Height = height;
        }

        public override double SuroundingArea()
        {
            return 2 * Math.PI * Height * Radius;
        }

        public override double Volume()
        {
            return Math.PI * Radius * Radius * Height;
        }

        public override string ToString()
        {
            return $"Cylinder[X={X}, Y={Y}, Z={Z}, Height={Height}, " +
                $"Radius={Radius}]";
        }
    }

    // lớp mô tả thông tin hình lăng trụ tam giác đều
    class TriangularPrism : Shape3D
    {
        public double EdgeA { get; set; }
        public double EdgeB { get; set; }
        public double EdgeC { get; set; }
        public double Height { get; set; }

        public TriangularPrism()
        {
            EdgeA = 0;
            EdgeB = 0;
            Height = 0;
        }

        public TriangularPrism(int x, int y, int z, double edgeA, double height) : base(x, y, z)
        {
            EdgeB = edgeA;
            EdgeA = edgeA;
            EdgeC = edgeA;
            Height = height;
        }

        public override double SuroundingArea()
        {
            return 3 * Height * EdgeA;
        }

        public override double Volume()
        {
            var p = 0.5 * (EdgeA + EdgeB + EdgeC);
            var area = Math.Sqrt(p * (p - EdgeA) * (p - EdgeA) * (p - EdgeA));
            return Height * area;
        }

        public override string ToString()
        {
            return $"Trapezium[X={X}, Y={Y}, Z={Z}, EdgeA={EdgeA}, EdgeB={EdgeB}, " +
                $"EdgeC={EdgeC}, Height={Height}]";
        }
    }
}
