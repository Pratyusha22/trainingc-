using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class EnrollmentException : Exception
    {
        public EnrollmentException(string message):base(message)
        {

        }
    }
     public class Student
    {
        int id;
        long[] phoneNumbers = new long[2];
        string name;
        DateTime dateofbirth;
        static string collegeName;
        static Student()
        {
            collegeName = "NSEC";
        }
        public Student(int id,string name,DateTime dateofbirth,long[] phoneNumbers)
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
        public DateTime _dateofbirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

    }
    class info
    {
        public static void display(Student student)
        {
            Console.WriteLine(student._id);
            Console.WriteLine(student._name);
            Console.WriteLine(student._dateofbirth);
            Console.WriteLine(Student._collegeName);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(student._phoneNumbers[i]);
            }

            Console.WriteLine("----------------------");
        }
        public void display_course(Course course)
        {
            Console.WriteLine(course._id);
            Console.WriteLine(course._name);
            Console.WriteLine(course._duration);
            Console.WriteLine(course._fees);
        }
        public void display_enrollment(Enroll enroll)
        {
            Console.WriteLine(enroll._student._id);
            Console.WriteLine(enroll._student._name);
            Console.WriteLine(enroll._student._dateofbirth);
            Console.WriteLine(Student._collegeName);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(enroll._student._phoneNumbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine(enroll._course._id);
            Console.WriteLine(enroll._course._name);
            Console.WriteLine(enroll._course._duration);
            Console.WriteLine(enroll._course._fees);
            Console.WriteLine(enroll._enrollmentDate);
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }
    }
    public abstract class Course
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


        public abstract void calculateMonthlyFee();
    }

    class DegreeCourse : Course
    {
        bool isPlacementAvailable;
        public DegreeCourse()
        {
                
        }
        public DegreeCourse(bool isPlacementAvailable, int id, string name, int duration, double fees) : base(id, name, duration, fees)
        {
            this.isPlacementAvailable = isPlacementAvailable;
        }
        enum level { Bachelors, Masters };
        public bool _isPlacementAvailable
        {
            get { return isPlacementAvailable; }
            set { isPlacementAvailable = value; }
        }
        public override void calculateMonthlyFee()
        {
            if (isPlacementAvailable) { 
            _fees= _fees+(0.1*_fees);
            }
            else
            {
                _fees= _fees;
            }
        }

    }
    class DiplomaCourse : Course
    {

        public DiplomaCourse()
        {
            
        }
        public DiplomaCourse(int id, string name, int duration, double fees) : base(id, name, duration, fees)
        {

        }
        enum type { professional, academic };
        public override void calculateMonthlyFee()
        {
            Console.WriteLine("What's the type of Course?Professional or academic");
            string s = Console.ReadLine();
            if (s==type.professional.ToString())
            {
                _fees= _fees + (0.1 * _fees);
            }
            else if(s == type.academic.ToString())
            {
                _fees= _fees + (0.05 * _fees);
            }
        }
    }
    public class Enroll
    {
        private Student student;
        private Course course;
        private DateTime enrollmentDate=DateTime.Now;
        public Enroll()
        {

        }
        public Enroll(Student student,Course course)
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
        public  List<Student> listOfStudents();
        public void enroll(Student student, Course course);
        public List<Enroll> ListOfEnrollments();
        public static List<Enroll> EnrollDetails;
        public static List<Student> StudentDetails;
        public static List<Course> CourseDetails;
    }
    class InMemoryAppEngine : AppEngine
    {
        public InMemoryAppEngine()
        {
            EnrollDetails = new List<Enroll>();
            StudentDetails = new List<Student>();
            CourseDetails = new List<Course>();
        }

        public List<Enroll> EnrollDetails { get; }
        public List<Student> StudentDetails { get; }
        public List<Course> CourseDetails { get; }

        public void enroll(Student student, Course course)
        {
           
            Enroll e = new Enroll(student, course);
            Console.WriteLine("Successfully Enrolled");
            EnrollDetails.Add(e);
            info i1 = new info();
            i1.display_enrollment(e);
        }

        public void introduce(Course course)
        {
            Console.WriteLine("Course Introduction");
            Console.WriteLine("Course ID "+course._id);
            Console.WriteLine("Course Name "+course._name);
            Console.WriteLine("Course Duration+ "+course._duration);
            CourseDetails.Add(course);
        }

        public List<Enroll> ListOfEnrollments()
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
    class App
    {
        static void Main() {
            //scenario1();
            //scenario2();
            //scenario3();
            //scenario4(); 
            int id,t,d;
            char c;
            double fee;
            string name;
            DateTime dob,ed;
            long ph1, ph2;
            bool place;
            long[] ph = new long[2];
            ArrayList s = new ArrayList();
            ArrayList cs = new ArrayList();
            info i = new info();
            InMemoryAppEngine im = new InMemoryAppEngine();
            do
            {
                Console.WriteLine("Enter student id");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter student name");
                name = Console.ReadLine();
                Console.WriteLine("Enter student date of birth in DD-MM-YYYY");
                dob = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter student phone number");
                ph1 = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter another phone number");
                ph2 = long.Parse(Console.ReadLine());
                ph[0] =  ph1;
                ph[1] = ph2;
                Student st = new Student(id, name, dob, ph);
                s.Add(st);
                Console.WriteLine("Enter course id");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter course name");
                name = Console.ReadLine();
                Console.WriteLine("Enter course duration");
                d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter course fee");
                fee = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Type 1 for Degree Course, aby other number  for Diploma Course");
                t = Convert.ToInt32(Console.ReadLine());
                if (t == 1)
                {
                    Console.WriteLine("Type true for placement false for no placement");
                    place = Convert.ToBoolean(Console.ReadLine());
                    DegreeCourse dc = new DegreeCourse(place, id, name, d, fee);
                    dc.calculateMonthlyFee();
                    im.enroll(st, dc);
                    im.introduce(dc);
                    im.register(st);
                }
                else
                {
                    DiplomaCourse dp = new DiplomaCourse(id,name, d, fee);
                    dp.calculateMonthlyFee();
                    im.enroll(st, dp);
                    im.introduce(dp);
                    im.register(st);
                }
                Console.WriteLine("Press q to quit or anyother key to continue");
                c = Convert.ToChar(Console.ReadLine());
            }while (c != 'q') ;
            List<Student> ls = im.listOfStudents();
            List<Enroll> en = im.ListOfEnrollments();
            Console.WriteLine("++++++++++");
            foreach (Enroll e in en)
            {
                i.display_enrollment(e);
                Console.WriteLine("***********Enrollment Data End**************");
            }

        }
        static void scenario1()
        {
            long[] ph1 = { 9841001489, 7792824545 };
            long[] ph2 = { 9841001489, 7792824545 };
            long[] ph3 = { 9841001489, 7792824545 };
            DateTime date1 = new DateTime(2015, 12, 25);
            DateTime date2 = new DateTime(2016, 10, 5);
            DateTime date3 = new DateTime(2015, 9, 20);
            Student s1 = new Student(10, "Pratyusha",date1 ,ph1);
            Student s2 = new Student(11, "Anjali", date2,ph2);
            Student s3 = new Student(12, "Sayan", date3,ph3);
            info i = new info();
            info.display(s1);
            info.display(s2);
            info.display(s3);
        }
        static void scenario2()
        {
            long[] ph1 = { 9841001489, 7792824545 };
            long[] ph2 = { 9841001489, 7792824545 };
            long[] ph3 = { 9841001489, 7792824545 };
            DateTime date1 = new DateTime(2015, 12, 25);
            DateTime date2 = new DateTime(2016, 10, 5);
            DateTime date3 = new DateTime(2015, 9, 20);
            Student._collegeName = "NSEC";
            Student s1 = new Student(10, "Pratyusha", date1, ph1);
            Student s2 = new Student(11, "Anjali", date2, ph2);
            Student s3 = new Student(12, "Sayan", date3, ph3);
            Student[] s = { s1, s2, s3 };
            for (int i = 0; i < 3; i++)
            {
                info.display(s[i]);
            }
        }
        static void scenario3()
        {
            int ind=0;
            int id;
            string name;
            DateTime dob;
            long ph1, ph2;
            Student[] s = new Student[3];
            while (ind<3)
            {
                Console.WriteLine("Enter student id");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter student name");
                name =Console.ReadLine();
                Console.WriteLine("Enter student date of birth in MM/DD/YYYY");
                dob = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter student phone number");
                ph1 =long.Parse(Console.ReadLine());
                Console.WriteLine("Enter another phone number");
                ph2 = long.Parse(Console.ReadLine());
                long[] ph = { ph1, ph2 };
                Student st = new Student(id, name, dob, ph);
                s[ind] = st;
                ind++;
            }
            info i1= new info();
            
            for(int i = 0; i < 3; i++)
            {
                info.display(s[i]);
            }
        }
        static void scenario4()
        {
            long[] ph1 = { 9841001489, 7792824545 };
            long[] ph2 = { 9841001489, 7792824545 };
            long[] ph3 = { 9841001489, 7792824545 };
            DateTime date1 = new DateTime(2015, 12, 25);
            DateTime date2 = new DateTime(2016, 10, 5);
            DateTime date3 = new DateTime(2015, 9, 20);
            Student._collegeName = "NSEC";
            Student s1 = new Student(10, "Pratyusha", date1, ph1);
            Student s2 = new Student(11, "Anjali", date2, ph2);
            Student s3 = new Student(12, "Sayan", date3, ph3);
            ArrayList arr = new ArrayList();
            arr.Add(s1);
            arr.Add(s2);
            arr.Add(s3);
            info i = new info();
            foreach(Student s in arr)
            {
                info.display(s);
            }
            DiplomaCourse c = new DiplomaCourse(200, "C#", 30, 50000);
            i.display_course(c);
        }
    }
}
