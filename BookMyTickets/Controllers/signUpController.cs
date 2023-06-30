using BookMyTickets.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class signUpController : ControllerBase
    {

        db dbop = new db();
        string msg = string.Empty;


        // POST api/<signUpController>
        [HttpPost]
        public List<SignUpModel> PostTheSignUP([FromBody] SignUpModel signUpObj )
        {
            SignUpModel signUp = new SignUpModel();
            signUp.type = "getByEmail";
            signUp.email = signUpObj.email;

            DataSet ds = dbop.signUpGet(signUp, out msg);

            List<SignUpModel> list = new List<SignUpModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SignUpModel
                {
                    idsignUp = Convert.ToInt32(dr["idsignUp"]),
                    email = dr["email"].ToString(),
                    passwordOfEmail = dr["passwordOfEmail"].ToString()
                });
            }
            if( list.Count == 0 )
            {
                string msg = string.Empty;
                try
                {
                    signUpObj.type = "insert";
                    msg = dbop.signUpPost(signUpObj);
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
                return list;
            }
            else
            {
                return list;    
            }
        }


        [HttpPost("/login")]
        public List<SignUpModel> GetTicketById(SignUpModel signUpObj )
        {
            SignUpModel signUp = new SignUpModel();
            signUp.type = "getByEmailAndPassword";
            signUp.passwordOfEmail = signUpObj.passwordOfEmail;
            signUp.email = signUpObj.email;

            DataSet ds = dbop.signUpGet(signUp, out msg);

            List<SignUpModel> list = new List<SignUpModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SignUpModel
                {
                    idsignUp = Convert.ToInt32(dr["idsignUp"]),
                    email = dr["email"].ToString(),
                    passwordOfEmail = dr["passwordOfEmail"].ToString()
                });
            }
            return list;   
        }
    }
}
