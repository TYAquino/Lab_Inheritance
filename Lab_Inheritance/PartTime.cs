

namespace Lab_Inheritance
{
    public class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }

        public PartTime(int id, string name, string address, string phone, long sin, string doB, string dept, double rate, double hours) : base (id, name, address, phone, sin, doB, dept)
        {
            Rate = rate;
            Hours = hours;
        }
        
        public double getPay() 
        {
            double salary = Hours * Rate;
            return salary;
        }
    }
}
