using ListadoClientes.DAO.Entities;
using ListadoClientes.DAO.Util;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ListadoClientes.DAO.Repositories
{
    public class SqlServerClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public SqlServerClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Client>> GetAll()
        {
            List<Client> clientsList = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_CLIENTS", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using var resultSet = await cmd.ExecuteReaderAsync();

                while (await resultSet.ReadAsync())
                {
                    clientsList.Add(new Client
                    {
                        Id = resultSet.GetInt32("id"),
                        Name = resultSet.GetString("name"),
                        Email = resultSet.GetString("email"),
                        DocumentType = resultSet.GetString("documentType"),
                        DocumentNumber = resultSet.GetString("documentNumber"),
                        RegisterDate = resultSet.GetDateTime("registerDate")
                    });
                }

            }

            return clientsList;
        }

        public async Task<Client?> Get(int id)
        {
            Client? clientFound = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_CLIENT_BY_ID", connection);
                cmd.Parameters.AddWithValue("id", id);
                var statusCodeParameter = new SqlParameter("@statusCode", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = 4
                };
                cmd.Parameters.Add(statusCodeParameter);
                cmd.CommandType = CommandType.StoredProcedure;

                using var resultSet = await cmd.ExecuteReaderAsync();

                while (await resultSet.ReadAsync())
                {
                    clientFound = new Client
                    {
                        Id = resultSet.GetInt32("id"),
                        Name = resultSet.GetString("name"),
                        Email = resultSet.GetString("email"),
                        DocumentType = resultSet.GetString("documentType"),
                        DocumentNumber = resultSet.GetString("documentNumber"),
                        RegisterDate = resultSet.GetDateTime("registerDate")
                    };
                }
            }

            return clientFound;
        }

        
    }
}
