using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dataModels.Entities;

public partial class Smsmsgtouser
{
    public int Id { get; set; }

    public byte[] UserId { get; set; } = null!;

    public string Sms { get; set; } = null!;

    public bool IsDelete { get; set; }

    public byte[] CreatorId { get; set; } = null!;

    public byte[]? ModificationId { get; set; }

    public byte[]? DeletorId { get; set; }

    public DateTime? ModificationTime { get; set; }

    public DateTime? CreationTime { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte[] UsermsgGuid { get; set; } = null!;

    public virtual User Creator { get; set; } = null!;

    public virtual User? Deletor { get; set; }

    public virtual User? Modification { get; set; }

    public virtual User User { get; set; } = null!;
}
