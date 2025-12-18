public class CustomerSearch
{
    private readonly DatabaseContext db;

    public CustomerSearch(DatabaseContext database)
    {
        db = database;
    }

    public List<Customer> SearchByCountry(string country)
    {
        return SearchCustomers(c => c.Country.Contains(country));
    }

    public List<Customer> SearchByCompanyName(string companyName)
    {
        return SearchCustomers(c => c.CompanyName.Contains(companyName));
    }

    public List<Customer> SearchByContact(string contactName)
    {
        return SearchCustomers(c => c.ContactName.Contains(contactName));
    }

    private List<Customer> SearchCustomers(Func<Customer, bool> searchCriteria)
    {
        var query = from customer in db.customers
                    where searchCriteria(customer)
                    orderby customer.CustomerID ascending
                    select customer;

        return query.ToList();
    }

    public string ExportToCSV(List<Customer> customerData)
    {
        if (customerData == null || customerData.Count == 0)
        {
            return string.Empty;
        }

        StringBuilder csvBuilder = new StringBuilder();
        
        csvBuilder.AppendLine("CustomerID,CompanyName,ContactName,Country");

        foreach (var customer in customerData)
        {
            string csvLine = FormatCustomerAsCSVLine(customer);
            csvBuilder.AppendLine(csvLine);
        }

        return csvBuilder.ToString();
    }

    private string FormatCustomerAsCSVLine(Customer customer)
    {
        return $"{customer.CustomerID},{customer.CompanyName},{customer.ContactName},{customer.Country}";
    }
}