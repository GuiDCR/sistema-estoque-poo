using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager.Models
{
    public enum MovementType { Entry, Sale, Adjustment, Loss}
    public record StockMovement(
        int Id,
        string ProductCode,
        MovementType Type,
        int Quantity,
        DateTime Date
    );
}
