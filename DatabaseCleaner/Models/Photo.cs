using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Photo
{
    public Guid Id { get; set; }

    public string Path { get; set; } = null!;

    public Guid AccountId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
