namespace Invoice.Logic;

public enum UnitOfMeasure
{
    Pieces,
    Kilograms,
}

public enum VATPercentage
{
    Reduced = 10,
    Standard = 20,
}

public record Product(
    string EAN,
    string Name,
    VATPercentage VATPercentage,
    decimal NetPrice,
    UnitOfMeasure UnitOfMeasure,
    bool IsMultipack
);

public class ProductImporter
{
    /// <summary>
    /// Imports products from the given lines.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of products
    /// </returns>
    /// <exception cref="ProductImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - The header line is missing or contains invalid column names or the order of columns is wrong
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - IsMultiPack is true when unit of measure is not Pieces
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public IEnumerable<Product> Import(string[] lines)
    {
        if (lines.Length == 0) { throw new ProductImportException("No lines to import."); }
        if (lines.First() != "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack") { throw new ProductImportException("Invalid header."); }

        var result = new List<Product>();

        foreach (var line in lines.Skip(1))
        {
            // Example line: 3548769012345,Apples,20,1.50,kg,false

            var parts = line.Split(',');

            if (parts.Length is not 6) { throw new ProductImportException("Invalid line length."); }

            if (parts[2] is not "10" and not "20") { throw new ProductImportException("Invalid VAT Percentage."); }

            if (!decimal.TryParse(parts[3], out var netPrice)) { throw new ProductImportException("Invalid Net Price."); }
            if (netPrice < 0) { throw new ProductImportException("Net Price must be positive."); }

            if (parts[4] is not "kg" and not "pcs") { throw new ProductImportException("Invalid Unit of Measure."); }

            if (!bool.TryParse(parts[5], out var isMultiPack)) { throw new ProductImportException("Invalid IsMultiPack."); }
            if (isMultiPack && parts[4] != "pcs") { throw new ProductImportException("IsMultiPack is true when unit of measure is not Pieces."); }

            result.Add(new Product(
                parts[0], 
                parts[1], 
                parts[2] == "10" ? VATPercentage.Reduced : VATPercentage.Standard, 
                netPrice, 
                parts[4] == "kg" ? UnitOfMeasure.Kilograms : UnitOfMeasure.Pieces, 
                isMultiPack));
        }
        
        return result;
    }
}

public class ProductImportException : Exception
{
    public ProductImportException() { }

    public ProductImportException(string message) : base(message) { }

    public ProductImportException(string message, Exception innerException) : base(message, innerException) { }
}
