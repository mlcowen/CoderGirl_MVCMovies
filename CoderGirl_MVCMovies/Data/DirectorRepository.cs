using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        static List<Director> directors = new List<Director>();
        static int nextId = 1;

        public void Delete(int id)
        {
            directors.RemoveAll(d => d.Id == id);
        }

        public Director GetById(int id)
        {
            return directors.SingleOrDefault(d => d.Id == id);
        }

        public List<Director> GetDirectors()
        {
            return directors;
        }

        public int Save(Director director)
        {
            director.Id = nextId++;
            directors.Add(director);
            return director.Id;
        }

        public void Update(Director director)
        {
            //there are many ways to accomplish this, this is just one possible way
            //the upside is that it is relatively simple, 
            //the (possible) downside is that it doesn't preserve the order in the list
            //as the AC doesn't specify, I am going with the simpler solution
            //once we start using the database this pattern will be simplified
            this.Delete(director.Id);
            directors.Add(director);
        }
    }
}
