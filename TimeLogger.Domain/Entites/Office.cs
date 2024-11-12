﻿namespace TimeLogger.Domain.Entites
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Room>? Rooms { get; set; }
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
        public ICollection<CheckOut> CheckOuts { get; set; } = new List<CheckOut>();
    }
}