using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharpDemoDelegatesAndLambdas
{
    //Definie our delegate to handle our various questions
    delegate string QuestionDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you a patient or a doctor?");
            string userType = Console.ReadLine();

            //Build a List<> of Delegates to call, depending on whether the user is a patient or a doctor
            List<QuestionDelegate> delegateList = new List<QuestionDelegate>();

            //We'll ask for name no matter what, so create a delegate for that
            QuestionDelegate questionDelegate = AskForName;
            delegateList.Add(questionDelegate);

            //Now we'll add different question methods depending on whether you're a patient or a doctor
            if(userType.ToLower() == "patient")
            {
                //Patients will be asked for their birthday and the reason they are seeing the doctor
                questionDelegate = AskForBirthday;
                delegateList.Add(questionDelegate);
                questionDelegate = AskForReasonForVisit;
                delegateList.Add(questionDelegate);
            }
            else
            {
                //Doctors will be asked for their medical license number and their speciality
                questionDelegate = AskForMedicalLicenseNumber;
                delegateList.Add(questionDelegate);
                questionDelegate = AskForSpeciality;
                delegateList.Add(questionDelegate);
            }

            //Now loop through the list and ask the appropriate questions by invoking the methods inside the delegates
            string answer = "";
            foreach(QuestionDelegate del in delegateList)
            {
                answer = del();
            }

            ///*********************************************************************
            //Now demo doing the same thing but with Delegate Chaining
            ///*********************************************************************
            Console.WriteLine("Press any key to do the same thing with Delegate Chaining.");
            Console.ReadKey();

            QuestionDelegate questionDelegate2 = AskForName;
            if (userType.ToLower() == "patient")
            {
                questionDelegate2 += AskForBirthday;
                questionDelegate2 += AskForReasonForVisit;
            }
            else
            {
                questionDelegate2 += AskForMedicalLicenseNumber;
                questionDelegate2 += AskForSpeciality;
            }

            //Now simply execute the delegate, and it will execute all the method you chained together!
            answer = questionDelegate2();

            ///*********************************************************************
            //Now demo doing the same thing but with Anonymous Methods
            ///*********************************************************************
            Console.WriteLine("Press any key to do the same thing with Anonymous Methods.");
            Console.ReadKey();

            //Declare the delegate inline without naming the method (thus the "anonymous")
            QuestionDelegate questionDelegate3 = delegate ()
            {
                Console.WriteLine("What is your name?");
                string inputName = Console.ReadLine();
                return inputName;
            };

            //You can still chain anonymous stuff!
            if (userType.ToLower() == "patient")
            {
                questionDelegate3 += delegate ()
                {
                    Console.WriteLine("What is your birthday?");
                    string inputBirthday = Console.ReadLine();
                    return inputBirthday;
                };

                questionDelegate3 += delegate ()
                {
                    Console.WriteLine("What is the reason for your visit today?");
                    string inputReason = Console.ReadLine();
                    return inputReason;
                };
            }
            else
            {
                questionDelegate3 += delegate ()
                {
                    Console.WriteLine("What is your medical license number?");
                    string inputLicenseNumber = Console.ReadLine();
                    return inputLicenseNumber;
                };

                questionDelegate3 += delegate ()
                {
                    Console.WriteLine("What is your medical speciality?");
                    string inputSpecialty = Console.ReadLine();
                    return inputSpecialty;
                };
            }

            //Excecute all the chained together methods!
            questionDelegate3();

            ///*********************************************************************
            //Now demo doing the same thing but with Lambda Functions
            ///*********************************************************************
            Console.WriteLine("Press any key to do the same thing with Lambda Functions.");
            Console.ReadKey();

            //Declare the delegate inline as a lambda function
            //The lambda format is:  delegate = (input parameters) => { method body / content };
            //Our methods don't have input parameters, so we just use ()
            QuestionDelegate questionDelegate4 = () =>
            {
                Console.WriteLine("What is your name?");
                string inputName = Console.ReadLine();
                return inputName;
            };

            //You can still chain anonymous stuff!
            if (userType.ToLower() == "patient")
            {
                questionDelegate4 += () =>
                {
                    Console.WriteLine("What is your birthday?");
                    string inputBirthday = Console.ReadLine();
                    return inputBirthday;
                };

                questionDelegate4 += () =>
                {
                    Console.WriteLine("What is the reason for your visit today?");
                    string inputReason = Console.ReadLine();
                    return inputReason;
                };
            }
            else
            {
                questionDelegate4 += () =>
                {
                    Console.WriteLine("What is your medical license number?");
                    string inputLicenseNumber = Console.ReadLine();
                    return inputLicenseNumber;
                };

                questionDelegate4 += () =>
                {
                    Console.WriteLine("What is your medical speciality?");
                    string inputSpecialty = Console.ReadLine();
                    return inputSpecialty;
                };
            }

            //Excecute all the chained together methods!
            questionDelegate4();

            ///*********************************************************************
            //Now demo doing the same thing but with Generic Delegates
            ///*********************************************************************
            Console.WriteLine("Press any key to do the same thing with Generic Delegates / Func<>s.");
            Console.ReadKey();

            //Create the question function with a string return type
            //Note that for Funcs the last parameter passed in the generics<> is the output type.  So if you had input types as well,
            //  you'd need to pass those in first - for example, if I had Func<int, string, int, string, string> - that LAST string is the output; all the other
            //  ints and strings are inputs
            Func<string> questionFunction = () =>
            {
                Console.WriteLine("What is your name?");
                string inputName = Console.ReadLine();
                return inputName;
            };

            //You can still chain Funcs!
            if (userType.ToLower() == "patient")
            {
                questionFunction += () =>
                {
                    Console.WriteLine("What is your birthday?");
                    string inputBirthday = Console.ReadLine();
                    return inputBirthday;
                };

                questionFunction += () =>
                {
                    Console.WriteLine("What is the reason for your visit today?");
                    string inputReason = Console.ReadLine();
                    return inputReason;
                };
            }
            else
            {
                questionFunction += () =>
                {
                    Console.WriteLine("What is your medical license number?");
                    string inputLicenseNumber = Console.ReadLine();
                    return inputLicenseNumber;
                };

                questionFunction += () =>
                {
                    Console.WriteLine("What is your medical speciality?");
                    string inputSpecialty = Console.ReadLine();
                    return inputSpecialty;
                };
            }

            //Excecute all the chained together methods!
            questionFunction();

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }


        static string AskForName()
        {
            Console.WriteLine("What is your name?");
            string inputName = Console.ReadLine();
            return inputName;
        }

        static string AskForBirthday()
        {
            Console.WriteLine("What is your birthday?");
            string inputBirthday = Console.ReadLine();
            return inputBirthday;
        }

        static string AskForReasonForVisit()
        {
            Console.WriteLine("What is the reason for your visit today?");
            string inputReason = Console.ReadLine();
            return inputReason;
        }

        static string AskForMedicalLicenseNumber()
        {
            Console.WriteLine("What is your medical license number?");
            string inputLicenseNumber = Console.ReadLine();
            return inputLicenseNumber;
        }

        static string AskForSpeciality()
        {
            Console.WriteLine("What is your medical speciality?");
            string inputSpecialty = Console.ReadLine();
            return inputSpecialty;
        }

    }
}
