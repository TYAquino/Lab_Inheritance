
namespace Lab_Inheritance
{
    public class Wage : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }

        public Wage(int id, string name, string address, string phone, long sin, string doB, string dept, double rate, double hours) : base (id, name, address, phone, sin, doB, dept)
        {
            Rate = rate;    
            Hours = hours;
        }

        public double getPay()
        {
            double totalPay = 0;
            double salary = 0;
            if (Hours <= 40)
            {
                salary = Hours * Rate; 
            }
            else if (Hours > 40)
            {
                double basePay = 40 * Rate;
                double overtimeHours = (Hours - 40) * 1.5;
                double overtimePay = overtimeHours * Rate;
                totalPay = basePay + overtimePay;
            }
            return salary + totalPay;
        }
    }
}
