using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? PhoneNumber { get; set; }

    public int? MotorcycleId { get; set; }

    public int? PaymentId { get; set; }

    public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();

    public virtual CustomerMotorcycle? Motorcycle { get; set; }

    public virtual PaymentTable? Payment { get; set; }
}
