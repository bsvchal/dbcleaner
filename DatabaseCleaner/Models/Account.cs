using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool IsEmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? PhotoId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Photo? Photo { get; set; }

    public virtual ICollection<Receptionist> Receptionists { get; set; } = new List<Receptionist>();
}
