using BookMyTickets.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        db dbop = new db();
        string msg  = string.Empty; 

        // GET: api/<MovieController>
        [HttpGet]
        public List<MovieModel> Get()
        {
            MovieModel movie = new MovieModel();
            movie.type = "get" ;
            DataSet ds = dbop.MovieGet(movie, out msg);
            List<MovieModel> list = new List<MovieModel>();
            foreach ( DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new MovieModel
                {
                    idMovies = Convert.ToInt32(dr["idMovies"]),
                    title = dr["title"].ToString(),
                    descr = dr["descr"].ToString(),
                    src = dr["src"].ToString()
                });
            }
            return list;
        }

        // POST api/<MovieController>
        [HttpPost]
        public List<MovieModel> PostMovie([FromBody] MovieModel movie)
        {
            List<MovieModel> list = new List<MovieModel>();
            string msg = string.Empty;
            try
            {
                movie.type = "insert";
                msg = dbop.MovieOpt(movie); 
            }
            catch(Exception e)
            {
                msg = e.Message;
            }
            return list;
        }


        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public List<MovieModel> DeleteMovie(int id)
        {
            List<MovieModel> list = new List<MovieModel>();
            string msg = string.Empty;
            try
            {
                MovieModel movie = new MovieModel();
                movie.idMovies = id;
                movie.type = "delete";
                msg = dbop.MovieOpt(movie);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return list;
        }
    }
}
