using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Harry_Potter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();

            
            using (StreamReader file = new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] human = ln.Split('\t').ToArray<string>();
                    if (human[1] == "Walker" && human[0] == "Donald")
                    {
                        break;
                    }
                    
                    switch (human[8])
                    {
                        case "teacher":
                            {
                                Teacher teacher = new Teacher();
                                teacher.FirstName = human[0];
                                teacher.LastName = human[1];
                                teacher.DateOfBirthDay = Convert.ToDateTime(human[2]);

                                if (human[3] == "male")
                                {
                                    teacher.GenderType = Person.Gender.male;
                                }
                                else if (human[3] =="female")
                                {
                                    teacher.GenderType= Person.Gender.female;
                                }
                                teacher.FatherName = human[4];
                                teacher.UserName = human[5];
                                teacher.Password = human[6];
                                if (human[7] == "Half blood")
                                {
                                    teacher.racetype = Person.RaceType.Half_blood;
                                }
                                else if (human[7] == "Pure blood")
                                {
                                    teacher.racetype = Person.RaceType.Pure_blood;
                                }
                                else if (human[7] == "Muggle blood")
                                {
                                    teacher.racetype = Person.RaceType.Muggle_blood;
                                }
                                teachers.Add(teacher);
                                break;
                            }
                        case "student":
                            {
                                Student student = new Student();
                                student.FirstName = human[0];
                                student.LastName = human[1];
                                student.DateOfBirthDay = Convert.ToDateTime(human[2]);
                                if (human[3] == "male")
                                {
                                    student.GenderType = Person.Gender.male;
                                }
                                else if (human[3] == "female")
                                {
                                    student.GenderType = Person.Gender.female;
                                }
                                student.FatherName = human[4];
                                student.UserName = human[5];
                                student.Password = human[6];
                                if (human[7] == "Half blood")
                                {
                                    student.racetype = Person.RaceType.Half_blood;
                                }
                                else if (human[7] == "Pure blood")
                                {
                                    student.racetype = Person.RaceType.Pure_blood;
                                }
                                else if (human[7] == "Muggle blood")
                                {
                                    student.racetype = Person.RaceType.Muggle_blood;
                                }
                                students.Add(student);
                                break;
                            }
                    }

                }


                file.Close();
            }
            while (true)
            {
                Console.WriteLine(
                "Choose one:\n" +
                "1.Dumbeldore\n" +
                "2.Teacher\n" +
                "3.Student of Hogwarts\n" +
                "4.Invited/Waiting for Invitation to Hogwarts");

                 int choose = Convert.ToInt32(Console.ReadLine());
                 switch (choose)
                 {
                    case 1:
                       {
                            Console.Write("UserName: ");
                            string adminuser = Console.ReadLine();
                            Console.Write("Password: ");
                            string adminpass = Console.ReadLine();
                            Dumbledore dumbledore = new Dumbledore();
                            dumbledore.UserName = "11111";
                            dumbledore.Password = "00000";

                            if (adminuser == dumbledore.UserName && adminpass == dumbledore.Password)
                            {
                                bool stayadmin = true;
                                while (stayadmin)
                                {
                                    Console.WriteLine("Choose one: " +
                                        "\nSending letters to authorized students (s)" +
                                        "\nExite (e)");
                                     char voroudi = Convert.ToChar(Console.ReadLine());
                                     switch (voroudi)
                                     {
                                        case 's':
                                            {
                                                foreach (Student student in students)
                                                {
                                                    Random random = new Random();
                                                    int day = random.Next(1, 28);
                                                    int Cabin_number = random.Next(1, 10);
                                                    int Seat_number = random.Next(1, 4);

                                                    DateTime now = DateTime.Now;
                                                    int month = now.Month;
                                                    int year = now.Year;
                                                    int nowday = now.Day;
                                                    int nowmonth = now.Month;
                                                    if (nowday > day)
                                                    {
                                                        month = nowmonth + 1;
                                                        if (month > 12)
                                                        {
                                                            year = year + 1;
                                                            month = 1;
                                                        }
                                                    }

                                                    student.Letter = "Congratulations! You have been invited to Hogwarts :)" +
                                                        $"\nDeparture date of your train:{new DateTime(now.Year , month , day )}" +
                                                        $"\nCabin : {Cabin_number}\nSeat : {Seat_number}";
                                                    Console.WriteLine(student.Letter);
                                                }
                                                break;
                                            }
                                        case 'e':
                                            {
                                                 stayadmin = false;
                                                 break;
                                            }

                                        default: { break; }
                                     }
                                }
                                        
                            }
                                

                            break;
                       }
                       case 2:
                       {
                            break;
                       }
                       case 3:
                       {
                            break;
                       }
                       case 4:
                       {
                            break;
                       }

                 }

            }
                
            
            
            Console.ReadKey();

        }
    }
}
