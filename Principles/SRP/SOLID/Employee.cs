using System;

public class Employee
{
    // Read-only properties. Once set via the constructor, they can never change.
    public string Id { get; }
    public string Name { get; }
    public decimal HourlyRate { get; }
    public int HoursWorked { get; }

    // Explicit Constructor required to populate the read-only fields
    public Employee(string id, string name, decimal hourlyRate, int hoursWorked)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    // --- OPTIONAL BOILERPLATE (Records give you this automatically) ---

    // Classic Value-Based Equality Override
    public override bool Equals(object? obj)
    {
        if (obj is not Employee other) return false;

        return Id == other.Id &&
               Name == other.Name &&
               HourlyRate == other.HourlyRate &&
               HoursWorked == other.HoursWorked;
    }

    // Always override GetHashCode when overriding Equals
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, HourlyRate, HoursWorked);
    }

    // Clean diagnostic string representation
    public override string ToString()
    {
        return $"Employee {{ Id = {Id}, Name = {Name}, HourlyRate = {HourlyRate}, HoursWorked = {HoursWorked} }}";
    }
}