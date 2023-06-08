using CinemaTicketSalesAutomation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesAutomation.Helpers
{
    public class Helper
    {
        public static List<Movie> CreateMovies()
        {
            string basePath = "C:\\Users\\yalpe\\OneDrive\\Masaüstü\\Gelişim Süreci\\C# - yeni\\CinemaTicketSalesAutomation\\CinemaTicketSalesAutomation\\Pictures\\";

            return new List<Movie>()
            {
                new Movie()
                {
                    movieName = "Avatar",
                    category = Category.bilim_kurgu,
                    minute = "2:40",
                    price = 50,
                    picturePath = basePath + "avatar.jpg.jpg"
                },
                new Movie()
                {
                    movieName = "Clean",
                    category = Category.macera,
                    minute = "2:10",
                    price = 40,
                    picturePath = basePath + "desktop-wallpaper-clean-movie-posters-2022.jpg"
                },
                new Movie()
                {
                    movieName = "Joker",
                    category = Category.gerilim,
                    minute = "1:50",
                    price = 30,
                    picturePath = basePath + "joker-film-poster-2019.jpg"
                },
                new Movie()
                {
                    movieName = "Matrix",
                    category = Category.bilim_kurgu,
                    minute = "2:10",
                    price = 80,
                    picturePath = basePath + "matrix.jpg"
                },
                new Movie()
                {
                    movieName = "Tron",
                    category = Category.bilim_kurgu,
                    minute = "2:19",
                    price = 60,
                    picturePath = basePath + "tron.jpg"
                },
                new Movie()
                {
                    movieName = "Who am i",
                    category = Category.komedi,
                    minute = "2:39",
                    price = 30,
                    picturePath = basePath + "whoami.jpg"
                }
            };
        }
    }
}
