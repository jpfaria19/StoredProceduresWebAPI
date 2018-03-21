using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FriendRepository
    {
        private String _connectionString;
        private SqlConnection _sqlConnection;

        public FriendRepository()
        {
            _connectionString = Data.Properties.Settings.Default.DbConnectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public void Add(Friend friend)
        {
            SqlCommand sqlCommand = new SqlCommand("CreateFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", friend.Id);
                sqlCommand.Parameters.AddWithValue("@Name", friend.Name);
                sqlCommand.Parameters.AddWithValue("@Age", friend.Age);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void Update(Friend friend)
        {
            SqlCommand sqlCommand = new SqlCommand("UpdateFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", friend.Id);
                sqlCommand.Parameters.AddWithValue("@Name", friend.Name);
                sqlCommand.Parameters.AddWithValue("@Age", friend.Age);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void Delete(Friend friend)
        {
            SqlCommand sqlCommand = new SqlCommand("DeleteFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", friend.Id);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public IEnumerable<Friend> GetAll()
        {
            List<Friend> friends = new List<Friend>();

            SqlCommand sqlCommand = new SqlCommand("GetAllFriends", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Friend friend = new Friend
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"]
                    };
                    friends.Add(friend);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }

            return friends;
        }
    }
}
