using System.Globalization;

namespace Invoice.Logic;

public abstract class Line { }

public class InvoiceLine(string ean, decimal quantity) : Line
{
    public string EAN { get; } = ean;
    public decimal Quantity { get; } = quantity;
}

public class DiscountLine(decimal percentage) : Line
{
    public decimal Percentage { get; } = percentage;
}

public class LineImporter
{
    /// <summary>
    /// Imports an invoice line or a discount line from the given string.
    /// </summary>
    /// <param name="line">Line of text read from a file that should be imported</param>
    /// <returns>
    /// Line of an invoice or a discount
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="line"/> is empty
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public Line Import(string line)
    {
        if (string.IsNullOrEmpty(line)) { throw new InvoiceLineImportException("Line is empty."); }

        var parts = line.Split(',');

        if (parts[0] == "IL") 
        {
            // Example: IL,3548769012345,2.5

            if (parts.Length != 3) { throw new InvoiceLineImportException("Invalid number of columns."); }
            if (!decimal.TryParse(parts[2], out var quantity)) { throw new InvoiceLineImportException("Invalid quantity."); }
            if (quantity < 0) { throw new InvoiceLineImportException("Quantity must be positive."); }

            return new InvoiceLine(parts[1], quantity);
        }
        else if (parts[0] == "D")
        {
            // Example: D,5

            if (parts.Length != 2) { throw new InvoiceLineImportException("Invalid number of columns."); }
            if (!decimal.TryParse(parts[1], out var percentage)) { throw new InvoiceLineImportException("Invalid percentage."); }
            if (percentage < 0) { throw new InvoiceLineImportException("Percentage must be positive."); }

            return new DiscountLine(percentage / 100);
        }
        else
        {
            throw new InvoiceLineImportException("Invalid line type.");
        }
    }

    /// <summary>
    /// Imports an invoice and discount lines from the given string array.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of lines and discounts
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - The same EAN appears multiple times in the lines
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public IEnumerable<Line> Import(string[] lines)
    {
        if (lines.Length == 0) { throw new InvoiceLineImportException("No lines to import."); }

        var result = new List<Line>();

        foreach (var line in lines)
        {
            var newLine = Import(line);
            
            if (newLine is InvoiceLine invoiceLine)
            {
                if (result.OfType<InvoiceLine>().Any(x => x.EAN == invoiceLine.EAN))
                {
                    throw new InvoiceLineImportException($"EAN {invoiceLine.EAN} appears multiple times.");
                }
            }
            
            result.Add(newLine);
        }

        return result;
    }
}

public class InvoiceLineImportException : Exception
{
    public InvoiceLineImportException() { }

    public InvoiceLineImportException(string message) : base(message) { }

    public InvoiceLineImportException(string message, Exception innerException) : base(message, innerException) { }
}

