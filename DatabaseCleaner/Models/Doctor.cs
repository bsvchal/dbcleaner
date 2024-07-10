using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Doctor
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int CareerStartYear { get; set; }

    public bool IsWorking { get; set; }

    public string Specialization { get; set; } = null!;

    public Guid? OfficeId { get; set; }

    public Guid AccountId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Office? Office { get; set; }
}
