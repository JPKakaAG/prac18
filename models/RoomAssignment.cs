using System;
using System.Collections.Generic;

namespace prac18;

public partial class RoomAssignment
{
    public int Id { get; set; }

    public int? IdОтеля { get; set; }

    public int? IdСпортсмена { get; set; }

    public int? НомерКомнаты { get; set; }

    public virtual Hotel? IdОтеляNavigation { get; set; }

    public virtual Veteran? IdСпортсменаNavigation { get; set; }
}
