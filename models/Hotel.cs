using System;
using System.Collections.Generic;

namespace prac18;

public partial class Hotel
{
    public int Id { get; set; }

    public string? НазваниеГостиницы { get; set; }

    public string? Адрес { get; set; }

    public string? Город { get; set; }

    public int? НомерКомнаты { get; set; }

    public virtual ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();
}
