using BP.Simulation.Models;
using BP.Simulation.Repositories;
using BP.Simulation.Services;
using BP.Simulation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Simulation.ViewModels
{
    public class CustomerViewModel
    {
        private readonly GeneratorService _generatorService;
        private readonly CustomerRepository _customerRepository;
        private readonly EntitesLists _entitesLists;

        internal CustomerViewModel(GeneratorService generatorService, CustomerRepository customerRepository, EntitesLists entitesLists)
        {
            _generatorService = generatorService;
            _customerRepository = customerRepository;
            _entitesLists = entitesLists;
        }

        public async Task GenerateCustomer()
        {
            Customer customer = _generatorService.GenerateCustomer();
            await _customerRepository.AddCustomerAsync(customer);
            _entitesLists.Customers.Add(customer);
        }

        public async Task FillCustomers()
        {
            _entitesLists.Customers.AddRange(await _customerRepository.GetCustomersAsync());
            _entitesLists.Customers.Select(x => )
        }
    }
}
