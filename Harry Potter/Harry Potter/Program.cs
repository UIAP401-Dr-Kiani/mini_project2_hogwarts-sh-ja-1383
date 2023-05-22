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
            List<Student> invited_students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            List <Student> students = new List<Student>();
            Dumbledore dumbledore = new Dumbledore();
            List<Lesson> all_lessons = new List<Lesson>();
            Botanical botanical = new Botanical();



            using (StreamReader file = new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] human = ln.Split('\t').ToArray<string>();
                    if (human[1] == "Walker" && human[0] == "Donald")
                    {
                        continue;
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
                                invited_students.Add(student);
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
                { t.TeachInSameTime = true; }
                else
                { t.TeachInSameTime = false; }
            }


            while(true)
            {
                Console.WriteLine("Choose one : \n" +
                    "1.in train \n" +
                    "2.in Hagwarts \n" +
                    "3.in resturant");

                int which_environment = Convert.ToInt32(Console.ReadLine());
                switch (which_environment)
                {
                    case 1:
                        {
                            Console.Write("UserName : ");
                            string username = Console.ReadLine();
                            Console.Write("Password : ");
                            string password = Console.ReadLine();

                            bool checkstudent = false;
                            int whichstudent = 0;

                            foreach (Student student in invited_students)
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

                                    char vorudi = Convert.ToChar(Console.ReadLine());
                                    switch (vorudi)
                                    {
                                        case 'c':
                                            {
                                                if (invited_students[whichstudent].Letter == null)
                                                {
                                                    Console.WriteLine("Unfortunately, you are not invited.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(invited_students[whichstudent].Letter);
                                                }
                                                break;
                                            }

                                        case 'g':
                                            {
                                                if (invited_students[whichstudent].Letter == null)
                                                {
                                                    Console.WriteLine("Sorry! You cannot use this section becouse you are not invited.");
                                                }
                                                else
                                                {
                                                    if (invited_students[whichstudent].traintime > DateTime.Now)
                                                    {
                                                        Console.WriteLine("Wait for the train to depart.");
                                                    }
                                                    else if (invited_students[whichstudent].traintime == DateTime.Now)
                                                    {
                                                        Console.WriteLine("Get on the train.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("You are on the train going to Hagwarts.");
                                                        students.Add(invited_students[whichstudent]);
                                                        students[whichstudent].Term = 1;
                                                    }
                                                    else if (invited_students[whichstudent].traintime < DateTime.Now)
                                                    {
                                                        Console.WriteLine("You arrived late. The train has left :( ");
                                                        Console.WriteLine("Do you want to request a new ticket? ( yes(y) / no(n) )");
                                                        char yn = Convert.ToChar(Console.ReadLine());
                                                        switch (yn)
                                                        {
                                                            case 'y':
                                                                {
                                                                    dumbledore.ticket_request_users.Add(whichstudent);
                                                                    invited_students[whichstudent].Letter = null;
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

                                        default:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(
                "Choose one:\n" +
                "1.Dumbeldore\n" +
                "2.Teacher\n" +
                "3.Student of Hogwarts\n");

                            int choose = Convert.ToInt32(Console.ReadLine());
                            switch (choose)
                            {
                                case 1:
                                    {
                                        Console.Write("UserName: ");
                                        string adminuser = Console.ReadLine();
                                        Console.Write("Password: ");
                                        string adminpass = Console.ReadLine();


                                        dumbledore.UserName = "Dumbeldore";
                                        dumbledore.Password = "dumbel_pass";

                                        if (adminuser == dumbledore.UserName && adminpass == dumbledore.Password)
                                        {
                                            bool stayadmin = true;
                                            while (stayadmin)
                                            {
                                                Console.WriteLine("Choose one: " +
                                                    "\nSending letters to authorized students (s)" +
                                                    "\nReview of return ticket requests (r)" +
                                                    "\nCheck ticket requests again (c)" +
                                                    "\nCheck plants requestes (p)" +
                                                    "\nExite (e)");
                                                char voroudi = Convert.ToChar(Console.ReadLine());
                                                switch (voroudi)
                                                {
                                                    case 's':
                                                        {
                                                            foreach (Student student in invited_students)
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

                                                            if (dumbledore.ticket_request_users == null)
                                                            {
                                                                Console.WriteLine("There is not any request! ");
                                                            }


                                                            if (dumbledore.ticket_request_users != null)
                                                                foreach (int x in dumbledore.ticket_request_users)
                                                                {
                                                                    i++;
                                                                    Console.WriteLine(i + " : " + invited_students[x].FirstName + " " + invited_students[x].LastName);
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

                                                                                invited_students[x].cabin_number = Cabin_number;
                                                                                invited_students[x].seat_number = Seat_number;

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
                                                                                invited_students[x].traintime = new DateTime(year, month, day);
                                                                                invited_students[x].Letter = "Congratulations! You have been invited to Hogwarts :)" +
                                                                                    $"\nDeparture date of your train:{invited_students[x].traintime}" +
                                                                                    $"\nCabin : {invited_students[x].cabin_number}\nSeat : {invited_students[x].seat_number}";


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
                                                    case 'p':
                                                        {
                                                            if (dumbledore.ticket_request_users == null)
                                                            {
                                                                Console.WriteLine("There is not any request! ");
                                                            }


                                                            if (dumbledore.reqplnt != null)
                                                            {
                                                                int i = 0;
                                                                foreach (Plant plant in dumbledore.reqplnt)
                                                                {
                                                                    Console.WriteLine($"{i+1}- {plant.Name}");
                                                                    i++;
                                                                }

                                                                Console.Write("Enter the number of the plant : (or Enter e to exite)");
                                                                char plnt = Convert.ToChar(Console.ReadLine());
                                                                while (plnt != 'e')
                                                                {
                                                                    int whichplant = Convert.ToInt32(plnt) - 1;
                                                                    Console.WriteLine("Enter the number of this plant to add to the forest");
                                                                    int numplnt = Convert.ToInt32(Console.ReadLine());
                                                                    if (botanical.all_plants != null)
                                                                    {
                                                                        bool thereisplant = false;
                                                                        foreach (Plant plant in botanical.all_plants)
                                                                        {
                                                                            if (plant.Name == dumbledore.reqplnt[whichplant].Name)
                                                                            {
                                                                                plant.number = numplnt;
                                                                                thereisplant = true;
                                                                            }
                                                                        }
                                                                        if (!thereisplant)
                                                                        {
                                                                            dumbledore.reqplnt[whichplant].number = numplnt;
                                                                            botanical.all_plants.Add(dumbledore.reqplnt[whichplant]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        dumbledore.reqplnt[whichplant].number = numplnt;
                                                                        botanical.all_plants.Add(dumbledore.reqplnt[whichplant]);
                                                                    }

                                                                    Console.Write("Enter the number of the plant : (or Enter e to exite)");
                                                                    plnt = Convert.ToChar(Console.ReadLine());
                                                                }
                                                                
                                                            }
                                                            break;
                                                        }

                                                    case 'r':
                                                        {

                                                            if (dumbledore.back_ticket_request_users == null)
                                                            {
                                                                Console.WriteLine("There is not any request!");
                                                            }

                                                            int i = 0;

                                                            if (dumbledore.back_ticket_request_users != null)
                                                                foreach (int x in dumbledore.back_ticket_request_users)
                                                                {
                                                                    i++;
                                                                    Console.WriteLine(i + " : " + students[x].FirstName + " " + students[x].LastName);
                                                                    Console.WriteLine("Do you accept the request? ( yes(y) / no(n) )");
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
                                                                                students[x].cabin_number = Cabin_number;
                                                                                students[x].seat_number = Seat_number;


                                                                                Console.WriteLine("Successful!");


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
                                        Console.Write("UserName : ");
                                        string username = Console.ReadLine();
                                        Console.Write("Password : ");
                                        string password = Console.ReadLine();

                                        bool checkteacher = false;
                                        int whichteacher = 0;
                                        foreach (Teacher teacher in teachers)
                                        {
                                            if (teacher.UserName == username && teacher.Password == password)
                                            {
                                                checkteacher = true;
                                                break;
                                            }
                                            whichteacher++;
                                        }
                                        if (checkteacher)
                                        {
                                            bool stayteacher = true;

                                            Console.WriteLine($"hello {teachers[whichteacher].FirstName} {teachers[whichteacher].LastName}");
                                            while (stayteacher)
                                            {
                                                Console.WriteLine("choose one : " +
                                                    "\nSetting lesson plans (s)" +
                                                    "\nView the curriculum (v)" +
                                                    "\nCreate practice (c)" +
                                                    "\nGrading the practice (g)" +
                                                    "\nFinal grading (f)" +
                                                    "\nExite (e)");

                                                char vorudi = Convert.ToChar(Console.ReadLine());
                                                switch (vorudi)
                                                {
                                                    case 's':
                                                        {
                                                            Lesson drs = new Lesson();
                                                            Console.Write("Enter the name of the course : ");
                                                            drs.Name = Console.ReadLine();
                                                            Console.Write("Enter class time : ");
                                                            drs.Time = Console.ReadLine();
                                                            drs.Teacher = teachers[whichteacher];

                                                            teachers[whichteacher].AddLesson(drs);
                                                            all_lessons.Add(drs);

                                                            break;
                                                        }

                                                    case 'v':
                                                        {
                                                            teachers[whichteacher].PrintSchedule();
                                                            break;
                                                        }

                                                    case 'c':
                                                        {
                                                            bool bl = true;
                                                            while (bl)
                                                            {

                                                                Plant plnt = new Plant();
                                                                Console.Write("Enter the name of the plant / Exite : ");
                                                                string vrd = Console.ReadLine();

                                                                if (vrd == "Exite")
                                                                {
                                                                    bl = false;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    plnt.Name = vrd;
                                                                    Console.Write("Enter the number of the plant");
                                                                    plnt.number = Convert.ToInt32(Console.ReadLine());
                                                                    botanical.Exercise_plant.Add(plnt);
                                                                }
                                                            }
                                                            break;
                                                        }

                                                    case 'g':
                                                        {
                                                            foreach (Student student in students)
                                                            {
                                                                foreach (Lesson lesson in student.lessons)
                                                                {
                                                                    if (lesson.Teacher == teachers[whichteacher])
                                                                    {
                                                                        if (student.Collected_plants != null)
                                                                        {
                                                                            Console.WriteLine($"{student.FirstName} {student.LastName} :");
                                                                            foreach (Plant plant in student.Collected_plants)
                                                                            {
                                                                                Console.WriteLine($"{plant.Name} : {plant.number}");
                                                                            }
                                                                            Console.Write("Enter the student's score : ");
                                                                            student.gradeplant = Convert.ToInt32(Console.ReadLine());
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        }

                                                    case 'f':
                                                        {
                                                            foreach (Student student in students)
                                                            {
                                                                foreach (Lesson lesson in student.lessons)
                                                                {
                                                                    if (lesson.Teacher == teachers[whichteacher])
                                                                    {
                                                                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                                                                        Console.WriteLine("Enter the final score");
                                                                        lesson.grade = Convert.ToInt32(Console.ReadLine());
                                                                    }
                                                                }
                                                            }
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
                                                Console.WriteLine("Choose one : " +
                                                    "\nView grades of lessons (v)" +
                                                    "\nRequest for a return ticket (r)" +
                                                    "\nDo homework (d)" +
                                                    "\nSee the final score (s)" +
                                                    "\nExite (e)");
                                                char vorudi = Convert.ToChar(Console.ReadLine());

                                                switch (vorudi)
                                                {
                                                    case 'v':
                                                        {
                                                            foreach (Lesson lesson in students[whichstudent].lessons)
                                                            {
                                                                if (lesson.grade >= 0 && lesson.grade <= 100)
                                                                {
                                                                    Console.WriteLine(lesson.grade);
                                                                }
                                                            }

                                                            break;
                                                        }

                                                    case 'r':
                                                        {
                                                            dumbledore.back_ticket_request_users.Add(whichstudent);
                                                            Console.WriteLine("Your request done.");
                                                            break;
                                                        }

                                                    case 'd':
                                                        {
                                                            Console.WriteLine("Plants in practice");
                                                            foreach (Plant plant1 in botanical.Exercise_plant)
                                                            {
                                                                Console.WriteLine($"{plant1.Name} ( *{plant1.number} )");
                                                            }

                                                            int i = 0;
                                                            Console.WriteLine("\n\nPlants in the forest : ");
                                                            foreach (Plant plant in botanical.all_plants)
                                                            {
                                                                Console.WriteLine($"{i}- {plant.Name} ( *{plant.number} )");
                                                            }
                                                            bool x = true;
                                                            while (x)
                                                            {
                                                                Console.WriteLine("Enter the number of the desired plant/ 2.request to add plant / 3.Exite");
                                                                var vrdi = Convert.ToInt32(Console.ReadLine());
                                                                if (vrdi == 3)
                                                                {
                                                                    x = false;
                                                                    break;
                                                                }
                                                                else if (vrdi == 2)
                                                                {
                                                                    Console.WriteLine("Enter the number of the desired plant");
                                                                    int m = Convert.ToInt32(Console.ReadLine());
                                                                    dumbledore.reqplnt.Add(botanical.all_plants[m]);
                                                                }

                                                                else
                                                                {
                                                                    students[whichstudent].Collected_plants.Add(botanical.all_plants[vrdi]);
                                                                    botanical.all_plants[vrdi].number -= 1;

                                                                    Console.WriteLine("The plants added.");

                                                                }
                                                            }

                                                            break;
                                                        }

                                                    case 's':
                                                        {
                                                            int i = 0;
                                                            foreach (Lesson lesson in students[whichstudent].lessons)
                                                            {
                                                                Console.WriteLine($"{i + 1} {lesson.Name}");
                                                                i++;
                                                            }

                                                            Console.Write("Enter the number of the lesson you want to see the grade of : ");
                                                            int numlesson = Convert.ToInt32(Console.ReadLine());
                                                            Console.WriteLine($"Your grade in {students[whichstudent].lessons[numlesson].Name} : {students[whichstudent].lessons[numlesson].grade}");

                                                            break;
                                                        }

                                                    case 'e':
                                                        {
                                                            staystudent = false;
                                                            break;
                                                        }
                                                }

                                            }

                                        }


                                        break;
                                    }
                            }

                            break;
                        }
                    case 3:
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
                                if (students[whichstudent].Term > 1)
                                {
                                    List<Lesson> lessonscanbechoosen = new List<Lesson>();
                                    Console.WriteLine("Enroll lessons");

                                    foreach (Lesson lesson in all_lessons)
                                    {
                                        if (!students[whichstudent].passed_units.Contains(lesson) && !students[whichstudent].lessons.Contains(lesson))
                                        {
                                            lessonscanbechoosen.Add(lesson);
                                        }
                                    }
                                    int i = 0;
                                    foreach (Lesson lesson in lessonscanbechoosen)
                                    {
                                        Console.WriteLine($"{i}- {lesson.Name} : {lesson.Time}");
                                        i++;
                                    }

                                    for (int j = 0; j < 5; j++)
                                    {
                                        Console.Write("Enter the lesson number : ");
                                        int x = Convert.ToInt32(Console.ReadLine());

                                        students[whichstudent].Enroll(lessonscanbechoosen[x]);
                                    }

                                }
                                else
                                {
                                    Random rand = new Random();
                                    for (int j = 0; j < 5; j++)
                                    {
                                        int x = rand.Next(0 , all_lessons.Count);

                                        students[whichstudent].Enroll(all_lessons[x]);
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
