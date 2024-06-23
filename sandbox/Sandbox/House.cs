class House
{
    List<Room> rooms = new List<Room>(); // has rooms
    public House(List<Room> rooms)
    {
        this.rooms = rooms;
    }

    public List<Room> GetRooms()
    {
        return rooms;
    }
}