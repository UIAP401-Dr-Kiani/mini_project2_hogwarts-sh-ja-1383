using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Student : Authorized_Persons
    {
        public List<Lesson> passed_units {  get; set; }
        public List<Lesson> lessons { get; set; }
        public int Term { get; set; }
        public int RoomNumber { get; set; }
        public DateTime traintime { get; set; }
        public int cabin_number { get; set; }
        public int seat_number { get; set; }
        public List <Plant> Collected_plants { get; set; }
        public int gradeplant { get; set; }

        
        public void Enroll (Lesson lesson)
        {
            if (lesson.StudentCount < lesson.Capacity)
            {
                bool canchoose = true;
                foreach (Lesson lesson1 in lessons)
                {
                    if (lesson1.Time == lesson.Time)
                    {
                        canchoose = false;
                        break;
                    }
                }

                if (canchoose)
                {
                    lesson.StudentCount++;
                    lessons.Add(lesson);
                    Console.WriteLine($"you enrolled in {lesson.Name}.");
                    lesson.Students.Add(this);
                }
                else
                {
                    Console.WriteLine($"you Cannot enroll in {lesson.Name}");
                }
            }
            else
            {
                Console.WriteLine($"you Cannot enroll in {lesson.Name}");
            }
        }


        public void PrintSchedule ()
        {
            Console.WriteLine($"Schadule Term {Term} : ");
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"{lesson.Time} : {lesson.Name}");
            }
        }
    }
}
