namespace TicketHub
{
    public class Concert
    {
        public int ConcertId { get; set; }
        //do i need any of this??? TODO
        //public string Artist { get; set; }
        //public string Venue { get; set; }
        //public DateOnly Date { get; set; }
        //public string? Summary { get; set; }

        public List<TicketPurchase> TicketPurchases { get; set; } = new();
    }
}
