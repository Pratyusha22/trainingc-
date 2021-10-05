using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    class student
    {
        int id;
        long[] phoneNumbers = new long[10];
        string name, dateofbirth;
        static string collegeName;
        public student(int id, string name, string dateofbirth, long[] phoneNumbers)
        {
            this.id = id;
            this.name = name;
            this.dateofbirth = dateofbirth;
            this.phoneNumbers = phoneNumbers;
        }
        public int _id
        {
            get { return id; }
            set { id = value; }
        }
        public long[] _phoneNumbers
        {
            get { return phoneNumbers; }
            set { phoneNumbers = value; }
        }
        public string _name
        {
            get { return name; }
            set { name = value; }
        }
        public static string _collegeName
        {
            get { return collegeName; }
            set { collegeName = value; }
        }
        public string _dateofbirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

    }
    class info
    {
        public static void display(student std)
        {
            Console.WriteLine(std._id);
            Console.WriteLine(std._name);
            Console.WriteLine(std._dateofbirth);
            Console.WriteLine(student._collegeName);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(std._phoneNumbers[i]);
            }
            Console.WriteLine();
        }
        public void display_course(Course c)
        {
            Console.WriteLine(c._id);
            Console.WriteLine(c._name);
            Console.WriteLine(c._duration);
            Console.WriteLine(c._fees);
        }
        public void display_enrollment(enroll enroll)
        {

        }
    }
    abstract class Course
    {
        int id;
        string name;
        int duration;
        double fees;
        public Course()
        {

        }
        public Course(int id, string name, int duration, double fees)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;
        }
        public int _id
        {
            get { return id; }
            set { id = value; }
        }
        public int _duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public double _fees
        {
            get { return fees; }
            set { fees = value; }
        }
        public string _name
        {
            get { return name; }
            set { name = value; }
        }
        public abstract double calculateMonthlyFee();

    }
    class App
    {
        static void Main()
        {
            //scenario1();
            //scenario2();
            //scenario3();
            //Scenario4();
            Course c1 = new DegreeCourse(10000);
            Console.WriteLine(c1.calculateMonthlyFee());
            DiplomaCourse c2 = new DiplomaCourse("professional");
            c2.amt = 20000;
            Console.WriteLine(c2.calculateMonthlyFee());
            InMemoryAppEngine im = new InMemoryAppEngine();
        }
        //public static void scenario1()
        //{

        //    student._collegeName = "NSEC";
        //    student s1 = new student(11, "Pratyusha", "22-03-1999", 9873648975);
        //    student s2 = new student(12, "Anjali", "22-03-1998", 7884662781);
        //    student s3 = new student(13, "Anu", "22-03-1997", 4568673521);
        //    info i = new info();
        //    info.display(s1);
        //    info.display(s2);
        //    info.display(s3);


        //}
        //public static void scenario2()
        //{
        //    char[] p1 = { '8', '7', '9', '2', '9', '4', '4', '0', '5', '7' };
        //    char[] p2 = { '7', '7', '9', '2', '9', '4', '4', '0', '5', '7' };
        //    char[] p3 = { '9', '7', '9', '2', '9', '4', '4', '0', '5', '7' };
        //    info i1 = new info();
        //    student[] st = new student[30];
        //    Console.WriteLine("Scenario 2 --->");
        //    st[0] = new student(46, "kunal", "24-03-1999", p1);
        //    info.display(st[0]);
        //    st[1] = new student(45, "liktha", "11-06-1999", p2);
        //    info.display(st[1]);
        //    st[2] = new student(18, "Bharathi", "13-02-1999", p3);
        //    info.display(st[2]);

        //}
        //public static void scenario3()
        //{
        //    student[] s4 = new student[3];
        //    for (int i = 0; i < s4.Length; i++)
        //    {

        //        Console.WriteLine("Please Enter Your Details");

        //        s4[i]._id = int.Parse(Console.ReadLine());
        //        s4[i]._name = Console.ReadLine();
        //        s4[i]._dateofbirth = Console.ReadLine();
        //    }
        //    info i4 = new info();
        //    for (int i = 0; i < s4.Length; i++)
        //    {
        //        info.display(s4[i]);
        //    }

        //}
        //public static void Scenario4()
        //{
        //    int n;
        //    int i;
        //    ArrayList s5 = new ArrayList();
        //    n = Convert.ToInt32(Console.ReadLine());
        //    for ( i = 0; i < n; i++)
        //    {

        //        Console.WriteLine("Please Enter Your Details");

        //        int id = int.Parse(Console.ReadLine());
        //        string name = Console.ReadLine();
        //        string dateofbirth = Console.ReadLine();
        //        int lofPhoneNoList = Convert.ToInt32(Console.ReadLine());
        //        long[] phoneNumbers = new long[lofPhoneNoList];
        //        for (int j = 0; j < lofPhoneNoList; j++)
        //        {
        //            phoneNumbers[j] = long.Parse(Console.ReadLine());
        //        }
        //        s5.Add(new student(i,  name, dateofbirth, phoneNumbers));
        //    }
        //    info ob = new info();

        //    foreach (student s in s5 )
        //    {
        //        info.display(s);
        //    }

        //}

    }

    class DegreeCourse : Course
    {
        enum level { Bachelors, Masters };
        bool isPlacementAvailable = true;
        public double amt { get; set; }
        public DegreeCourse()
        {

        }
        public DegreeCourse(double amt)
        {
            this.amt = amt;
        }
        public override double calculateMonthlyFee()
        {

            if (isPlacementAvailable == true)
            {
                return (amt + (0.01 * amt));
            }
            else
            {
                return amt;
            }
        }
    }
    class DiplomaCourse : Course
    {
        enum type { professional, academic };
        type t;
        public DiplomaCourse(string c)
        {
            if (c == "academic")
            {
                this.t = type.academic;
            }
            if (c == "professional")
            {
                this.t = type.professional;
            }
        }
        public DiplomaCourse()
        {

        }
        public DiplomaCourse(double amt)
        {
            this.amt = amt;

        }
        public double amt { get; set; }


        public override double calculateMonthlyFee()
        {


            if (t == type.professional)
            {
                return amt + (0.1 * amt);
            }
            else
            {
                return amt + (0.05 * amt);
            }

        }





    }
    class enroll
    {
        private Student student;
        private Course course;
        private DateTime enrollmentDate = DateTime.Now;
        public enroll()
        {

        }
        public enroll(Student student, Course course)
        {
            this.student = student;
            this.course = course;
        }
        public DateTime _enrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }
        public Student _student
        {
            get { return student; }
            set { student = value; }
        }
        public Course _course
        {
            get { return course; }
            set { course = value; }
        }
    }
    interface AppEngine
    {
        public void introduce(Course course); 
	 public void register(Student student);
	 public List<Student> listOfStudents();
	 public void enroll(Student student, Course course);
	 public List< enroll> listOfEnrollments();
        public static List<enroll> EnrollDetails;
        public static List<Student> StudentDetails;
        public static List<Course> CourseDetails;
    }
    class InMemoryAppEngine : AppEngine

    {
        public InMemoryAppEngine()
        {
            EnrollDetails = new List<enroll>();
            StudentDetails = new List<Student>();
            CourseDetails = new List<Course>();
        }
        public List<enroll> EnrollDetails { get; }
        public List<Student> StudentDetails { get; }
        public List<Course> CourseDetails { get; }

        public void enroll(Student student, Course course)
        {

            enroll e = new enroll(student, course);
            Console.WriteLine("Successfully Enrolled");
            EnrollDetails.Add(e);
            info i1 = new info();
            i1.display_enrollment(e);
        }

        public void introduce(Course course)
        {
            Console.WriteLine("Course Introduction");
            Console.WriteLine("Course ID " + course._id);
            Console.WriteLine("Course Name " + course._name);
            Console.WriteLine("Course Duration+ " + course._duration);
            CourseDetails.Add(course);
        }

        public List<enroll> listOfEnrollments()
        {
            return EnrollDetails;
        }

        public List<Student> listOfStudents()
        {
            return StudentDetails;
        }

        public void register(Student student)
        {
            StudentDetails.Add(student);
            Console.WriteLine("Student Details Registered Successfully");
        }
    }
    class EnrollmentException : Exception
    {
        public EnrollmentException(string message) : base(message)
        {

        }
    }
}






