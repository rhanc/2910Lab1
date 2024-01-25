using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            List<VideoGame> games = CreateObjects();
            SortGamesFromPublisher(games, "Ubisoft");
            Console.WriteLine("The list of games above are games by Ubisoft.\nPress enter to continue.");
            Console.ReadLine();
            FindPublisherPercentage(games, "Ubisoft");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            Console.WriteLine();
            FindGamesByGenre(games, "Action");
            Console.WriteLine("The list of games above are action games.\nPress enter to continue.");
            Console.ReadLine();
            FindGenrePercentage(games, "Action");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Please type the publisher of games you want to search for");
            string publisher = Console.ReadLine();
            PublisherData(games, publisher);
            Console.WriteLine("Please type the genre of games you want to search for");
            string genre = Console.ReadLine();
            GenreData(games, genre);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        public static string[] ReadInData()//Question 1
        { 
            return File.ReadAllLines("videogames.csv");
        }
        public static List<VideoGame> CreateObjects()//Question 1
        {
            List<VideoGame> games = new List<VideoGame>();
            string[] lines = ReadInData();
            int LineNum = 1;
            foreach (string line in lines)
            {
                if (LineNum != 1)
                {
                    //Console.WriteLine(line);
                    string[] arr = line.Split(',');
                    string name = arr[0];
                    string platform = arr[1];
                    int year = int.Parse(arr[2]);
                    string genre = arr[3];
                    string publisher = arr[4];
                    double na_sales = double.Parse(arr[5]);
                    double eu_sales = double.Parse(arr[6]);
                    double jp_sales = double.Parse(arr[7]);
                    double other_sales = double.Parse(arr[8]);
                    double global_sales = double.Parse(arr[9]);
                    VideoGame game = new VideoGame(name, platform, year, genre, publisher, na_sales, eu_sales, jp_sales, other_sales, global_sales);
                    games.Add(game);
                }
                LineNum++;
            }
            return games;
        }

        public static void SortGamesFromPublisher(List<VideoGame> games, string publisher)//Question 3
        {
            List<VideoGame> SortedList = (from game in games
                                          where game.Publisher == publisher
                                          orderby game.Name ascending
                                          select game).ToList();
            //List<VideoGame> SortedList  = SortUsingCompareTo(games);
            Console.WriteLine("Showing games by "+publisher);
            foreach (VideoGame game in SortedList)
            {
                Console.WriteLine(game);

                //Console.ReadLine();
            }
            //Console.ReadLine();
        }
        public static void FindPublisherPercentage(List<VideoGame> games, string publisher)//Question 4
        {
            int count = 0;
            double percent=0;
            List<VideoGame> SortedList = (from game in games
                                          where game.Publisher.ToLower() == publisher.ToLower()

                                          select game).ToList();
             
            count = SortedList.Count;
            double result = (((double)count / (double)games.Count) * 100.00);
            result = Math.Round(result,2);
            int total = games.Count;
            Console.WriteLine("Out of "+ (games.Count+1).ToString() + " games, " +count+" are developed by "+ publisher);
            Console.WriteLine("Which is " + result+"%");
        }
        public static void FindGamesByGenre(List<VideoGame> games, string genre)//Question 5
        {
            int count = 0;
            List<VideoGame> SortedList = (from game in games
                                          where game.Genre.ToLower() == genre.ToLower() 
                                          orderby game.Name ascending
                                          select game).ToList();

            count = SortedList.Count;
            Console.WriteLine("Showing games by "+genre);
            foreach (VideoGame game in SortedList)
            {
                Console.WriteLine(game);

                //Console.ReadLine();
            }
        }



        public static void FindGenrePercentage(List<VideoGame> games, string genre)//Question 6
        {
            int count = 0;
            double percent = 0;
            List<VideoGame> SortedList = (from game in games
                                          where game.Genre.ToLower() == genre.ToLower()

                                          select game).ToList();

            count = SortedList.Count;
            double result = (((double)count / (double)games.Count) * 100.00);
            result = Math.Round(result, 2);
            Console.WriteLine("Out of " +(games.Count + 1).ToString() + " games, " + count + " are "+genre+" games.");
            Console.WriteLine("Which is " + result + "%");
        }

        public static void PublisherData(List<VideoGame> games, string publisher)
        {
            SortGamesFromPublisher(games, publisher); 
            FindPublisherPercentage(games, publisher);
        }

        public static void GenreData(List<VideoGame> games, string Genre)
        {
            FindGamesByGenre(games, Genre);
            FindGenrePercentage(games, Genre);
        } 
    }
}
