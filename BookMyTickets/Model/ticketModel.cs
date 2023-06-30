namespace BookMyTickets.Model
{
    public class ticketModel
    {
        public int ticketId { get; set; }

        public int idMovies { get; set; } = 0 ;
        public String customerName { get; set; } = "";

        public String title { get; set; } = "";
        public String customerPhoneNumber { get; set; } = "";

        public String dateOfTheShow { get; set; } = "";

        public String timeSlot { get; set; } = "";

        public String type { get; set; } = "";

        public int seats { get; set; } = 0;

        public int userId { get; set; } = 0;
    }
}
