using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new RhythmsGonnaGetYouContext();
            Menu.Options(context);

            //var bandCount = context.Bands.Count();
            //Console.WriteLine($"There are {bandCount} bands!");


        }


    }
}
