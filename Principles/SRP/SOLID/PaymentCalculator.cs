using System;
using System.IO;


// Business Logic Engine (Pure Functionality)
// This class only reads data; it contains zero side-effects and cannot mutate state.
public class PaymentCalculator
{
    public decimal CalculatePayslip(Employee employee)
    {
        if (employee.HoursWorked > 40)
        {
            int overtimeHours = employee.HoursWorked - 40;
            return (40 * employee.HourlyRate) + (overtimeHours * employee.HourlyRate * 1.5m);
        }
        return employee.HoursWorked * employee.HourlyRate;
    }
}
