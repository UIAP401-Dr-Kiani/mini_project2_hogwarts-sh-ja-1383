using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Teacher : Authorized_Persons
    {
        public bool TeachInSameTime { get; set; }
        public List <Lesson> Lessons { get; set; }

        public bool CanTeach;
        
        public void AddLesson (Lesson lesson)
        {
            if (!TeachInSameTime)
            {
                foreach (Lesson lesson1 in Lessons)
                {
                    if (lesson.Time == lesson1.Time)
                    {
                        CanTeach = false; break;
                    }
                }
            }
            else
            {
                CanTeach = true;
            }

            if (CanTeach)
            {
                Lessons.Add (lesson);
                Console.WriteLine($"{FirstName} {LastName} added {lesson.Name}");
            }
            else
            {
                Console.WriteLine($"{lesson.Name} cannot teach.");
            }
        }

        public void PrintSchedule()
        {
            Console.WriteLine("Your class schedule : ");
            foreach (Lesson lesson in Lessons)
            {
                Console.WriteLine($"{lesson.Time} : {lesson.Name}");
            }
        }



    }
}
