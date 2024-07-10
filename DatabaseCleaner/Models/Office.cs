using System;
using System.Collections.Generic;

namespace DatabaseCleaner.Models;

public partial class Office
{
    public Guid Id { get; set; }

    public string CityName { get; set; } = null!;

    public string RegistryPhoneNumber { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? DeletedTime { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Receptionist> Receptionists { get; set; } = new List<Receptionist>();
}
