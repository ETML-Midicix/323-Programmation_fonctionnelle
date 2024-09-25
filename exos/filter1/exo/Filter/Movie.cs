using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    internal class Movie
    {
        private string title;
        public string Title { get { return title; } set { title = value; } }

        private string genre;
        public string Genre { get {  return genre; } set {  genre = value; } }

        private double rating;
        public double Rating { get { return rating; } set { rating = value; } }

        private int year;
        public int Year { get { return year; } set { year = value; } }

        private string[] languageOptions;
        public string[] LanguageOptions { get { return languageOptions; } set { languageOptions = value; } }

        private string[] streamingPlatforms;
        public string[] StreamingPlatforms { get { return streamingPlatforms; } set { streamingPlatforms = value; } }
    }
}
