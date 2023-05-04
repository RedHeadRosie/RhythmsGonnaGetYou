using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public string Duration { get; set; }

        public Album Album { get; set; }

        internal static void AddNewSong(RhythmsGonnaGetYouContext context)
        {
            //IS THE BAND ALREADY IN THE DATABASE?
            var albumBandName = Menu.PromptForString("What is the name of the band this song belongs to? ");
            var checkBandName = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == albumBandName.ToUpper());

            if (checkBandName == null)
            {
                //IF NO, EXIT
                Console.WriteLine("This band is not in the database, please add this first. ");
            }
            else
            {
                //IF YES, IS THE ALBUM ALREADY IN THE DATABASE?
                var albumName = Menu.PromptForString("What is the title of the album this song belongs to? ");
                var checkAlbumName = context.Albums.FirstOrDefault(album => album.Title.ToUpper() == albumName.ToUpper());

                if (checkAlbumName == null)
                {
                    //IF NOT, EXIT
                    Console.WriteLine("This album is not in the database, please add this first. ");
                }
                else
                {
                    //IF YES, IS THE TRACK ALREADY IN THE DATABASE?
                    var songName = Menu.PromptForString("What is the title of the song you want to add? ");
                    var checkSongName = context.Songs.FirstOrDefault(song => song.Title.ToUpper() == songName.ToUpper());

                    if (checkSongName != null)
                    {
                        Console.WriteLine("This song is already in this album within the database. ");
                    }
                    else
                    {
                        var songTrack = Menu.PromptForInteger("What is the track number for this song? ");
                        var checkTrackNumber = context.Songs.FirstOrDefault(song => song.TrackNumber == songTrack);

                        if (checkTrackNumber != null && checkBandName.Id == checkAlbumName.BandId && checkAlbumName.Id == checkTrackNumber.AlbumId)
                        {
                            Console.WriteLine("There is already a song for this track number in this album. ");
                        }
                        else
                        {
                            var newSong = new Song
                            {
                                TrackNumber = songTrack,
                                Title = songName,
                                AlbumId = checkAlbumName.Id,
                                Duration = Menu.PromptForString("What is the duration of this song? ")

                            };
                            context.Songs.Add(newSong);
                            context.SaveChanges();
                        }


                    }


                }
            }
        }
    }
}
