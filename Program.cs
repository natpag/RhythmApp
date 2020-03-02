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
        bandManager.OpeningMenu();
        var input = Console.ReadLine().ToLower();

        // Sign a band
        if (input == "s")
        {
          bandManager.AddBand();
          Console.WriteLine("\n");
        }
        // Let go of a band
        if (input == "u")
        {
          bandManager.UnSignBand();
          Console.WriteLine("\n");
        }
        // Resign a band
        if (input == "r")
        {
          bandManager.ReSignBand();
          Console.WriteLine("\n");
        }
        // Work with a band ---> Produce an album / View all albums
        if (input == "w")
        {
          bandManager.WorkingWithABand();
          Console.WriteLine("\n");
        }
        // View all Label's Albums
        if (input == "va")
        {
          bandManager.ViewAllLabelsAlbums();
          Console.WriteLine("\n");
        }
        // View all Signed Bands
        if (input == "vs")
        {
          bandManager.ViewAllSignedBands();
          Console.WriteLine("\n");

        }
        // View all UnSigned Bands
        if (input == "vu")
        {
          bandManager.ViewAllUnSignedBands();
          Console.WriteLine("\n");
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
