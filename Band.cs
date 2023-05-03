using System.Linq;
using System;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        public static void NewBand(RhythmsGonnaGetYouContext context)
        {
            var bandName = Menu.PromptForString("What is the name of the band? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == bandName.ToUpper());

            if (checkBandName != null)
            {
                Console.WriteLine("This band is already in the database.");
            }
            else
            {
                var newBand = new Band
                {
                    Name = bandName,
                    CountryOfOrigin = Menu.PromptForString("What is the country of origin? "),
                    NumberOfMembers = 1,
                    Website = Menu.PromptForString("What is their website? "),
                    Style = Menu.PromptForString("What is their style? "),
                    IsSigned = true,
                    ContactName = Menu.PromptForString("What is the contact name? "),
                    ContactPhoneNumber = Menu.PromptForString("What is their contact phone number? ")
                };
                context.Bands.Add(newBand);
                context.SaveChanges();
            }
        }
    }


}