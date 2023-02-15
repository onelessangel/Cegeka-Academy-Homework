using System;
using System.Collections.Generic;
using GenericsDemo.Entities;

namespace GenericsDemo.Repositories;

public class OrganizationRepository {
    private readonly List<Organization> _organizations = new();

    public void Add(Organization organization) {
        _organizations.Add(organization);
    }

    public void Save() {
        foreach (var organization in _organizations) {
            Console.WriteLine(organization);
        }
    }
}