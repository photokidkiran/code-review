using System;
using System.IO;

public class ApocalypticTrentFunction
{

    public string[] UserDetails = new string[2];
    public int[] GameLevel = new int[3];
    Boolean GameFlag = true;

    //Taking Player details required for the game
    public void TakeUserDetails(string[] UserDetails)
    {
        Console.WriteLine("Hi, Welcome to Post Apocolyptic Trent: Its a game about if Trent is under a Zombie attack!!");
        Console.WriteLine("Fill in the following Details for us to begin the game:");
        Console.Write("Name: ");
        UserDetails[0] = Console.ReadLine();
        Console.Write("Freinds Name: ");
        UserDetails[1] = Console.ReadLine();
    }

    //To convert Gamelevel int array into an unique int to map it with corresponding text file
    public string GetGameLevel(int[] GameLevel)
    {
        int sum = 0;
        for (int i = 0; i < 4; i++)
        {
            sum = sum * 10 + GameLevel[i];
        }
        return (GetGamePath(sum)); //returning the correspoding path for the required next text file
    }

    //To read the the story from a designated path
    public int NewStoryReader(string[] UserDetails, string FilePath)
    {
        Boolean Temp = true;
        StreamReader reader = new StreamReader(FilePath);
        while (!reader.EndOfStream)
        {
            string PlayerFlag = "$";
            string PlayerFriendFlag = "#";
            string PeriodFlag = ".";
            string EndFlag = "###";
            string RunFlag = "**";
            string FightFlag = "##";

            if (Temp == true)
            {
                string[] temp = (reader.ReadLine()).Split(' ');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == PlayerFlag)
                    {
                        temp[i] = UserDetails[0];
                        Console.Write(" {0}", temp[i]);
                    }
                    else if (temp[i] == PlayerFriendFlag)
                    {
                        temp[i] = UserDetails[1];
                        Console.Write(" {0}", temp[i]);
                    }
                    else if (temp[i] == PeriodFlag)
                    {
                        Console.Write(".\n");
                    }
                    else if (temp[i] == EndFlag)
                    {
                        GameFlag = false;
                        break;
                    }

                    else if (temp[i] == FightFlag)
                    {
                        if (TimerGame("fight") == false)
                        {
                            Temp = false;
                            GameFlag = false;
                        }
                    }

                    else if (temp[i] == RunFlag)
                    {
                        if (TimerGame("Run") == false)
                        {
                            Temp = false;
                            GameFlag = false;
                        }
                    }

                    else
                        Console.Write(" {0}", temp[i]);
                }
            }
            else
                break;
        }
        reader.Close();
        if (GameFlag)
        {
            return (CheckInvalidInput("Choose between 1-2: ", 1, 2));

        }
        else return 0;
    }

    public Boolean TimerGame(string Event)
    {
        Console.WriteLine("The {0} begins now, Keep Keying the Charecters that appear on the screen", Event);
        Console.WriteLine("PRESS ANY KEY WHEN READY");
        Console.ReadKey();
        DateTime StartTime = DateTime.Now;
        Random RandomGenerator = new Random();
        for (int StepCounter = 0; StepCounter < 10; StepCounter++)
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
        int IntRuntime = Convert.ToInt32(RunTime.TotalMilliseconds) / 10;
        if (IntRuntime < 1000)
        {
            Console.WriteLine("You Survived the " + Event);
            KeyToContinue("Press any key to continue");
            return true;
        }
        else if (IntRuntime < 1100)
        {
            Console.WriteLine("You Barely made out of the " + Event);
            KeyToContinue("Press any key to continue");
            return true;
        }
        else
        {
            Console.WriteLine("Sorry you could not survive the " + Event);
            Console.WriteLine("Would you want to retry?  \n1. Yes 2.No");
            int Decision = CheckInvalidInput(" Please choose between 1 and 2 : ", 1, 2);
            if (Decision == 1)
            {
                TimerGame("Fight");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public int CheckInvalidInput(string Prompt, int Option1, int Option2)
    {
        Console.Write(Prompt);
        int Input = Convert.ToInt32(Console.ReadLine());
        while ((Input < Option1) || (Input > Option2))
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

    public string GetGamePath(int sum)
    {
        string Path = "null";
        switch (sum)
        {
            case 0:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\Introduction.txt";
                break;
            case 1000:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\one.txt";
                break;
            case 1100:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\two.txt";
                break;
            case 2000:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\three.txt";
                break;
            case 2100:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\four.txt";
                break;
            case 2110:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\five.txt";
                break;
            case 2120:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\six.txt";
                break;
            case 2200:
                Path = "C:\\C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\seven.txt";
                break;
            case 2210:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\eight.txt";
                break;
            case 2220:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\nine.txt";
                break;
            case 1200:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\ten.txt";
                break;
            case 1210:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\four.txt";
                break;
            case 1220:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\seven.txt";
                break;
            case 1211:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\five.txt";
                break;
            case 1212:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\six.txt";
                break;
            case 1221:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\eight.txt";
                break;
            case 1222:
                Path = "C:\\Users\\KailAsh\\Desktop\\PAT\\PostApocalypticTrent\\PostApocalypticTrent\\nine.txt";
                break;
        }
        return Path;
    }
}