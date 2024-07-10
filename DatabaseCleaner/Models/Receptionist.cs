using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Receptionist
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public Guid AccountId { get; set; }

    public Guid OfficeId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;
}
