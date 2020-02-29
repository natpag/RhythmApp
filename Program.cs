using System;
using RhythmApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace RhythmApp
{
  public class Program
  {
    static void Main(string[] args)
    {
      bool doneManaging = false;
      while (!doneManaging)
      {
        var bandManager = new BandManager();
        bandManager.PopulateDatabase();


        Console.WriteLine("Welcome to Daddy Kool's Record Label!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[S] Sign a band");
        Console.WriteLine("[U] Unsign of a band");
        Console.WriteLine("[R] Resign a band");
        Console.WriteLine("[VA] View all of the label's albums");
        Console.WriteLine("[VS] View all signed bands");
        Console.WriteLine("[VU] View all unsigned bands");
        Console.WriteLine("[Q] Quit");
        var input = Console.ReadLine().ToLower();

        // Sign a band
        if (input == "s")
        {
          bandManager.AddBand();
        }
        // Let go of a band
        if (input == "u")
        {
          bandManager.UnSignBand();
        }
        // Resign a band
        if (input == "r")
        {
          bandManager.ReSignBand();
        }
        // Quit
        if (input == "q")
        {
          Console.WriteLine("Are you sure you want to quit? [y] or [n]");
          var newInput = Console.ReadLine().ToLower();
          if (newInput == "y")
          {
            Console.WriteLine("Ok bye!");
            doneManaging = true;
          }
          if (newInput == "n")
          { }
          else if (newInput != "y" && newInput != "n")
          {
            Console.WriteLine("That is not a valid input...");
          }
        }
      }
    }
  }
}
