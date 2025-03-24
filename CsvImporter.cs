using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Configuration;

namespace AutoCSV
{
    public class CsvImporter
    {
        public static List<ProcessInfoHistorical> ReadCsv(string filePath)
        {
            var records = new List<ProcessInfoHistorical>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false, // Tidak membaca header
                Delimiter = "," // Pastikan delimiter adalah koma
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    try
                    {
                        var csvFields = csv.Parser.Record; // Ambil semua field dalam satu baris CSV

                        if (csvFields.Length < 32) // Sesuaikan dengan jumlah minimal field yang diperlukan
                        {
                            Console.WriteLine("Warning: Data CSV memiliki jumlah kolom kurang dari yang diharapkan.");
                            continue; // Lewati baris ini
                        }

                        var record = new ProcessInfoHistorical
                        {
                            MachineCode = "GSK-P01-L01-M01",
                            Date = !string.IsNullOrWhiteSpace(csvFields[0]) &&
                                       DateTime.TryParseExact(csvFields[0].Trim(), "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate)
                                    ? parsedDate
                                    : (DateTime?)null,
                            Time = TimeSpan.TryParse(csvFields[1], out TimeSpan parsedTime) ? parsedTime : (TimeSpan?)null,

                            Column01 = csvFields.Length > 2 ? csvFields[2] : null,
                            Column02 = csvFields.Length > 3 ? csvFields[3] : null,
                            Column03 = csvFields.Length > 4 ? csvFields[4] : null,
                            Column04 = csvFields.Length > 5 ? csvFields[5] : null,
                            Column05 = csvFields.Length > 6 ? csvFields[6] : null,
                            Column06 = csvFields.Length > 7 ? csvFields[7] : null,
                            Column07 = csvFields.Length > 8 ? csvFields[8] : null,
                            Column08 = csvFields.Length > 9 ? csvFields[9] : null,
                            Column09 = csvFields.Length > 10 ? csvFields[10] : null,
                            Column10 = csvFields.Length > 11 ? csvFields[11] : null,
                            Column11 = csvFields.Length > 12 ? csvFields[12] : null,
                            Column12 = csvFields.Length > 13 ? csvFields[13] : null,
                            Column13 = csvFields.Length > 14 ? csvFields[14] : null,
                            Column14 = csvFields.Length > 15 ? csvFields[15] : null,
                            Column15 = csvFields.Length > 16 ? csvFields[16] : null,
                            Column16 = csvFields.Length > 17 ? csvFields[17] : null,
                            Column17 = csvFields.Length > 18 ? csvFields[18] : null,
                            Column18 = csvFields.Length > 19 ? csvFields[19] : null,
                            Column19 = csvFields.Length > 20 ? csvFields[20] : null,
                            Column20 = csvFields.Length > 21 ? csvFields[21] : null,
                            Column21 = csvFields.Length > 22 ? csvFields[22] : null,
                            Column22 = csvFields.Length > 23 ? csvFields[23] : null,
                            Column23 = csvFields.Length > 24 ? csvFields[24] : null,
                            Column24 = csvFields.Length > 25 ? csvFields[25] : null,
                            Column25 = csvFields.Length > 26 ? csvFields[26] : null,
                            Column26 = csvFields.Length > 27 ? csvFields[27] : null,
                            Column27 = csvFields.Length > 28 ? csvFields[28] : null,
                            Column28 = csvFields.Length > 29 ? csvFields[29] : null,
                            Column29 = csvFields.Length > 30 ? csvFields[30] : null,
                            Column30 = csvFields.Length > 31 ? csvFields[31] : null,

                            IsActive = true, // Default aktif
                            CreatedDate = DateTime.Now, // Timestamp sekarang
                            CreatedBy = "SYSTEM" // Sesuai parameter
                        };

                        records.Add(record);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing row: {ex.Message}");
                    }
                }
            }

            return records;

        }

