

namespace Lab_Inheritance
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string DoB { get; set; }
        public string Dept { get; set; }

        public Employee(int id, string name, string address, string phone, long sin, string doB, string dept)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            DoB = doB;
            Dept = dept;
        }

        public override string ToString()
        {
            return $"\n\tID: {Id} \n\tName: {Name} \n\tAddress: {Address} \n\tPhone: {Phone} \n\tSIN: {Sin} \n\tDate of Birth: {DoB} \n\tDepartment: {Dept}";
        }

    }
}
