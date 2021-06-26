using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PWTestApp1___ProposalMockup.Models;

namespace PWTestApp1___ProposalMockup.Data
{
    class ProjectDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ProjectDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }
        public Task<List<Item>> GetDataAsync()
        {
            //Get all data
            return database.Table<Item>().ToListAsync();
        }
        public Task<Item> GetDatumAsync(int id)
        {
            //Get a specific data
            return database.Table<Item>()
                .Where(i => Int64.Parse(i.Id) == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveDataAsync(Item data)
        {
            if(Int64.Parse(data.Id) != 0)
            {
                //Update an existing data
                return database.UpdateAsync(data);
            }
            else
            {
                //Save a new data
                return database.InsertAsync(data);
            }
        }

        public Task<int> DeleteDataAsync(Item data)
        {
            //Delete a data
            return database.DeleteAsync(data);
        }
    }
}