        public static void ImportToDatabase()
        {
            string filePath = @"D:\2 - WORK\2022 Nov - PT Panasonic Gobel Energy Indonesia\Bank Document\1. PECGI IOT Gasket\PLC Data Example\LOG53010_ProcessInfo_temporary_part11.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            var records = ReadCsv(filePath);

            if (records.Count == 0)
            {
                Console.WriteLine("No records to insert.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ProdmonEntities"].ConnectionString;
            string tableName = GetDynamicTableName();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = tableName;

                    // Mapping CSV columns to SQL table columns
                    bulkCopy.ColumnMappings.Add("MachineCode", "MachineCode");
                    bulkCopy.ColumnMappings.Add("Date", "Date");
                    bulkCopy.ColumnMappings.Add("Time", "Time");
                    bulkCopy.ColumnMappings.Add("Column01", "Column01");
                    bulkCopy.ColumnMappings.Add("Column02", "Column02");
                    bulkCopy.ColumnMappings.Add("Column03", "Column03");
                    bulkCopy.ColumnMappings.Add("Column04", "Column04");
                    bulkCopy.ColumnMappings.Add("Column05", "Column05");
                    bulkCopy.ColumnMappings.Add("Column06", "Column06");
                    bulkCopy.ColumnMappings.Add("Column07", "Column07");
                    bulkCopy.ColumnMappings.Add("Column08", "Column08");
                    bulkCopy.ColumnMappings.Add("Column09", "Column09");
                    bulkCopy.ColumnMappings.Add("Column10", "Column10");
                    bulkCopy.ColumnMappings.Add("Column11", "Column11");
                    bulkCopy.ColumnMappings.Add("Column12", "Column12");
                    bulkCopy.ColumnMappings.Add("Column13", "Column13");
                    bulkCopy.ColumnMappings.Add("Column14", "Column14");
                    bulkCopy.ColumnMappings.Add("Column15", "Column15");
                    bulkCopy.ColumnMappings.Add("Column16", "Column16");
                    bulkCopy.ColumnMappings.Add("Column17", "Column17");
                    bulkCopy.ColumnMappings.Add("Column18", "Column18");
                    bulkCopy.ColumnMappings.Add("Column19", "Column19");
                    bulkCopy.ColumnMappings.Add("Column20", "Column20");
                    bulkCopy.ColumnMappings.Add("Column21", "Column21");
                    bulkCopy.ColumnMappings.Add("Column22", "Column22");
                    bulkCopy.ColumnMappings.Add("Column23", "Column23");
                    bulkCopy.ColumnMappings.Add("Column24", "Column24");
                    bulkCopy.ColumnMappings.Add("Column25", "Column25");
                    bulkCopy.ColumnMappings.Add("Column26", "Column26");
                    bulkCopy.ColumnMappings.Add("Column27", "Column27");
                    bulkCopy.ColumnMappings.Add("Column28", "Column28");
                    bulkCopy.ColumnMappings.Add("Column29", "Column29");
                    bulkCopy.ColumnMappings.Add("Column30", "Column30");
                    bulkCopy.ColumnMappings.Add("IsActive", "IsActive");
                    bulkCopy.ColumnMappings.Add("CreatedDate", "CreatedDate");
                    bulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");

                    DataTable dataTable = ConvertToDataTable(records);
                    bulkCopy.WriteToServer(dataTable);
                }
            }

            Console.WriteLine("Data successfully imported to " + tableName);
        }

        private static string GetDynamicTableName()
        {
            string currentMonth = DateTime.Now.ToString("yyyyMM");
            return $"IoTUtility_T_ProcessInfo_Historical_{currentMonth}";
        }

        private static DataTable ConvertToDataTable(List<ProcessInfoHistorical> records)
        {
            DataTable table = new DataTable();

            table.Columns.Add("MachineCode", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Time", typeof(TimeSpan));
            table.Columns.Add("Column01", typeof(string));
            table.Columns.Add("Column02", typeof(string));
            table.Columns.Add("Column03", typeof(string));
            table.Columns.Add("Column04", typeof(string));
            table.Columns.Add("Column05", typeof(string));
            table.Columns.Add("Column06", typeof(string));
            table.Columns.Add("Column07", typeof(string));
            table.Columns.Add("Column08", typeof(string));
            table.Columns.Add("Column09", typeof(string));
            table.Columns.Add("Column10", typeof(string));
            table.Columns.Add("Column11", typeof(string));
            table.Columns.Add("Column12", typeof(string));
            table.Columns.Add("Column13", typeof(string));
            table.Columns.Add("Column14", typeof(string));
            table.Columns.Add("Column15", typeof(string));
            table.Columns.Add("Column16", typeof(string));
            table.Columns.Add("Column17", typeof(string));
            table.Columns.Add("Column18", typeof(string));
            table.Columns.Add("Column19", typeof(string));
            table.Columns.Add("Column20", typeof(string));
            table.Columns.Add("Column21", typeof(string));
            table.Columns.Add("Column22", typeof(string));
            table.Columns.Add("Column23", typeof(string));
            table.Columns.Add("Column24", typeof(string));
            table.Columns.Add("Column25", typeof(string));
            table.Columns.Add("Column26", typeof(string));
            table.Columns.Add("Column27", typeof(string));
            table.Columns.Add("Column28", typeof(string));
            table.Columns.Add("Column29", typeof(string));
            table.Columns.Add("Column30", typeof(string));
            table.Columns.Add("IsActive", typeof(bool));
            table.Columns.Add("CreatedDate", typeof(DateTime));
            table.Columns.Add("CreatedBy", typeof(string));

            foreach (var record in records)
            {
                table.Rows.Add(
                    record.MachineCode,
                    record.Date,
                    record.Time,
                    record.Column01, record.Column02, record.Column03, record.Column04, record.Column05, record.Column06,
                    record.Column07, record.Column08, record.Column09, record.Column10, record.Column11, record.Column12,
                    record.Column13, record.Column14, record.Column15, record.Column16, record.Column17, record.Column18,
                    record.Column19, record.Column20, record.Column21, record.Column22, record.Column23, record.Column24,
                    record.Column25, record.Column26, record.Column27, record.Column28, record.Column29, record.Column30,
                    record.IsActive, record.CreatedDate, record.CreatedBy
                );
            }

            return table;
        }
    }
}
