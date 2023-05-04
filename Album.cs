using System;
using System.Collections.Generic;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Band Band { get; set; }

        public static void NewAlbum(RhythmsGonnaGetYouContext context)
        {
            //IS THE BAND ALREADY ADDED TO THE DATABASE?
            var albumBandName = Menu.PromptForString("What is the name of the band this album belongs to? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                //IF NO, EXIT
                Console.WriteLine("This band is not in the database, please add this first.");
            }
            else
            {
                //IF YES, IS THE ALBUM ALREADY IN THE DATABASE?
                var albumName = Menu.PromptForString("What is the title of the album? ");
                var checkAlbumName = context.Albums.FirstOrDefault(album => album.Title.ToUpper() == albumName.ToUpper());

                if (checkAlbumName != null)
                {
                    //IF NO, EXIT
                    Console.WriteLine("This album is already in the database, you can't add it again.");
                }
                else
                {
                    var releaseDate = Menu.PromptForString("What is the release date? mm/dd/yyyy ");
                    var parseDate = DateTime.Parse(releaseDate);

                    var newAlbum = new Album
                    {
                        Title = albumName,
                        IsExplicit = Menu.PromptForBoolean("Is this album explicit? "),
                        ReleaseDate = parseDate,
                        BandId = checkBandName.Id
                    };
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
            }

        }

        public static void ViewAlbumsByBand(RhythmsGonnaGetYouContext context)
        {
            // foreach (var obj in context.Albums)
            // {
            //     Console.WriteLine($"There is an album called {obj.Title}");
            // }


            var albumBandName = Menu.PromptForString("What is the name of the band that you would like to see the albums for? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                Console.WriteLine("This band is not in the database, soz");
            }
            else
            {
                int albumIdInt = checkBandName.Id;

                foreach (var obj in context.Albums)
                {
                    if (albumIdInt == obj.BandId)
                    {
                        Console.WriteLine($"There is an album called {obj.Title} by {checkBandName.Name}. ");
                    }
                }
            }
        }

        public static void ViewAlbumsByRD(RhythmsGonnaGetYouContext context)
        {
            var albumRD = Menu.PromptForString("What is the release date (mm/dd/yyyy) you would like to see the albums for? ");
            var parseRDate = DateTime.Parse(albumRD);
            var checkRD = context.Albums.FirstOrDefault(album => album.ReleaseDate == parseRDate);

            if (checkRD == null)
            {
                Console.WriteLine("There are no albums with that release date in the database");
            }
            else
            {
                foreach (var obj in context.Albums)
                {
                    if (parseRDate == obj.ReleaseDate)
                    {
                        Console.WriteLine($"There is an album called {obj.Title} that was released {checkRD.ReleaseDate}. ");
                    }
                }
            }
        }
    }
}
