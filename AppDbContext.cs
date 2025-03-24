using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCSV
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(ConfigurationManager.ConnectionStrings["ProdmonEntities"].ConnectionString) { }

        public DbSet<ProcessInfoHistorical> ProcessInfoHistorical { get; set; }

        public void EnsureTableExists()
        {
            string currentMonth = DateTime.Now.ToString("yyyyMM");
            string tableName = $"IoTUtility_T_ProcessInfo_Historical_{currentMonth}";

            string createTableQuery = $@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}')
        BEGIN
            CREATE TABLE {tableName} (
                Id BIGINT IDENTITY(1,1) PRIMARY KEY,
                MachineCode NVARCHAR(20),
                Date DATE,
                Time TIME,
                {string.Join(", ", Enumerable.Range(1, 50).Select(i => $"Column{i:D2} NVARCHAR(50)"))},
                {string.Join(", ", Enumerable.Range(1, 10).Select(i => $"FormulatedColumn{i:D2} NVARCHAR(50)"))},
                IsActive BIT,
                CreatedDate DATETIME,
                CreatedBy VARCHAR(50)
            )
        END";

            this.Database.ExecuteSqlCommand(createTableQuery);
        }
    }
}
