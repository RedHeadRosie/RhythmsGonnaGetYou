using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //ADD FUNCTION TO FIND BAND ID
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
                    var newAlbum = new Album
                    {
                        Title = albumName,
                        IsExplicit = Menu.PromptForBoolean("Is this album explicit? "),
                        //ADD FUNCTION TO CHECK THE FORMATTING OF DATE
                        ReleaseDate = Menu.PromptForDateTime("What is the release date? "),
                        BandId = checkBandName.Id
                    };
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
            }



        }
    }
}
