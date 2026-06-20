using SQLite;

namespace MiAppGastos.Models;

[Table("Transactions")]
public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [NotNull]
    public string Description { get; set; } = string.Empty;
    
    [NotNull]
    public decimal Amount { get; set; } // Positivo para ingresos, Negativo para gastos (o usar un Enum)
    
    [NotNull]
    public TransactionType Type { get; set; } // Ingreso o Gasto
    
    [NotNull]
    public DateTime Date { get; set; }
}