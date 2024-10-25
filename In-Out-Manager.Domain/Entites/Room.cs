namespace In_Out_Manager.Domain.Entites
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
