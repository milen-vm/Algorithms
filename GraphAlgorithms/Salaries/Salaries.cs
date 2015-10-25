using System;
using System.Collections.Generic;
using System.Linq;

class Salaries
{
    static List<int>[] employees;
    static long[] salaries;

    static void Main()
    {
        int employeesCount = int.Parse(Console.ReadLine());
        employees = new List<int>[employeesCount];
        salaries = new long[employeesCount];

        ReadEmployees(employeesCount);

        for(int i = 0; i < employees.Length; i++)
        {
            DFS(i);
        }

        Console.WriteLine(salaries.Sum());
    }

    private static void ReadEmployees(int count)
    {
        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();
            employees[i] = new List<int>();

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'Y')
                {
                    employees[i].Add(j);
                }
            }
        }
    }

    private static void DFS(int employe)
    {
        if(salaries[employe] > 0)
        {
            return;
        }
        
        if(employees[employe].Count == 0)
        {
            salaries[employe] = 1;
            return;
        }

        foreach(var e in employees[employe])
        {
            if(salaries[e] == 0)
            {
                DFS(e);
            }

            salaries[employe] += salaries[e];
        }
    }
}
