using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LinqFull
{
    class Program
    {
        static bool isThereFull (string tab)
        {
            var full = from figure in tab
                       where char.IsLetterOrDigit(figure)
                       group figure by figure
                       into figureGroup
                       select figureGroup;

            if (full.Count() > 2)
                return false;
                
            foreach (var group in full)
                if (group.Count() == 1 || group.Count() == 0)
                    return false;

            return true;
        }

        
        static void Main(string[] args)
        {
            string data;
            using (FileStream input = File.OpenRead("input.txt"))
            using (StreamReader reader = new StreamReader(input))
            {
                 data = reader.ReadToEnd(); 
            }

            string[] hands = data.Split(";");
           
            foreach (var item in hands)
            {
                if (isThereFull(item))
                    Console.WriteLine(item);
            }
            
        }
    }
}
