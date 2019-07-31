using System;
using System.Globalization;
using System.Collections.Generic;
using tax_payer.Entities;

namespace tax_payer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Tax payer #{0} data: ", i + 1);

                Console.Write("Individual or company (i/c): ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, annualIncome, healthExpenditures));
                }
                else if(ch == 'c')
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, annualIncome, numberOfEmployees));
                }
            }

            double totalTaxes = 0.0;
            Console.WriteLine("------------------");
            Console.WriteLine("TAXES PAID: ");
            foreach(TaxPayer tp in taxPayers)
            {
                Console.WriteLine(tp.Name + ": $" + tp.Tax().ToString("F2", CultureInfo.InvariantCulture));
                totalTaxes += tp.Tax();
            }
            Console.WriteLine("------------------");
            Console.Write("TOTAL TAXES: ");
            Console.WriteLine(totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}