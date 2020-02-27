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


        Console.WriteLine("Welcome to your band managing app!");

        Console.WriteLine("Would you like to add a new band? (y) or (n)");
        var input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          bandManager.AddBand();
        }
        else if (input == "n")
        {
          Console.WriteLine("ok bye!");
        }
      }
    }
  }
}
