using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class VideoGame : IComparable<VideoGame>
    {
        private string name;
        private string platform;
        private int year;
        private string genre;
        private string publisher;
        private double na_sales;
        private double eu_sales;
        private double jp_sales;
        private double other_sales;
        private double global_sales;

        public VideoGame()
        {
            Name = "";
            Platform = "";
            Year = 0;
            Genre = "";
            Publisher = "";
            Na_sales = 0;
            Eu_sales = 0;
            Jp_sales = 0;
            Other_sales = 0;
            Global_sales = 0;
        } 

        public VideoGame(string name, string platform, int year, string genre, string publisher, double na_sales, double eu_sales, double jp_sales, double other_sales, double global_sales)
        {
            this.Name = name;
            this.Platform = platform;
            this.Year = year;
            this.Genre = genre;
            this.Publisher = publisher;
            this.Na_sales = na_sales;
            this.Eu_sales = eu_sales;
            this.Jp_sales = jp_sales;
            this.Other_sales = other_sales;
            this.Global_sales = global_sales;
        }

        public string Name { get => name; set => name = value; }
        public string Platform { get => platform; set => platform = value; }
        public int Year { get => year; set => year = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public double Na_sales { get => na_sales; set => na_sales = value; }
        public double Eu_sales { get => eu_sales; set => eu_sales = value; }
        public double Jp_sales { get => jp_sales; set => jp_sales = value; }
        public double Other_sales { get => other_sales; set => other_sales = value; }
        public double Global_sales { get => global_sales; set => global_sales = value; }

        public int CompareTo(VideoGame other)
        {
            return Name.CompareTo(other.Name);
        } 

        public override string ToString()
        {
            string str = "name: " + Name+"\n";
            str += "platform: " + Platform+"\n";
            str += "year: " + Year+"\n";
            str += "genre: " + Genre + "\n";
            str += "publisher: " + Publisher + "\n";
            str += "NA Sales: " + Na_sales + "\n";
            str += "EU Sales: " + Eu_sales + "\n";
            str += "JP Sales: " + Jp_sales + "\n";
            str += "Other Sales: " + Other_sales + "\n";
            str += "Global Sales: " + Global_sales + "\n";
            return str;
        } 
    }
}
