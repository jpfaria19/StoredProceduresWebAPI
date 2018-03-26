using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                sqlCommand.Parameters.AddWithValue("@SurName", friend.SurName);
                sqlCommand.Parameters.AddWithValue("@Email", friend.Email);
                sqlCommand.Parameters.AddWithValue("@Phone", friend.Phone);
                sqlCommand.Parameters.AddWithValue("@Birthday", friend.Birthday);
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

        public bool Update(Friend friend, Guid Id)
        {
            bool statusOk;
            SqlCommand sqlCommand = new SqlCommand("UpdateFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", friend.Id);
                sqlCommand.Parameters.AddWithValue("@Name", friend.Name);
                sqlCommand.Parameters.AddWithValue("@SurName", friend.SurName);
                sqlCommand.Parameters.AddWithValue("@Email", friend.Email);
                sqlCommand.Parameters.AddWithValue("@Phone", friend.Phone);
                sqlCommand.Parameters.AddWithValue("@Birthday", friend.Birthday);
                sqlCommand.ExecuteNonQuery();

                statusOk = true;
            }
            catch (Exception ex)
            {
                statusOk = false;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return statusOk;

        }

        public bool Delete(Guid Id)
        {
            bool statusOk;
            SqlCommand sqlCommand = new SqlCommand("DeleteFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                sqlCommand.ExecuteNonQuery();

                statusOk = true;
            }
            catch (Exception ex)
            {
                statusOk = false;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return statusOk;
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
                        Id = Guid.Parse(reader.GetString(0)),
                        Name = reader.GetString(1),
                        SurName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetInt32(4),
                        Birthday = reader.GetDateTime(5)
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
        public Friend GetById(Guid Id)
        {

            SqlCommand sqlCommand = new SqlCommand("GetFriend", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                _sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Friend friend = new Friend
                    {
                        Name = reader["Name"].ToString(),
                        SurName = reader["SurName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = (int)reader["Phone"],
                        Birthday = (DateTime)reader["Birthday"]
                    };

                    return friend;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
    }
}
