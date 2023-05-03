using System;

namespace RhythmsGonnaGetYou
{
    public class Menu
    {
        public static void Options(RhythmsGonnaGetYouContext context)
        {

            Boolean activeMenu = true;

            var response = PromptForInteger("Main Menu\n1. add a new band\n2. view all bands\n3. add a new album for a band\n4. add a song to an album\n5. let a band go\n6. sign a band\n7. view all albums\n8. quit\n");

            while (activeMenu == true)
            {
                switch (response)
                {
                    case 1:
                        Band.NewBand(context);
                        break;

                    case 2:
                        ViewBandsMenu(context);
                        break;

                    case 3:
                        //to do
                        Album.NewAlbum(context);
                        break;

                    case 4:
                        //to do
                        AddNewSong(context);
                        break;

                    case 5:
                        //to do
                        DropBand(context);
                        break;

                    case 6:
                        //to do
                        SignBand(context);
                        break;

                    case 7:
                        //to do
                        ViewAlbums(context);
                        break;

                    case 8:
                        activeMenu = false;
                        break;

                    default:
                        Options(context);
                        break;
                }
            }

        }

        private static void ViewAlbums(RhythmsGonnaGetYouContext context)
        {
            throw new NotImplementedException();
        }

        private static void SignBand(RhythmsGonnaGetYouContext context)
        {
            throw new NotImplementedException();
        }

        private static void DropBand(RhythmsGonnaGetYouContext context)
        {
            throw new NotImplementedException();
        }

        private static void AddNewSong(RhythmsGonnaGetYouContext context)
        {
            throw new NotImplementedException();
        }

        private static void ViewBandsMenu(RhythmsGonnaGetYouContext context)
        {
            //Console.WriteLine("debug2");
            //Console.WriteLine("How do you want the bands to be displayed?");
            //Console.WriteLine("(1)all the bands");
            //Console.WriteLine("(2)all the signed bands");
            //Console.WriteLine("(3)all the unsigned bands");
            //Console.WriteLine("(4)return to main menu");
            //Console.WriteLine();

            var vOOutput = PromptForInteger("How do you want to view the bands?\n1. view all the bands\n2. view all signed bands\n3. view all unsigned bands\n4. return to main menu\n");

            switch (vOOutput)
            {

                case 1:
                    ViewAllBands(context);
                    break;

                case 2:
                    ViewSignedBands(context);
                    break;

                case 3:
                    ViewUnsignedBands(context);
                    break;

                case 4:
                    Options(context);
                    break;

                default:
                    Options(context);
                    break;

            }


        }

        private static void ViewUnsignedBands(RhythmsGonnaGetYouContext context)
        {
            foreach (var obj in context.Bands)
            {
                if (obj.IsSigned == false)
                {
                    Console.WriteLine($"There is a band called {obj.Name} that is not signed.");
                }
            }
        }

        private static void ViewSignedBands(RhythmsGonnaGetYouContext context)
        {
            foreach (var obj in context.Bands)
            {
                if (obj.IsSigned == true)
                {
                    Console.WriteLine($"There is a band called {obj.Name} that is signed.");
                }
            }
        }

        private static void ViewAllBands(RhythmsGonnaGetYouContext context)
        {
            foreach (var obj in context.Bands)
            {
                Console.WriteLine($"There is a band called {obj.Name}");
            }
        }

        public static int PromptForInteger(string prompt)
        {
            //Console.WriteLine("debug3");
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            //Console.WriteLine($"userInput is {userInput}");
            if (isThisGoodInput)
            {
                //Console.WriteLine("debug4");
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        public static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        internal static bool PromptForBoolean(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y")
            {
                Boolean outputTrue = true;
                return outputTrue;
            }
            else if (userInput == "N" || userInput == "n")
            {
                Boolean outputFalse = false;
                return outputFalse;
            }
            else
            {
                Console.WriteLine("That is not valid input therefore the album will be labeled as explicit.");
                Boolean outputTrue = true;
                return outputTrue;
            }

        }

        internal static DateTime PromptForDateTime(string v)
        {
            throw new NotImplementedException();
        }
    }
}