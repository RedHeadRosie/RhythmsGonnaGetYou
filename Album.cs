using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RhythmsGonnaGetYou
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public Date ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Band Band { get; set; }
    }
}