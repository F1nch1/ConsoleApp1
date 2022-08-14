using System;
using System.Linq;

namespace ConsoleApp1
{
    class MainFile
    {
        bool playing = true;
        string[] quitInputs = { "x", "X", "quit", "Quit" };
        string[] yesInputs = { "yes", "Yes", "y", "Y", "ye", "Ye", "yeah", "Yeah" };
        string[] noInputs = { "no", "No", "n", "N", "nah", "Nah", "nope", "Nope" };
        Cat temporaryCat;
        Cat leader;
        static void Main(string[] args)
        {
            MainFile program = new MainFile();
            program.MainLoop();
        }

        public void MainLoop()
        {
            while (playing)
            {
                Setup();
            }
        }

        public void CheckQuit(string input)
        {
            if (quitInputs.Contains(input))
            {
                playing = false;
                System.Environment.Exit(1);
            }
        }

        public void Setup()
        {
            if(leader.name == null)
            {
                leader = CreateLeader();
            }
            
        }

        public Cat CreateLeader()
        {
            //Naming
            Console.WriteLine("What is your leader's name? (Prefix only)");
            string name = GetNameLoner();
            name =  name.First().ToString().ToUpper() + name.Substring(1);

            //Age
            Console.WriteLine("How old is your leader? (In moons)");
            int age = GetAge();

            //Gender
            Console.WriteLine("What is your leader's gender?");
            Defs.Gender gender = GetGender();

            //Rank
            Defs.Rank rank = Defs.Rank.Loner;

            //Temporary cat
            Cat tempCat = new Cat(name, "", rank, gender, age);

            bool check = CheckError(tempCat);
            while (!check)
            {
                check = CheckError(temporaryCat);
                tempCat = temporaryCat;
            }
            
            return tempCat;
        }

        public bool CheckError(Cat cat)
        {
            string input = "";

            while (!yesInputs.Contains(input) && !noInputs.Contains(input))
            {
                Console.WriteLine("You've created your cat! Are the following values correct?");
                Console.WriteLine(DisplayStatsLoner(cat));
                input = Console.ReadLine();
                CheckQuit(input);

                if (yesInputs.Contains(input))
                {
                    Console.WriteLine("Great job! You've created your cat, " + cat.name);
                    return true;
                }
                else if (noInputs.Contains(input))
                {
                    temporaryCat = CorrectError(cat);
                    return false;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }
        public Cat CorrectError(Cat cat)
        {
            Console.WriteLine("Which part is incorrect? \n[0]: Name\n[1]: Age\n[2]: Gender");
            string checkError = "";
            while (!checkError.All(Char.IsDigit) || string.IsNullOrWhiteSpace(checkError) || int.Parse(checkError) > 2)
            {
                checkError = Console.ReadLine();
                CheckQuit(checkError);
            }
            string name = cat.name;
            int age = cat.age;
            Defs.Gender gender = cat.genderAccesor;
            int error = int.Parse(checkError);
            switch (error)
            {
                case 0:
                    Console.WriteLine("What is your leader's name? (Prefix only)");
                    name = GetNameLoner();
                    name =  name.First().ToString().ToUpper() + name.Substring(1);
                    break;
                case 1:
                    Console.WriteLine("How old is your leader? (In moons)");
                    age = GetAge();
                    break;
                case 2:
                    Console.WriteLine("What is your leader's gender?");
                    gender = GetGender();
                    break;
            }
            Cat tempCat = new Cat(name, "", cat.rankAccesor, gender, age);
            return tempCat;

        }

        public string GetNameLoner()
        {
            string checkName = "";
            while (!checkName.All(Char.IsLetter) || string.IsNullOrWhiteSpace(checkName))
            {
                checkName = Console.ReadLine();
                CheckQuit(checkName);
            }
            string name = checkName;
            return name;
        }

        public int GetAge()
        {
            string checkAge = "";
            while (!checkAge.All(Char.IsDigit) || string.IsNullOrWhiteSpace(checkAge))
            {
                checkAge = Console.ReadLine();
                CheckQuit(checkAge);
            }
            int age = int.Parse(checkAge);
            return age;
        }

        public Defs.Gender GetGender()
        {
            Console.WriteLine("[0]: Tom \n[1]: She-cat \n[2]: Other");
            string checkGender = "";
            while (!checkGender.All(Char.IsDigit) || string.IsNullOrWhiteSpace(checkGender) || int.Parse(checkGender) > 2)
            {
                checkGender = Console.ReadLine();
                CheckQuit(checkGender);
            }
            int genderNumber = int.Parse(checkGender);
            Defs.Gender gender = Defs.genderDict.ElementAt(genderNumber).Key;
            return gender;
        }

        public string DisplayStatsLoner(Cat cat)
        {
            string display = cat.name + " \nAge: " + cat.age + " moons \nGender: " + Defs.genderDict[cat.genderAccesor];
            return display;
        }

    }
}
