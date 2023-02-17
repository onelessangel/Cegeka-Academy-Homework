using System;
using System.Collections.Generic;
using GenericsDemo.Entities;

namespace GenericsDemo.Repositories;

public class EmployeeRepository {
    private readonly List<Employee> _employees = new();

    public void Add(Employee employee) {
        _employees.Add(employee);
    }

    public void Save() {
        foreach (var employee in _employees) {
            Console.WriteLine(employee);
        }
    }
}