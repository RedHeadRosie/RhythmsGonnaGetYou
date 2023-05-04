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

        internal static void NewAlbum(RhythmsGonnaGetYouContext context)
        {

            var albumBandName = Menu.PromptForString("What is the name of the band this album belongs to? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                Console.WriteLine("This band is not in the database, please add this first.");
            }
            else
            {
                var albumName = Menu.PromptForString("What is the title of the album? ");
                var checkAlbumName = context.Albums.FirstOrDefault(album => album.Title.ToUpper() == albumName.ToUpper());

                if (checkAlbumName != null)
                {
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
            foreach (var obj in context.Albums)
            {
                Console.WriteLine($"There is an album called {obj.Title}");
            }


            // NOT NECESSARY FOR TASK, WILL RETURN TO WITH MORE TIME
            // var albumBandName = Menu.PromptForString("What is the name of the band that you would like to see the albums for? ");
            // var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            // if (checkBandName == null)
            // {
            //     Console.WriteLine("This band is not in the database, soz");
            // }
            // else
            // {
            //     var AlbumNames = new List<string> { };
            //     // HERE IS WHERE I WOULD PRINT OUT ALBUMS WITH MATCHING BAND NAME
            //     // foreach (var obj in context.Albums)
            //     // {
            //     //     Console.WriteLine($"There is an album called {obj.Title}");
            //     // }
            // }

        }

        internal static void ViewAlbumsByRD(RhythmsGonnaGetYouContext context)
        {
            throw new NotImplementedException();
        }
    }
}
