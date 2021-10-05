using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    
    
        class Department
        {
        int ID=10;
        string Name;
 
        public string deptloc;
        public string company { get; set; }
 
        public int _ID
        {
             get { return ID; }
        }
        public string _name
        {
            set { Name = value; }
            get { return Name; }
        }
 
        //public void setID(int id)
        //{
        //    ID = id;
        //}
        //public int GetID()
        //{
        //    return ID;
        //}
        //public void setname(string name)
        //{
        //    Name = name;
        //}
        //public string getname()
        //{
        //    return Name;
        //}
 
        public void Display()
        {
            Console.WriteLine("id =" + ID);
        }
 
 
    }
    class Dep
    {
        static void Main()
        {
            Department dept = new Department();


            dept._name="HR";
            dept.deptloc = "Hyderabad";
            dept.Display();

            Console.WriteLine("ID:" + dept._ID);
            Console.WriteLine("Name:" + dept._name);
 

        }

    }
    
}
