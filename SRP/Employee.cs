namespace SRP
{

    #region Before
    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public decimal Salary { get; set; }
    //    public string Department { get; set; }
    //    public decimal CalculateYearlySalary()
    //    {
    //        return Salary * 12;
    //    }
    //    public void GenerateReport(string reportType)
    //    {

    //    }
    //    public void SendNotification(string recipient, string message)
    //    {
    //    
    //    }
    //}
    #endregion

    #region After

    public interface IEmployee
    {
        string? Name { get; set; }
        decimal Salary { get; set; }
        public string? Department { get; set; }
    }

    public class Employee : IEmployee
    {
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Department { get; set; }
    }

    public static class EmployeeSalaryCalculator
    {
        public static decimal CalculateYearlySalary(this IEmployee employee)
        {
            return employee.Salary * 12;
        }
    }

    public static class ReportGenerator
    {
        public static void GenerateReport(this IEmployee employee, string reportType)
        {
            // code to generate reprots
        }
    }

    public static class NotificationSender
    {
        public static void SendNotification(this IEmployee employee, string recipient, string message)
        {
            // code to send notification with a certain message to a certain recipient
        }
    }

    #endregion
}
