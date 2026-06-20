using SQLite;
using MiAppGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;                     // Para Path
using Microsoft.Maui.Storage;        // Para FileSystem

namespace MiAppGastos.Services;

public interface IDatabaseService
{
    Task<List<Transaction>> GetTransactionsAsync();
    Task<int> AddTransactionAsync(Transaction transaction);
    Task<int> DeleteTransactionAsync(int id);
}

public class DatabaseService : IDatabaseService
{
    private SQLiteAsyncConnection _database;

    public DatabaseService()
    {
#pragma warning disable CA1416
#if WINDOWS
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "gastos.db3");
#else
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "gastos.db3");
#endif
#pragma warning restore CA1416
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Transaction>().Wait();
    }

    public Task<List<Transaction>> GetTransactionsAsync()
    {
        return _database.Table<Transaction>().OrderByDescending(t => t.Date).ToListAsync();
    }

    public Task<int> AddTransactionAsync(Transaction transaction)
    {
        return _database.InsertAsync(transaction);
    }

    public Task<int> DeleteTransactionAsync(int id)
    {
        return _database.DeleteAsync<Transaction>(id);
    }
}