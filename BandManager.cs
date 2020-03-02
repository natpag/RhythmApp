using System;
using RhythmApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace RhythmApp
{
  public class BandManager
  {

    public void OpeningMenu()
    {
      Console.WriteLine("Welcome to Daddy Kool's Record Label!");
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("[S] Sign a band");
      Console.WriteLine("[U] Unsign of a band");
      Console.WriteLine("[R] Resign a band");
      Console.WriteLine("[W] Work with a band");
      Console.WriteLine("[VA] View all of the label's albums");
      Console.WriteLine("[VS] View all signed bands");
      Console.WriteLine("[VU] View all unsigned bands");
      Console.WriteLine("[Q] Quit");
    }

    public void PopulateDatabase()
    {
      var db = new DatabaseContext();
      if (!db.Bands.Any())
      {
        db.Bands.Add(new Band
        {
          Name = "Iron Maiden",
          CountryOfOrigin = "Britain",
          NumberOfMembers = "6",
          Website = "https://ironmaiden.com/",
          Style = "Heavy Metal",
          IsSigned = true,
          PersonOfContact = "Bruce Dickinson",
          ContactPhoneNumber = "666-666-6666",
        });
        db.Bands.Add(new Band
        {
          Name = "GateCreeper",
          CountryOfOrigin = "United States of America",
          NumberOfMembers = "5",
          Website = "https://gatecreeper.bandcamp.com/",
          Style = "Death Metal",
          IsSigned = true,
          PersonOfContact = "Chase Mason",
          ContactPhoneNumber = "123-456-7890",
        });
        db.SaveChanges();
      }
    }

    public void AddBand()
    {
      var db = new DatabaseContext();
      Console.WriteLine("What is the band's name?");
      var name = Console.ReadLine();
      Console.WriteLine("What is the band's country of origin?");
      var countryOfOrigin = Console.ReadLine();
      Console.WriteLine("How many members are in the band?");
      var numberOfMembers = Console.ReadLine();
      Console.WriteLine("What is the band's website?");
      var website = Console.ReadLine();
      Console.WriteLine("What style is your band?");
      var style = Console.ReadLine();
      Console.WriteLine("Is your band signed? (y) or (n)");
      var isSigned = YesOrNo();
      Console.WriteLine("Who should we contact to get in touch with your band?");
      var personOfContact = Console.ReadLine();
      Console.WriteLine($"What is {personOfContact}'s phone number?");
      var contactPhoneNumber = Console.ReadLine();

      db.Bands.Add(new Band
      {
        Name = name,
        CountryOfOrigin = countryOfOrigin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        Style = style,
        IsSigned = isSigned,
        PersonOfContact = personOfContact,
        ContactPhoneNumber = contactPhoneNumber,
      });
      db.SaveChanges();
    }
    public void UnSignBand()
    {
      Console.WriteLine("Which band would you like to remove from the label?");
      var db = new DatabaseContext();
      var bands = db.Bands.OrderBy(b => b.Id);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}:{band.Name}");
      }
      var bandId = int.Parse(Console.ReadLine());
      var theBand = db.Bands.First(b => b.Id == bandId);
      Console.WriteLine($"Do you want to unsign {theBand.Name}? (y) or (n)");
      var isSigned = !YesOrNo();
      Console.WriteLine($"You've unsigned {theBand.Name}");
      theBand.IsSigned = isSigned;
      db.SaveChanges();
    }
    public void ReSignBand()
    {
      Console.WriteLine("Which band would you like to resign to the label?");
      var db = new DatabaseContext();
      var bands = db.Bands.OrderBy(b => b.Id);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}:{band.Name}");
      }
      var bandId = int.Parse(Console.ReadLine());
      var theBand = db.Bands.First(b => b.Id == bandId);
      Console.WriteLine($"Do you want to resign {theBand.Name} (y) or (n)? ");
      var isSigned = YesOrNo();
      Console.WriteLine($"You've resigned {theBand.Name}");
      theBand.IsSigned = isSigned;
      db.SaveChanges();
    }
    public bool YesOrNo()
    {
      var input = Console.ReadLine();
      bool theAnswer = input.ToLower() == "y";
      return theAnswer;
    }
    public void ViewAllLabelsAlbums()
    {
      Console.WriteLine("Here are all of the albums Daddy Kool has produced!");
      var db = new DatabaseContext();
      var albums = db.Albums.OrderBy(a => a.ReleaseDate);
      foreach (var album in albums)
      {
        Console.WriteLine($"{album.Id}:{album.Title}");
      }
    }

    public void ViewAllSignedBands()
    {
      var db = new DatabaseContext();
      Console.WriteLine("Here are all of the signed bands!");
      var bands = db.Bands.Where(b => b.IsSigned).OrderBy(b => b.Id);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}:{band.Name}");
      }
    }
    public void ViewAllUnSignedBands()
    {
      var db = new DatabaseContext();
      Console.WriteLine("Here are all of the signed bands!");
      var bands = db.Bands.Where(b => b.IsSigned == false);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}:{band.Name}");
      }
    }
    public void WorkingWithABand()
    {
      Console.WriteLine("Choose a band you'd like to work with...");
      var db = new DatabaseContext();
      var bands = db.Bands.OrderBy(b => b.Id);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}:{band.Name}");
      }
      var bandId = int.Parse(Console.ReadLine());
      var theBand = db.Bands.First(b => b.Id == bandId);
      Console.WriteLine($"Here are your options for working with {theBand.Name}");
      Console.WriteLine("\n[P]Produce an album [VA] View all albums");
      var input = Console.ReadLine().ToLower();
      if (input == "p")
      {
        Console.WriteLine("What would you like to name the album?");
        var albumTitle = Console.ReadLine();
        Console.WriteLine("Is the album explicit?");
        var isExplicit = YesOrNo();
        Console.WriteLine("When is the release date?");
        var releaseDate = DateTime.Parse(Console.ReadLine());

        db.Albums.Add(new Album
        {
          Title = albumTitle,
          IsExplicit = isExplicit,
          ReleaseDate = releaseDate,
          BandId = bandId,
        });
        db.SaveChanges();

        Console.WriteLine($"Would you like to add a song to you album (y) or (n)?");

        bool addSong = true;
        while (addSong)
        {
          if (input == "y")
          {
            Console.WriteLine("What is the name of the song?");
            var songTitle = Console.ReadLine();
            Console.WriteLine("What are the lyrics to the song? If none, please write N/A");
            var lyrics = Console.ReadLine();
            Console.WriteLine("What is the song's length in minutes?");
            var length = Console.ReadLine();
            Console.WriteLine("What genre is the song?");
            var songGenre = Console.ReadLine();

            db.Songs.Add(new Song
            {
              Title = songTitle,
              Lyrics = lyrics,
              Length = length,
              Genre = songGenre,
            });
            db.SaveChanges();
          }

          if (input == "n")
          {
            Console.WriteLine("Okay, your album has no songs listed...");
            addSong = false;
          }
        }
      }

    }

  }
}