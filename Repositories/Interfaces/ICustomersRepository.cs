public interface ICustomersRepository {
  Task<IEnumerable<Customers>> GetAllCustomers();
  Task <Customers> GetCustomerById(int id);
  Task<bool> CreateCustomer(Customers customers);
  Task UpdateCustomer2(int id);
  Task DeleteCustomerById(int id);
}