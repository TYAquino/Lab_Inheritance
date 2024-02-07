
namespace Lab_Inheritance
{
    public class Program
    {
        //public static int A { get; private set; }

        static List<Employee> LoadEmployeesListFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            { 
                string[] fileLines = File.ReadAllLines(filePath);
                foreach (string line in fileLines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(':');
                        int id = int.Parse(fields[0]);
                        char idFirstChar = fields[0][0];
                        switch (idFirstChar)
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                                employees.Add(new Salaried(int.Parse(fields[0]), fields[1], fields[2], fields[3],
                                                           long.Parse(fields[4]), fields[5],
                                                           fields[6], double.Parse(fields[7])));
                                break;
                            case '5':
                            case '6':
                            case '7':
                                employees.Add(new Wage(int.Parse(fields[0]), fields[1], fields[2], fields[3],
                                                         long.Parse(fields[4]), fields[5],
                                                         fields[6], double.Parse(fields[7]), double.Parse(fields[8])));
                                break;
                            case '8':
                            case '9':
                                employees.Add(new PartTime(int.Parse(fields[0]), fields[1], fields[2], fields[3],
                                                           long.Parse(fields[4]), fields[5],
                                                           fields[6], double.Parse(fields[7]), double.Parse(fields[8])));
                                break;
                        }
                    }
                }
            }
            return employees;
        }

        //Average pay of employees
        static double AveragePay(List<Employee> employees)
        {
            double sum = 0;
            foreach (Employee emp in employees) 
            {
                if (emp is Salaried)
                {
                    sum += ((Salaried)emp).getPay();
                }
                else if (emp is Wage)
                {
                    sum += ((Wage)emp).getPay();
                }
                else if (emp is PartTime)
                {
                    sum += ((PartTime)emp).getPay();
                }
            }
            return Math.Round(sum / employees.Count(), 2);
        }

        //Employee with highest pay
        static Wage HighestPayEmployee(List<Employee> employees) 
        {
            Wage highestPayEmp = null;
            double highestPay = 0;

            for (int i = 0; i < employees.Count; i++) 
            {
                Employee emp = employees[i];
                if (emp is Wage)
                {
                    Wage wages = (Wage)emp;
                    if (wages.getPay() > highestPay)
                    {
                        highestPay = wages.getPay();
                        highestPayEmp = wages;
                    }
                }    
            }
            return highestPayEmp;
        }

        //Employee with the lowest pay
        static Salaried LowestPayEmployee(List<Employee> employees)
        {
            Salaried lowestPayEmp = null ;
            double lowestPay = int.MaxValue;

            foreach (Employee emp in employees) 
            {
                if (emp is Salaried)
                {
                    Salaried salariedEmp = (Salaried)emp;
                    if (salariedEmp.getPay() < lowestPay)
                    { 
                        lowestPay = salariedEmp.getPay();
                        lowestPayEmp = salariedEmp;
                    }
                }
            }
            return lowestPayEmp;
        }

        //Percentage of employees' salary
        static double percentageOfSalaried(List<Employee> employees) 
        {
            int count = 0;
            foreach (Employee emp in employees) 
            {
                if (emp is Salaried)
                {
                    count++;
                }
            }
            return Math.Round(((double)count / employees.Count()) * 100, 2);
        }

        //Percentage of employees' wage
        static double percentageOfWage(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Wage)
                {
                    count++;
                }
            }
            return Math.Round(((double)count / employees.Count()) * 100, 2);
        }

        //Percentage of partTime employees
        static double percentageOfPartTime(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is PartTime)
                {
                    count++;
                }
            }
            return Math.Round(((double)count / employees.Count()) * 100, 2);
        }


        static void Main(string[] args)
        {
            string inputFilePath = @"../../../res/employees.txt";
            List<Employee> employees = LoadEmployeesListFromFile(inputFilePath);

            Console.WriteLine($"The average pay for all employees is: {AveragePay(employees)}");

            Wage wageEmp = HighestPayEmployee(employees);
            Console.WriteLine($"The Wages employee with the highest pay is: {wageEmp} \n\tPay: {wageEmp.getPay()}\n");

            Salaried salariedEmp = LowestPayEmployee(employees);
            Console.WriteLine($"The Salaried employee with the lowest pay is: {salariedEmp} \n\tSalary: {salariedEmp.getPay()} \n\tPay: {salariedEmp.getPay()}\n");

            Console.WriteLine($"The Percentage of Salaried employees is: {percentageOfSalaried(employees)}% \n");

            Console.WriteLine($"The Percentage of Wages employees is: {percentageOfWage(employees)}% \n");

            Console.WriteLine($"The Percentage of Part Time employees is: {percentageOfPartTime(employees)}% \n");

            Console.ReadKey();
        }
    }
}