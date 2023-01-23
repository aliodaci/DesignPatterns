using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator   = new Mediator();
            
            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";

            mediator.Teacher= engin;

            Student derin = new Student(mediator);
            derin.Name = "Derin";

            Student salih = new Student(mediator);
            salih.Name = "Salih";
            salih.RecieveSendQuestion("what is name", engin);

            mediator.Students=new List<Student> { derin,salih };

            engin.SendNewImageUrl("Slide1.jpg");
            engin.RecieveQuestion("is it true", salih);
            


            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher:CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator Mediator) : base(Mediator)
        {
        }

        public void RecieveQuestion(string question,Student student)
        {
            Console.WriteLine("Teacher recieve a question from {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(string Url)
        {
            Console.WriteLine("Teacher change slide: {0}", Url);
            Mediator.UpdateImage(Url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}",student.Name,answer);
        }
    }

    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveImage(string Url)
        {
            Console.WriteLine("{1} recieved image:{0}", Url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieve answer {0}", answer);
        }
        public void RecieveSendQuestion(string question,Teacher teacher)
        {
            Console.WriteLine("Student recieve answer : {0}", question,teacher);
        }
        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string Url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(Url);
            }
        }
        
        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
