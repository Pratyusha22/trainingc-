using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class vehicle
    {
        public int modelno;

        public vehicle()
        {
            Console.WriteLine("Vehicle constrctor");
        }

        public vehicle(int modelno)
        {
            this.modelno = modelno;
        }
    }
    class HeavyVehicle : vehicle
    {
        public int capacity;
        public HeavyVehicle()
        {
            Console.WriteLine("Heavy Vehicle constrctor");
        }

        public HeavyVehicle(int modelno, int capacity) : base(modelno)
        {
            this.capacity = capacity;
        }
    }
    class Heavyvehicle2 : HeavyVehicle
    {
        public bool license;

        public Heavyvehicle2(bool license, int modelno, int capacity) : base(modelno, capacity)
        {
            this.license = license;
        }
        public Heavyvehicle2()
        {
            Console.WriteLine("Heavy Vehicle 2 constrctor");
        }

    }
    class Class2
    {

        static void Main()
        {
            Heavyvehicle2 HV = new Heavyvehicle2();

            Heavyvehicle2 hv = new Heavyvehicle2(true, 1234, 8);
            Console.WriteLine("Model No:" + hv.modelno);
            Console.WriteLine("Capacity:" + hv.capacity);
            Console.WriteLine("License:" + hv.license);
        }
    }

}
