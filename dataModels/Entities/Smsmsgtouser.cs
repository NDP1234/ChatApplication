using System;
using System.Collections.Generic;

namespace dataModels.Entities;

public partial class Smsmsgtouser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Sms { get; set; } = null!;

    public bool IsDelete { get; set; }

    public int? CreatorId { get; set; }

    public int? ModificationId { get; set; }

    public int? DeletorId { get; set; }

    public DateTime? ModificationTime { get; set; }

    public DateTime? CreationTime { get; set; }

    public virtual User? Creator { get; set; }

    public virtual User? Deletor { get; set; }

    public virtual User? Modification { get; set; }

    public virtual User User { get; set; } = null!;
}
