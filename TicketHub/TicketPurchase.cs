﻿namespace TicketHub
{
    public class TicketPurchase
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public int Quantity { get; set; }
        public string? CreditCard { get; set; }
        public string? Expiry { get; set; }
        public string? SecurityCode { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; } 
    }
}
