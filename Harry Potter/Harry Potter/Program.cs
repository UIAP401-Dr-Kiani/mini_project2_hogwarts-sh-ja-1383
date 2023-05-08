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
            Dumbledore dumbledore = new Dumbledore();
            dumbledore.UserName = "11111";
            dumbledore.Password = "00000";

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

            foreach (Teacher t in teachers)
            {
                Random random = new Random();
                int x = random.Next(0, 1);
                if (x == 1)
                { t.TeachingAtTheSameTime = true; }
                else
                { t.TeachingAtTheSameTime = false; }
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
                            

                            if (adminuser == dumbledore.UserName && adminpass == dumbledore.Password)
                            {
                                bool stayadmin = true;
                                while (stayadmin)
                                {
                                    Console.WriteLine("Choose one: " +
                                        "\nSending letters to authorized students (s)" +
                                        "\nCheck ticket requests again (c)" +
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
                                                    student.traintime = new DateTime(year, month, day);
                                                    student.Letter = "Congratulations! You have been invited to Hogwarts :)" +
                                                        $"\nDeparture date of your train:{student.traintime}" +
                                                        $"\nCabin : {Cabin_number}\nSeat : {Seat_number}";
                                                }
                                                Console.WriteLine("The letter was successfully sent to all students.");
                                                break;
                                            }

                                        case 'c':
                                            {
                                                int i = 0;
                                                foreach (int x in dumbledore.ticket_request_users)
                                                {
                                                    i++;
                                                    Console.WriteLine(i + " : " + students[x].FirstName + " " + students[x].LastName);
                                                    Console.WriteLine("Do you want to resubmit a ticket? ( yes(y) / no(n) )");
                                                    char vorudi = Convert.ToChar(Console.ReadLine());

                                                    switch (vorudi)
                                                    {
                                                        case 'y':
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
                                                                students[x].traintime = new DateTime(year, month, day);
                                                                students[x].Letter = "Congratulations! You have been invited to Hogwarts :)" +
                                                                    $"\nDeparture date of your train:{students[x].traintime}" +
                                                                    $"\nCabin : {Cabin_number}\nSeat : {Seat_number}";


                                                                Console.WriteLine("Successful!");


                                                                break;
                                                            }
                                                        case 'n':
                                                            {
                                                                dumbledore.ticket_request_users.Remove(x);
                                                                Console.WriteLine("OK");
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                break;
                                                            }
                                                    }
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
                            Console.Write("User Name : ");
                            string username = Console.ReadLine();
                            Console.Write("Password : ");
                            string password = Console.ReadLine();

                            bool checkteacher = false;
                            int whichteacher = 0;
                            foreach (Teacher teacher in teachers)
                            {
                                if (teacher.UserName ==  username && teacher.Password == password)
                                {
                                    checkteacher = true;
                                    break;
                                }
                                whichteacher++;
                            }
                            if (checkteacher)
                            {
                                bool stayteacher = true;
                                while (stayteacher)
                                {
                                    Console.WriteLine($"hello {teachers[whichteacher].FirstName} {teachers[whichteacher].LastName}");
                                    Console.WriteLine("choose one : " +
                                        "\nSetting lesson plans (s)" +
                                        "\nExite (e)");

                                    char vorudi = Convert.ToChar(Console.ReadLine());
                                    switch (vorudi)
                                    {
                                        case 's':
                                            {
                                                // اینو حالا حال ندارم بزنم بعد بزن
                                                break;
                                            }
                                        case 'e':
                                            {
                                                stayteacher = false;
                                                break;
                                            }
                                        default:
                                            { break; }
                                    }
                                }
                            }
                            break;
                       }
                       case 3:
                       {



                            break;
                       }
                       case 4:
                       {
                            Console.Write("UserName : ");
                            string username = Console.ReadLine();
                            Console.Write("Password : ");
                            string password = Console.ReadLine();

                            bool checkstudent = false;
                            int whichstudent = 0;

                            foreach (Student student in students)
                            {
                                if (student.UserName == username && student.Password == password)
                                {
                                    checkstudent = true;
                                    break;
                                }
                                whichstudent++;
                            }

                            if (checkstudent)
                            {
                                bool staystudent = true;
                                while (staystudent)
                                {
                                    Console.WriteLine("Choose One : " +
                                        "\nChecking if you have been invited to hagwarts (c)" +
                                        "\nGo to train (g)" +
                                        "\nExite (e)");

                                    char vorudi = Convert.ToChar(Console.ReadLine()) ;
                                    switch (vorudi)
                                    {
                                        case 'c':
                                            { 
                                                if (students[whichstudent].Letter == null)
                                                {
                                                    Console.WriteLine("Unfortunately, you are not invited.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(students[whichstudent].Letter);
                                                }
                                                break;
                                            }

                                        case 'g':
                                            {
                                                if (students[whichstudent].Letter == null)
                                                {
                                                    Console.WriteLine("Sorry! You cannot use this section becouse you are not invited.");
                                                }
                                                else
                                                {
                                                    if (students[whichstudent].traintime > DateTime.Now)
                                                    {
                                                        Console.WriteLine("Wait for the train to depart.");
                                                    }
                                                    else if (students[whichstudent].traintime == DateTime.Now)
                                                    {
                                                        Console.WriteLine("Get on the train.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("You are on the train going to Hagwarts.");
                                                    }
                                                    else if (students[whichstudent].traintime < DateTime.Now)
                                                    {
                                                        Console.WriteLine("You arrived late. The train has left :( ");
                                                        Console.WriteLine("Do you want to request a new ticket? ( yes(y) / no(n) )");
                                                        char yn = Convert.ToChar(Console.ReadLine());
                                                        switch (yn)
                                                        {
                                                            case 'y':
                                                                {
                                                                    dumbledore.ticket_request_users.Add(whichstudent);
                                                                    Console.WriteLine("Your request done.");
                                                                    break;
                                                                }
                                                            case 'n':
                                                                {
                                                                    Console.WriteLine("Ok!");
                                                                    break;
                                                                }
                                                            default:
                                                                {
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                }
                                                break;
                                            }

                                        case 'e':
                                            {
                                                staystudent = false;
                                                break;
                                            }

                                        default :
                                            { 
                                                break;
                                            }
                                    }



                                }
                            }

                            

                            

                            break;
                       }

                 }

            }
                
            
            
            Console.ReadKey();

        }
    }
}
