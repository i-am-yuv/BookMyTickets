using BookMyTickets.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketController : ControllerBase
    {

        db dbop = new db();
        string msg = string.Empty;

        // GET api/<ticketController>/5
        [HttpGet("{id}")]
        public List<ticketModel> GetTicketById(int id)
        {
            ticketModel ticket = new ticketModel();
            ticket.userId = id;
            ticket.type = "getid";

            DataSet ds = dbop.ticketGet(ticket, out msg);
            List<ticketModel> list = new List<ticketModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ticketModel
                {
                    ticketId = Convert.ToInt32(dr["ticketId"]),   
                    idMovies = Convert.ToInt32(dr["idMovies"]),
                    title = dr["title"].ToString(),
                    customerName = dr["customerName"].ToString(),
                    customerPhoneNumber = dr["customerPhoneNumber"].ToString(),
                    dateOfTheShow = dr["dateOfTheShow"].ToString(),
                    timeSlot = dr["timeSlot"].ToString(),
                    seats = Convert.ToInt32(dr["seats"]),
                    userId = Convert.ToInt32(dr["userId"])
                });
            }
            return list;
        }

        // POST api/<ticketController>
        [HttpPost]
        public List<ticketModel> Postticket([FromBody] ticketModel ticket)
        {
            List<ticketModel> list = new List<ticketModel>();
            string msg = string.Empty;
            try
            {
                ticket.type = "insert";
                msg = dbop.ticketOpt(ticket);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return list;
        }

        [HttpDelete("{id}")]
        public List<ticketModel> DeleteTicket(int id)
        {
            List<ticketModel> list = new List<ticketModel>();
            string msg = string.Empty;
            try
            {
                ticketModel ticket = new ticketModel();
                ticket.ticketId = id;
                ticket.type = "deleteById";
                
                msg = dbop.ticketOpt(ticket);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return list;
        }
    }
}
