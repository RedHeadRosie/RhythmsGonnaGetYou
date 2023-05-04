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
                    NumberOfMembers = Menu.PromptForInteger("How many members are there in the band?"),
                    Website = Menu.PromptForString("What is their website? "),
                    Style = Menu.PromptForString("What is their style? "),
                    IsSigned = Menu.PromptForBoolean("Is the band signed? y/n"),
                    ContactName = Menu.PromptForString("What is the contact name? "),
                    ContactPhoneNumber = Menu.PromptForString("What is their contact phone number? ")
                };
                context.Bands.Add(newBand);
                context.SaveChanges();
            }
        }

        public static void DropBand(RhythmsGonnaGetYouContext context)
        {
            var albumBandName = Menu.PromptForString("What is the name of the band that you would like to set as unsigned? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                Console.WriteLine("This band is not in the database, please add this first.");
            }
            else
            {
                var checkSigned = checkBandName.IsSigned;
                if (checkSigned == false)
                {
                    //check if they are signed
                    // - if not, then let user know and exit.
                    Console.WriteLine($"{checkBandName.Name} is already set as unsigned. No changed made. ");
                }
                else if (checkSigned == true)
                {
                    // -if they are, then set them as unsigned
                    Boolean setAsUnsigned = false;
                    checkBandName.IsSigned = setAsUnsigned;
                    Console.WriteLine($"{checkBandName.Name} has been dropped from their record label. ");
                }
                else
                {
                    Boolean setAsUnsigned = false;
                    checkBandName.IsSigned = setAsUnsigned;
                    Console.WriteLine($"{checkBandName.Name} has been dropped from their record label. ");
                }
                context.SaveChanges();
            }
        }

        public static void SignBand(RhythmsGonnaGetYouContext context)
        {
            var albumBandName = Menu.PromptForString("What is the name of the band that you would like to set as signed? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                Console.WriteLine("This band is not in the database, please add this first.");
            }
            else
            {
                var checkSigned = checkBandName.IsSigned;
                if (checkSigned == true)
                {
                    //check if they are signed
                    // - if yes, then let user know and exit.
                    Console.WriteLine($"{checkBandName.Name} is already set as signed. No changed made.");
                }
                else if (checkSigned == false)
                {
                    // -if they aren't, then set them as signed
                    Boolean setAsUnsigned = true;
                    checkBandName.IsSigned = setAsUnsigned;
                    Console.WriteLine($"{checkBandName.Name} has been signed, Huzzah! ");
                }
                else
                {
                    Boolean setAsUnsigned = true;
                    checkBandName.IsSigned = setAsUnsigned;
                    Console.WriteLine($"{checkBandName.Name} has been signed, Huzzah! ");
                }
                context.SaveChanges();
            }
        }
    }


}