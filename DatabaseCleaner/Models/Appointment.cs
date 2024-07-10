using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Appointment
{
    public Guid Id { get; set; }

    public DateTime ScheduledTime { get; set; }

    public bool IsApproved { get; set; }

    public decimal Price { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
