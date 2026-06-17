using System;
using System.IO;

public class EmployeeSRPViolation
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; } // Can be modified externally

    // Responsibility 1: Managing Core Employee Data
    public EmployeeSRPViolation(string id, string name, decimal hourlyRate, int hoursWorked)
    {
        Id = id;
        Name = name;
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    // Responsibility 2: Calculating Financial Business Logic
    public decimal CalculatePayslip()
    {
        // Simple logic: regular pay + overtime premium for hours over 40
        if (HoursWorked > 40)
        {
            int overtimeHours = HoursWorked - 40;
            return (40 * HourlyRate) + (overtimeHours * HourlyRate * 1.5m);
        }
        return HoursWorked * HourlyRate;
    }

    // Responsibility 3: Data Persistence (I/O operations)
    public void SaveToFile()
    {
        //string path = $"{Id}_payslip.txt";
        //string content = $"Employee: {Name}\nTotal Pay: {CalculatePayslip():C}";

        //// This links the business entity directly to the local file system
        //File.WriteAllText(path, content);
        //Console.WriteLine($"Payslip saved to {path}");

        // --- THE BUG INTRODUCED HERE ---
        // The developer wanted to sanitize the name for the file system layout.
        // But they accidentally re-assigned the class-level 'Name' property instead of a local variable!
        Name = Name.Replace(" ", "_");

        // Worse: They tried to sanitize the hours worked for the file view, 
        // accidentally resetting the actual employee data state before calculation!
        if (HoursWorked > 40)
        {
            Console.WriteLine("Log: High hours detected for file formatting.");
            // Accidentally mutated the operational state to fix a file layout concern:
            HoursWorked = 40;
        }

        string path = $"{Id}_{Name}_payslip.txt";

        // This call now calculates the WRONG amount because HoursWorked was mutated above!
        string content = $"Employee: {Name}\nTotal Pay: {CalculatePayslip():C}";

        File.WriteAllText(path, content);
        Console.WriteLine($"Payslip saved to {path}");
    }
}