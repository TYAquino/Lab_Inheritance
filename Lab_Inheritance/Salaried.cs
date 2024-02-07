
namespace Lab_Inheritance
{
    public class Salaried : Employee
    {
        public double Salary { get; set; }

        public Salaried(int id, string name, string address, string phone, long sin, string doB, string dept, double salary) : base (id, name, address, phone, sin, doB, dept) 
        {
            Salary = salary; 
        }

        public double getPay()
        {
            return Salary;
        }
    }
}
