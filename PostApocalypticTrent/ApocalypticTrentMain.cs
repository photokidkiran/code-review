using System;
using System.IO;

public class ApocalypticTrentMain
{
    public static void Main()
    {
        string[] UserDetails = new string[2];
        int[] GameLevel = new int[5];
        int Level = 0;

        ApocalypticTrentFunction Pat = new ApocalypticTrentFunction();

        Pat.TakeUserDetails(UserDetails);

        for (int i = 0; i < 5; i++)
        {
            string PathGame = Pat.GetGameLevel(GameLevel);
            GameLevel[Level] = Pat.NewStoryReader(UserDetails, PathGame);
            Console.Clear();
            if(GameLevel[Level] == 0)
            {
                Console.WriteLine("Thanks for playing!!");
                break;
            }
            else
            {
                Level++;
            }
        }           
    }
}