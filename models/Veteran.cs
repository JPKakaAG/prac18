using System;
using System.Collections.Generic;

namespace prac18.models;

public partial class Veteran
{
    public int Id { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Отчество { get; set; }

    public int? Возраст { get; set; }

    public string? ВозрастнуюГруппа { get; set; }

    public int? НомерКомнаты { get; set; }
}
