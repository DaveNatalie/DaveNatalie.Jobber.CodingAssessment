using System;
using System.Collections.Generic;

namespace DaveNatalie.Jobber.CodingAssessment
{
    class Program
    {
        static void Main(string[] args)
        {

            char[][] triplets = new[]
            {
                new [] { 't','u','p' },
                new [] { 'w', 'h', 'i' },
                new [] { 't', 's', 'u' },
                new [] { 'a', 't', 's' },
                new [] { 'h', 'a', 'p' },
                new [] { 't', 'i', 's' },
                new [] { 'w', 'h', 's' }
            };

            //Some other test data

            //char[][] triplets = new[]
            //{
            //    new [] { 'o','t',')' },
            //    new [] { 'n', 'm', ':' },
            //    new [] { 'c', 'h', ':' },
            //    new [] { 't', 'm', 'u' },
            //    new [] { 'm', 'c', ')' },
            //    new [] { 't', 'h', ')' },

            //};


            //char[][] triplets = new[]
            //{
            //    new [] { 'v','e','k' },
            //    new [] { 'a', 'i', 'o' },
            //    new [] { 'd', 'e', 'k' },
            //    new [] { 'i', 's', 'o' },
            //    new [] { 'v', 'i', 'o' },
            //    new [] { 'd', 'o', 'k' },
            //};



            List<char> secret = new List<char>();



            //In the provided "whatisup" example, the secret can be deduced by executing the triplets in the provided order.
            //For some of my test data, the order of the triplets could make a difference
            //To resolved this, I iterate over the triplets until no more swaps are detected.
            bool shouldRevaluate = true;

            while (shouldRevaluate)
            {
                shouldRevaluate = false;

                foreach (char[] triplet in triplets)
                {
                    //This is minimum position that a chracter can be inserted into the secret array
                    int minPosition = 0;

                    //Loop over each character in the triplet
                    //Nothing in this code limits the array size to three
                    //It will work with any sized multi-dimensional array
                    foreach (var c in triplet)
                    {
                        //Determine the current position of the character within the secret
                        //If the character is not currently in the secret, positionInSecret == -1 
                        int positionInSecret = secret.IndexOf(c);

                    
                        minPosition = Math.Max(positionInSecret, minPosition);

                        //Check to see if the character is already in the secret array
                        //If not, add it to the beginning
                        if (positionInSecret < 0)
                        {
                            secret.Insert(minPosition, c);
                            shouldRevaluate = true;
                        }
                        else
                        {
                            //If the character already exists, ensure it's in a position that is higher than the minimum
                            if (positionInSecret < minPosition)
                            {
                                //Remove the character from it's lower position, and reinsert it at a higher position
                                secret.Remove(c);
                                secret.Insert(Math.Min(minPosition, secret.Count), c);
                                shouldRevaluate = true;
                            }
                        }

                        minPosition++;
                    }
                }

            }
            string secretString = String.Join(String.Empty, secret);
            Console.WriteLine(secretString);
        }
    }
}
