using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    //class Infotainment
    //{
    //    public string PlayerType { get; set; }
    //    public string Name { get; set; }


    //}

    //class car {

    //    public string ChasiNO { get; set; }
    //    public string  BodyType { get; set; }
    //    public string FuelType { get; set; }
    //    public int NoOfSeats { get; set; }

    //    public  car(Infotainment infotainment)
    //    {
    //      this.Infotainment = infotainment;

    //    }
    //     public void ReplaceInfotainment(Infotainment infotainment)
    //    {

    //    }
    //    public Infotainment Infotainment { get; private set; }

    //    public void Run()
    //    {
    //        Console.WriteLine("Car has Started");
    //        Console.WriteLine("player of the type {0} has started in {1}", Infotainment.PlayerType,Infotainment.Name);
    //    }

    //}

    //class Constructor
    //{

    //    static void Main(string[] args)
    //    {
    //        car Car = new car(new Infotainment { Name="Boat",PlayerType="USB" });
    //        Car.Run();
    //    }
    //}
    class BaseClass {
        public  BaseClass()
        {
            Console.WriteLine("HI from Base class");
        }

        public BaseClass(int no)
        {
            Console.WriteLine("HI from paramterized Constructor");
        }
    }


    class DerivedClass1 : BaseClass
    {
        public  DerivedClass1(int a) : base(a)
        {
            Console.WriteLine("Hi from Derived class without parameter");
        }
    }

    class Constructor {

        static void Main(string[] args)
        {
            int a = utilities.GetNumber("Enter number");
            DerivedClass1 derivedClass1 = new DerivedClass1(a);

        }
    }







}
