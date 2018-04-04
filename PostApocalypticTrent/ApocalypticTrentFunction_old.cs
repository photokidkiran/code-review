using System;
using System.IO;

public class ApocalypticTrentFunction
{
    public ApocalypticTrentFunction()
    {
    }

    public void TakeUserDetails(string[] UserDetails)
    {
        Console.WriteLine("Hi, Welcome to Post Apocolyptic Trent: Its a game about if Trent is under a Zombie attack!!");
        Console.WriteLine("Fill in the following Details for us to begin the game:");
        Console.Write("Name: ");
        UserDetails[0] = Console.ReadLine();
        Console.Write("Freinds Name: ");
        UserDetails[1] = Console.ReadLine();
    }
 
    public void ReadStory(string[] Story, string StoryPath)
    {
        
        StreamReader StoryReader = new StreamReader(StoryPath);

        for(int Counter =0; Counter < Story.Length; Counter++)
        {
            Story[Counter] = StoryReader.ReadLine();
        }
        StoryReader.Close();
    }

    public void newDisplay(string[] Story, string[] UserDetails)
    {
        for(int counter =0; counter < Story.Length; counter++)
        {
            string[] temp = Story[counter].Split(' '); 
            for(int counter1 =0; counter1 < temp.Length; counter1++)
            {
                if (temp[counter1] == "$")
                {
                    temp[counter1] = UserDetails[0];
                }
                else if (temp[counter1] == ".")
                {
                    Console.Write(".\n");
                }
                else
                    Console.Write(" {0}", temp[counter1]);
            }
        }
    }

    public void DisplayStory(string[] Story, int Begin, int End, string[] UserDetails)
    {
        for (int Counter = Begin; Counter <= End; Counter++)
        {
            if ((Counter == 3 || Counter == 17))
            {
                Console.WriteLine(UserDetails[0] + Story[Counter]);
            }
            else if (Counter == 7 || Counter == 19 || Counter == 20 || Counter ==23 || Counter ==26 || Counter == 30 || Counter == 33 ||Counter == 39 || Counter == 40 || Counter ==41 || Counter == 47 || Counter == 52 )
            {
                Console.Write(Story[Counter] + UserDetails[1]);
            }
            else
            {
                Console.WriteLine("{0}", Story[Counter]);
            }
        }
    }

    public int CheckInvalidInput(string Prompt, int Option1, int Option2)
    {
        Console.Write(Prompt);
        int Input = int.Parse(Console.ReadLine());
        while((Input < Option1) || (Input > Option2))
        {
            Console.Write(Prompt);
            Input = int.Parse(Console.ReadLine());
        }
        return Input;
    }
    public void KeyToContinue(string KeyPrompt)
    {
        Console.Write(KeyPrompt);
        Console.ReadKey();
        Console.Clear();
    }


    public int TimerGame(string Event)
    {
        Console.WriteLine("The {0} begins now, Keep Keying the Charecters that appear on the screen",Event);
        Console.WriteLine("PRESS ANY KEY WHEN READY");
        Console.ReadKey();
        DateTime StartTime = DateTime.Now;
        Random RandomGenerator = new Random();
        for(int StepCounter = 0; StepCounter <10; StepCounter++)
        {
            int RandomKey = RandomGenerator.Next(1, 9);
            Console.Write(RandomKey + ": ");
            ConsoleKeyInfo CharInput = Console.ReadKey();
            int IntInput = int.Parse(CharInput.KeyChar.ToString());
            if (IntInput != RandomKey)
            {
                Console.Write("\t Wrong Step!");
                StepCounter--;
            }
            Console.WriteLine();
        }
        DateTime StopTime = DateTime.Now;
        TimeSpan RunTime = (StopTime - StartTime);
        int IntRuntime = Convert.ToInt32(RunTime.TotalMilliseconds)/10;
        if(IntRuntime < 1000)
        {
            Console.WriteLine("You Survived the "+ Event);
            KeyToContinue("Press any key to continue");
            return 1;
        }
        else if(IntRuntime < 1100)
        {
            Console.WriteLine("You Barely made out of the " + Event);
            KeyToContinue("Press any key to continue");
            return 1;
        }
        else
        {
            Console.WriteLine("Sorry you could not survive the "+ Event );
            Console.WriteLine("Would you want to retry?  \n1. Yes 2.No");
            int Decision = CheckInvalidInput(" Please choose between 1 and 2 : ", 1, 2);
            if(Decision == 1)
            {
                TimerGame("Fight");
            }
            return 0;
        }

    }
}
