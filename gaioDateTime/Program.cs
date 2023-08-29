// See https://aka.ms/new-console-template for more information
using gaioDateTime;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gaioDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = "29/08/2023";

            var g = new GaioDateTime(DateTime.Parse(date));  
            
            Console.WriteLine($"Date: {date} ---> GaioDate: {g}");


            Console.ReadLine();
        }




    }
}