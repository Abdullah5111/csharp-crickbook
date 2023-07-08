using System;
using System.Collections.Generic;

namespace CricBook;

public partial class Field
{
    public int Id { get; set; }

    public int HostId { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public TimeSpan OpeningTime { get; set; }

    public TimeSpan ClosingTime { get; set; }

    public byte[] PrimaryImage { get; set; } = null!;

    public byte[]? OptionalImage1 { get; set; }

    public byte[]? OptionalImage2 { get; set; }
}
