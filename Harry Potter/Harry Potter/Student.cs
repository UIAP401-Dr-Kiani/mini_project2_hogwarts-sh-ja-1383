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

        
        public void Enroll (Lesson lesson)
        {
            if (lesson.StudentCount < lesson.Capacity && lesson.Term <= Term)
            {
                lesson.StudentCount++;
                lessons.Add(lesson);
                Console.WriteLine($"{FirstName} {LastName} enrolled in {lesson.Name}.");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName} Cannot enroll in {lesson.Name}");
            }
        }


        public void PrintSchedule ()
        {
            Console.WriteLine($"Schadule for {FirstName} {LastName} (Term {Term}) : ");
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"{lesson.Time} : {lesson.Name}");
            }
        }
    }
}
