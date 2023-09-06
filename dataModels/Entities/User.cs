using System;
using System.Collections.Generic;

namespace dataModels.Entities;

public partial class User
{
    public int Userid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreatorId { get; set; }

    public int? ModificationId { get; set; }

    public int? DeletorId { get; set; }

    public DateTime? ModificationTime { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? DeletionTime { get; set; }

    public virtual ICollection<Smsmsgtoinductionuser> SmsmsgtoinductionuserCreators { get; set; } = new List<Smsmsgtoinductionuser>();

    public virtual ICollection<Smsmsgtoinductionuser> SmsmsgtoinductionuserDeletors { get; set; } = new List<Smsmsgtoinductionuser>();

    public virtual ICollection<Smsmsgtoinductionuser> SmsmsgtoinductionuserModifications { get; set; } = new List<Smsmsgtoinductionuser>();

    public virtual ICollection<Smsmsgtouser> SmsmsgtouserCreators { get; set; } = new List<Smsmsgtouser>();

    public virtual ICollection<Smsmsgtouser> SmsmsgtouserDeletors { get; set; } = new List<Smsmsgtouser>();

    public virtual ICollection<Smsmsgtouser> SmsmsgtouserModifications { get; set; } = new List<Smsmsgtouser>();

    public virtual ICollection<Smsmsgtouser> SmsmsgtouserUsers { get; set; } = new List<Smsmsgtouser>();
}
