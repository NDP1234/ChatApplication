using System;
using System.Collections.Generic;

namespace dataModels.Entities;

public partial class Inductionuser
{
    public int Inductionuserid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public int? CreatorId { get; set; }

    public int? ModificationId { get; set; }

    public int? DeletorId { get; set; }

    public DateTime? ModificationTime { get; set; }

    public DateTime? CreationTime { get; set; }

    public byte[] InductionuserGuid { get; set; } = null!;

    public virtual ICollection<Smsmsgtoinductionuser> Smsmsgtoinductionusers { get; set; } = new List<Smsmsgtoinductionuser>();
}
