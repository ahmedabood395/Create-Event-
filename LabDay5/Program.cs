using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LabDay5
{
    
    public class Time : EventArgs
    {
        public DateTime date { get; set; }
        public Time(DateTime date)
        {
            this.date = date;
        }
    }
    enum Exam_Mode
    {
        start,end
    }
    class Exam
    {
        public int id { get; set; }
        public int time { get; set; }
        public string subName { get; set; }

        public Exam_Mode exam_mode { get; set; }

        public event EventHandler<Time> StartExam;
        public Exam(int id,int time,string subName,Exam_Mode exam_mode)
        {
            this.id = id;
            this.time = time;
            this.subName = subName;
            this.exam_mode = exam_mode;

            StartExam += Students.Student_Start;
            StartExam += Staff.Staff_Start;
            StartExam(this, new Time(DateTime.Now));

        }
        public override string ToString()
        {
            return $"Exame ID={id},Exam Time={time},Exam Name={subName}";
        }
    }
    class Students
    {
        public static void Student_Start(object o,Time t)
        {
            Exam ex = o as Exam;
            if (ex!=null)
            {
                Console.WriteLine($"The Student Start Exam \n{o.ToString()} And start in ={t.date}");
            }
            
        }
    }
    class Staff
    {
        public static void Staff_Start(object o, Time t)
        {
            Exam ex = o as Exam;
            if (ex != null)
            {
                Console.WriteLine($"The Staff Start Exam \n{o.ToString()} And start in ={t.date}");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exam ex = new Exam(1, 50, "Math", Exam_Mode.start);

            Action<object, Time> d = Students.Student_Start;
            d(ex, new Time(DateTime.Now));
            Action<object, Time> d2 = Staff.Staff_Start;
            d2(ex, new Time(DateTime.Now));


        }
    }
}
