namespace Invoice.Logic;

public class InvoiceCalculator(IEnumerable<Product> products, IEnumerable<Line> lines)
{
    private IEnumerable<Product> Products { get; } = products;
    private IEnumerable<Line> Lines { get; } = lines;

    private Product? GetProduct(string ean) => Products.FirstOrDefault(p => p.EAN == ean);

    /// <summary>
    /// Calculates the total amount of the invoice.
    /// </summary>
    /// <remarks>
    /// The total amount is calculated by summing up the net total of all lines.
    /// For products that that have IsMultipack == true, the customer gets every
    /// third item for free (e.g. buy 3, pay 2; buy 5, pay 4; buy 6, pay 4, etc.). The total discount percentage must
    /// be applied before returning the total amount.
    /// </remarks>
    public decimal CalculateNetTotal()
    {   
        var totalNet = 0m;
        var discount = 0m;

        foreach(var line in Lines)
        {
            if(line is InvoiceLine invoiceLine)
            {
                var product = GetProduct(invoiceLine.EAN)!;
                var netPrice = product.NetPrice * invoiceLine.Quantity;
                if(product.IsMultipack){netPrice -= Math.Floor(invoiceLine.Quantity / 3) * product.NetPrice;}
                totalNet += netPrice;
            }
            else if(line is DiscountLine discountLine){discount += discountLine.Percentage;}
        }

        return Math.Round(totalNet * (1 - discount), 2);
    }

    /// <summary>
    /// Bonus exercise: Calculates the total discount amount of the invoice.
    /// </summary>
    /// <remarks>
    /// The total discount is the saved costs from multipacks plus the saved costs from the discount percentage.
    /// </remarks>
    public decimal CalculateTotalDiscount()
    {
        throw new NotImplementedException();
    }
}

public class InvoiceCalculationException : Exception
{
    public InvoiceCalculationException() { }

    public InvoiceCalculationException(string message) : base(message) { }

    public InvoiceCalculationException(string message, Exception innerException) : base(message, innerException) { }
}
