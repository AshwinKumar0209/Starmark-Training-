using ADO_Week3.CodeFileApproach;
using SampleConApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Week3.CodeFileApproach
{
    public class Movies {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int DirectorId { get; set; }

        
    }
   public class Directors {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public ICollection<Movies> movies { get; set; }
    }

  public  class codeFileApproach
    {
      static  MovieDb context = new MovieDb();

        static void Main(string[] args)
        {
            UIRun();
            //AddData();
            // Update();
            //DeleteMovie();
           // GetAllMovies();

        }

        private static void UIRun()
        {
            int choice = 0;
            Console.WriteLine("Enter 1 to Add Movie");
            Console.WriteLine("Enter 2 to Update Movie");
            Console.WriteLine("Enter 3 to Delete Movie");
            Console.WriteLine("Enter 1 to Get All Movies");
            try
            {
                choice = utilities.GetNumber("Enter choice");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            switch (choice)
            {
                case 1: AddHelper();
                    break;
                default:
                    break;
            }
        }

        private static void AddHelper()
        {
            int DirectorId = utilities.GetNumber("Director ID");
            string Directorname = utilities.Prompt("Director Name");
            context.directors.Add(new Directors
            {
                DirectorId = DirectorId,
                DirectorName = Directorname
            });
          
            context.SaveChanges();
            context.movies.Add(new Movies
            {
                MovieId = 2,
                DirectorId = 2,
                Duration = 148,
                Title = "Master"
            });
            context.SaveChanges();
        }

        private static void GetAllMovies()
        {
            int id=utilities.GetNumber("Director ID");
            var record = context.movies.FirstOrDefault((e)=>e.DirectorId==id);
            //foreach (var item in record)
            //{
            //    Console.WriteLine(item.MovieId+"-"+item.Title);
            //}
            Console.WriteLine(record.Title);
        }

        private static void DeleteMovie()
        {
            int id = utilities.GetNumber("Enter ID");
            var record = context.movies.FirstOrDefault((e) => e.DirectorId == id);
            context.movies.Remove(record);
            context.SaveChanges();
        }

        private static void Update()
        {
            int id = utilities.GetNumber("Enter ID");
            var record=context.movies.FirstOrDefault((e)=>e.DirectorId==id);
            record.Title = "Interstellar";
            record.Duration = 149;
            record.DirectorId = 1;
            context.SaveChanges();

        }

 
    }


}
