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
            using (StreamReader file = new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] human = ln.Split('\t').ToArray<string>();
                    
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
                }
                
                file.Close();
            }
            
            
            Console.ReadKey();

        }
    }
}
