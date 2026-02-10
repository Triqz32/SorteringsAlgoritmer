using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sortera_number
{
    internal class Program
    {
        static int numSwaps = 0;
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            

            Random rng = new Random();// randomizar numerna du har under från 1 till 10 eller hur många det är.
            int[] unsortedList = { 3,6,2,5,1,7,10,8,4,9};// generar 10 styck nummrar eller hur många det finns inne i Int arrayn
            /*for (int i = 0; i < unsortedList.Length; i++)//kollar på alla platser i listan
            {
                unsortedList[i] = rng.Next(999);// den här generar 10 styck numarna från 0 till 998 eller vilken siffra du vill ha
            }*/
            Console.WriteLine("Detta är den osorterade listan");//skriver ut vad som är inom parantesen.
            PrintArray(unsortedList);
            timer.Start();//börjar timern
            int[] SortedList = BogoSort(unsortedList);// skickar in den inte sorterat listan så att man kan sortera den.
            timer.Stop();//stoppar timern
            

            Console.WriteLine($"\n\nDet tog {timer.Elapsed.TotalSeconds} att sortera. Resultatet är.");//skriver ut vad som är inom parantesen. och även visar hur länge timern var på
            Console.WriteLine($"Vi har gjort {numSwaps} byten");// skriver ur hur många gånger vi har swapar siffrorlgf
            PrintArray (SortedList);//skriver den sorterade listan.

            Console.ReadKey();// stänger programmet så fort den är klar.
        }

        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            numSwaps += 1;
        }
        
        static void PrintArray(int[] array)//skriva ut vår lista flera gånger
        {
            for (int i = 0; i < array.Length; i++)//går igenom varje array
            {
                Console.Write($"{array[i]},");// skriver ut alla siffror.
                if (i % 5 == 0 && i != 0)// % 2 är delat på två med i aka siffran. jämn och ojämn 
                {
                    Console.Write("\n");
                }
                
            }
        }


        static int[] UselessSort(int[] unsorted)//static int array vill att du ska få något till baka medan med void är det inget.
        {
            Swap(unsorted, 0, 1);
            System.Threading.Thread.Sleep(1000);//paus i 1 sekund
            return unsorted;// måste ha return för att static int[] ska funka
        }


        static int[] BogoSort(int[] unsorted)
        {
            bool ärSorterad = unsorted.SequenceEqual(unsorted.OrderBy(x => x));
            Random rng = new Random();
            
            for (int x = 0; x < unsorted.Length; x++)
            {
               
            }
            while (!ärSorterad) //unsorted == false
            {
                int n = unsorted.Length;// kollar om de 3 tallen är sorterad
                while (n > 1)// im n är mindre än ett såt kommer den fortsätta randomiza.
                {
                    n--;//gör numret mindre
                    int k = rng.Next(n + 1);//kolla om n+1 funkar sen går den ner till swap
                    Swap(unsorted, n, k);// swappa placeringen med n, k alltså nummerna

                }

                ärSorterad = unsorted.SequenceEqual(unsorted.OrderBy(x => x));
               // PrintArray(unsorted);
            }

            //Kolla om listan är sorterad
            // Om inte
            // blanda listan
            // gör om.
            //unsored[i]


            return unsorted;
        }

   /*     private static Random rng= new Random();
        public static void Shuffle<T>(this IList<T> unsorted)
        {
            int n = unsorted.Count;
            while (n < 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T Value = unsorted[k];
                unsorted[k] = unsorted[n];
                unsorted[n] = Value;
            }
        }*/

        static int[] Bubblesort(int[] unsorted)
        {
            bool HasSwitched = true;
            while (HasSwitched == true)
            {
                HasSwitched = false;
                for (int x = 0; x < unsorted.Length - 1; x++)
                {
                    if (unsorted[x] > unsorted[x + 1])
                    {
                        Swap(unsorted, x, x + 1);
                        HasSwitched = true;
                    }
                }
                
            }
           
            

            // gå igenom listan    
                // jämför plats a och plats b
                    // om plats a är mer än plats b
                        // byt plats a och plats b
                         //Markera att byte har skätt
                      // jämför plats 2 och plats 3
                   // A + 1 och B + 1 (Kolla nästa platser i listan)
               // GÖr om allt till inga byten sker.
            return unsorted;
        }

        static int[] SelectionSort(int[] unsorted)
        {
            int smallestValue = 1000000;// minsta värdet i listan.
            int smallestIndex = 0;// plasent i listan för det minsta värdet.
            for (int x = 0; x < unsorted.Length; x++)// loop för en anna loop wowie
            {
                for (int i = x; i < unsorted.Length; i++)// kollar och sen sorterar nummerna på årdningen vi ska ha.
                {
                    if (unsorted[i] < smallestValue)
                    {
                        smallestValue = unsorted[i];
                        smallestIndex = i;
                    }
                }
                Swap(unsorted, x, smallestIndex);// swappar nummerna så att det blir rätt sifra i rätt plats från For loopen.
                smallestValue = 1000000;
            }
            
            return unsorted;
        }
    }
}
