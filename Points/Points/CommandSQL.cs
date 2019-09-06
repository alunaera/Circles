using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Points
{
    class CommandSQL
    {
        public async void InsertPoint(SqlConnection sqlConnection, string color, int width, int weight)
        {
            SqlCommand commandInsert = new SqlCommand("INSERT INTO [Points] (Color, Width, Weight)" +
                                    "VALUES (@Color, @Width, @Weight)", sqlConnection);
            commandInsert.Parameters.AddWithValue("Color", color);
            commandInsert.Parameters.AddWithValue("Width", width);
            commandInsert.Parameters.AddWithValue("Weight", weight);
            await commandInsert.ExecuteNonQueryAsync();
        }

        public void SelectId(SqlConnection sqlConnection, int id)
        {
            SqlCommand commandId = new SqlCommand("SELECT MAX(Id) + 1 FROM [Points]", sqlConnection);
            var result = commandId.ExecuteScalar();
            id = Convert.ToInt16(result);
        }

        public async void AddStats(SqlConnection sqlConnection, int id, int bumpCount, int timeLife)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Stats] (Id, BumpCount, TimeLife)" +
                                "VALUES (@Id, @BumpCount, @TimeLife)", sqlConnection);

            command.Parameters.AddWithValue("Id", id);
            command.Parameters.AddWithValue("BumpCount", bumpCount);
            command.Parameters.AddWithValue("TimeLife", timeLife);
            await command.ExecuteNonQueryAsync();
        }
    }
}
