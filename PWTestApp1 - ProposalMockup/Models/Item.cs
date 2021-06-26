using System;
using SQLite;

namespace PWTestApp1___ProposalMockup.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}