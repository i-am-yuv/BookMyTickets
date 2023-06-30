using System.Data;
using System.Data.SqlClient;

namespace BookMyTickets.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source =LAPTOP-BH2F0A6D\\SQLEXPRESS; Initial Catalog = ticketbookingapp; Integrated Security = True");   
    
        
        public string MovieOpt( MovieModel movie)
        {
            String msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Sp_Movies", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@idMovies", movie.idMovies);
                com.Parameters.AddWithValue("@title", movie.title);
                com.Parameters.AddWithValue("@descr", movie.descr);
                com.Parameters.AddWithValue("@src", movie.src);
                com.Parameters.AddWithValue("@type", movie.type);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";

            }
            catch(Exception ex) { 
                msg = ex.Message;   

            }
            finally
            {
                 if( con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        // get Record
        public DataSet MovieGet(MovieModel movie , out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Movies", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@idMovies", movie.idMovies);
                com.Parameters.AddWithValue("@title", movie.title);
                com.Parameters.AddWithValue("@descr", movie.descr);
                com.Parameters.AddWithValue("@src", movie.src);
                com.Parameters.AddWithValue("@type", movie.type);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
             return ds;
        }


        public string ticketOpt(ticketModel ticket)
        {
            String msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Sp_Ticket", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ticketId", ticket.ticketId);
                com.Parameters.AddWithValue("@idMovies", ticket.idMovies);
                com.Parameters.AddWithValue("@title", ticket.title);
                com.Parameters.AddWithValue("@customerName", ticket.customerName);
                com.Parameters.AddWithValue("@customerPhoneNumber", ticket.customerPhoneNumber);
                com.Parameters.AddWithValue("@dateOfTheShow", ticket.dateOfTheShow);
                com.Parameters.AddWithValue("@timeSlot", ticket.timeSlot);
                com.Parameters.AddWithValue("@type", ticket.type);
                com.Parameters.AddWithValue("@seats", ticket.seats);
                com.Parameters.AddWithValue("@userId", ticket.userId);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet ticketGet(ticketModel ticket, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Ticket", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ticketId", ticket.ticketId);
                com.Parameters.AddWithValue("@idMovies", ticket.idMovies);
                com.Parameters.AddWithValue("@title", ticket.title);
                com.Parameters.AddWithValue("@customerName", ticket.customerName);
                com.Parameters.AddWithValue("@customerPhoneNumber", ticket.customerPhoneNumber);
                com.Parameters.AddWithValue("@dateOfTheShow", ticket.dateOfTheShow);
                com.Parameters.AddWithValue("@timeSlot", ticket.timeSlot);
                com.Parameters.AddWithValue("@type", ticket.type);
                com.Parameters.AddWithValue("@seats", ticket.seats);
                com.Parameters.AddWithValue("@userId", ticket.userId);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return ds;
        }

        public string signUpPost(SignUpModel signUp)
        {
            String msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Sp_SignUp", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@idsignUp", signUp.idsignUp);
                com.Parameters.AddWithValue("@email", signUp.email);
                com.Parameters.AddWithValue("@passwordOfEmail", signUp.passwordOfEmail);
                com.Parameters.AddWithValue("@type", signUp.type);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet signUpGet(SignUpModel signUp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_SignUp", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@idsignUp", signUp.idsignUp);
                com.Parameters.AddWithValue("@email", signUp.email);
                com.Parameters.AddWithValue("@passwordOfEmail", signUp.passwordOfEmail);
                com.Parameters.AddWithValue("@type", signUp.type);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return ds;
        }



    }
}


