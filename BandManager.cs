using System;
using RhythmApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace RhythmApp
{
  public class BandManager
  {

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
      Console.WriteLine("Does your band have a website?");
      var website = Console.ReadLine();
      Console.WriteLine("What style is your band?");
      var style = Console.ReadLine();
      Console.WriteLine("Is your band signed? True or False?");
      var isSigned = bool.Parse(Console.ReadLine());
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
  }
}