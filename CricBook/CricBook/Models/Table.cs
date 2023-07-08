using System;
using System.Collections.Generic;

namespace CricBook;

public partial class Table
{
    public int Id { get; set; }

    public int FieldId { get; set; }

    public int PlayerId { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan StartTime { get; set; }
}
