
using System.Data;
using Dapper;

public class CustomersRepository : ICustomersRepository {


  private readonly IDbConnection _dbConnection;

  public CustomersRepository(IDbConnection dbConnection) 
  {
    _dbConnection = dbConnection;
  }

  public async Task<IEnumerable<Customers>> GetAllCustomers()
    {
        var query = @"SELECT * FROM CUSTOMERS";
        return await _dbConnection.QueryAsync<Customers>(query);
    }

      public async Task <Customers> GetCustomerById(int id)
    {
        var query = @"SELECT * FROM CUSTOMERS WHERE CUSTOMER_ID = @CUSTOMER_ID";
        return await _dbConnection.QuerySingleOrDefaultAsync<Customers>(query, new {CUSTOMER_ID = id});
        
    }


    public async Task<bool> CreateCustomer(Customers customers)
    {
        var query = @"INSERT INTO CUSTOMERS (NAME, CPF, RG, BIRTH_DATE, ADDRESS, PHONE_NUMBER, EMAIL, CREATE_DATE) VALUES (@NAME, @CPF, @RG, @BIRTH_DATE, @ADDRESS, @PHONE_NUMBER, @EMAIL, @CREATE_DATE)";
        int value = await _dbConnection.ExecuteAsync(query, customers);
        return value > 0;
    }

    public async Task UpdateCustomer2(int id)
    {
       var query = "UPDATE CUSTOMERS SET NAME = @NAME, CPF = @CPF, RG = @RG, BIRTH_DATE = @BIRTH_DATE, ADDRESS = @ADDRESS, PHONE_NUMBER = @PHONE_NUMBER, EMAIL = @EMAIL, CREATE_DATE = @CREATE_DATE WHERE CUSTOMER_ID = @CUSTOMER_ID";
        await _dbConnection.ExecuteAsync(query);

    }
    // public async Task UpdateCustomer(int id)
    // {
    //   var query = @"UPDATE CUSTOMERS 
    //     SET NAME = @NAME, 
    //       CPF = @CPF, 
    //       RG = @RG, 
    //       BIRTH_DATE = @BIRTH_DATE, 
    //       ADDRESS = @ADDRESS, 
    //       PHONE_NUMBER = @PHONE_NUMBER, 
    //       EMAIL = @EMAIL, 
    //       CREATE_DATE = @CREATE_DATE 
    //     WHERE 
    //     CUSTOMER_ID = @CUSTOMER_ID";

    //    await _dbConnection.ExecuteAsync(query);
      
    // }

      public async Task DeleteCustomerById(int id)
    {
        var query = @"DELETE FROM CUSTOMERS WHERE CUSTOMER_ID = @CUSTOMER_ID";
        await _dbConnection.ExecuteAsync(query, new {CUSTOMER_ID = id});
        
    }
}