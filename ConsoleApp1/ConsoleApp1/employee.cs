using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class employeedet
    {
        int Eid;
        string ename;
        int eage;


        public int _eid { set { Eid = value; } get { return Eid; } }
        public string _ename { set { ename = value; } get { return ename; } }
        public int _eage { set { eage = value; } get { return eage; } }
        public void display()
        {
            Console.WriteLine("employee details");
        }
    }
    class employee
    {
        public static void Main()
        {
            employeedet e = new employeedet();

            e._eid = 10;
            e._ename = "Anu";
            e._eage = 23;


            Console.WriteLine("Employee ID:" + e._eid);
            Console.WriteLine(" Employee Name:" + e._ename);
            Console.WriteLine("Employee Age:" + e._eage);


        }

    }
}
