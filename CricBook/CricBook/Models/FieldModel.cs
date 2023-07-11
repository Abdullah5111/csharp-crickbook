public class FieldComponentViewModel
{
    public byte[] PrimaryImage { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"Field ID: {Id}, City: {City}, Address: {Address}, Opening Time: {OpeningTime}, Closing Time: {ClosingTime}";
    }
}