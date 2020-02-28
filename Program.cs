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
        Console.WriteLine("What would you like to do?");
        // Sign a band
        // Produce an album (add an album and add a few songs to that album)
        // let go of a band (update isSigned to false)
        // resign a band (update isSigned to true)
        // View all albums for a band
        // View all the albums, ordered by ReleaseDate
        // View an Album's songs
        // view all signed bands
        // view all unsigned bands
        Console.WriteLine("[S] Sign a band");
        Console.WriteLine("[P] Produce an album");

        Console.WriteLine("Would you like to add a new band? (y) or (n)");
        var input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          bandManager.AddBand();
        }
        else if (input == "n")
        {
          Console.WriteLine("Ok bye!");
          doneManaging = true;

        }
      }
    }
  }
}
