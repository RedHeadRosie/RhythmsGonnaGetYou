using System;
using System.Linq;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();



            //var bandCount = context.Bands.Count();
            //Console.WriteLine($"There are {bandCount} bands!");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(A)add a new band");
            Console.WriteLine("(B)view all the bands");
            Console.WriteLine("(C)add a new album for a band");
            Console.WriteLine("(D)add a song to an album");
            Console.WriteLine("(E)let a band go");
            Console.WriteLine("(F)resign a band");
            Console.WriteLine("(G)view all a band's albums");
            Console.WriteLine("(H)view all albums by release date");
            Console.WriteLine("(Q)quit");
            Console.WriteLine();

            string response = Console.ReadLine();
            while (response != "Q" || response != "q")
            {

                if (response == "A" || response == "a")
                {

                }
                if (response == "B" || response == "b")
                {
                    Console.WriteLine("How do you want the bands to be displayed?");
                    Console.WriteLine("(A)all the bands");
                    Console.WriteLine("(B)all the signed bands");
                    Console.WriteLine("(C)all the unsigned bands");
                    Console.WriteLine("(D)return to main menu");
                    Console.WriteLine();
                    string viewingOptions = Console.ReadLine();
                    if (viewingOptions == "A" || viewingOptions == "a")
                    {
                        Console.WriteLine("debug");
                        foreach (var band in context.Bands)
                        {
                            Console.WriteLine($"There is a band called {band.Name}");
                            break;
                        }
                    }
                    else if (viewingOptions == "B" || viewingOptions == "b")
                    {
                    }
                    else if (viewingOptions == "C" || viewingOptions == "c")
                    {
                    }
                    else if (viewingOptions == "D" || viewingOptions == "d")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have not chosen A, B or C so you will be returned to the main menu");
                        break;
                    }

                }
                else if (response == "C" || response == "c")
                {

                }
                else if (response == "D" || response == "d")
                {

                }
                else if (response == "E" || response == "e")
                {

                }
                else if (response == "F" || response == "f")
                {

                }
                else if (response == "G" || response == "g")
                {

                }
                else if (response == "H" || response == "h")
                {

                }
                else if (response == "Q" || response == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose one of the options");
                }
            }
        }
    }
}
