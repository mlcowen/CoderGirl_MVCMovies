using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public interface IDirectorRepository
    {
        int Save(Director director);
        
        List<Director> GetDirectors();

        Director GetById(int id);

        void Update(Director director);

        void Delete(int id);
    }
}
