// TODO: Implement meaningful unit tests for invoice calculator

using Invoice.Logic;

namespace Calculator.Tests
{
    public class InvoiceCalculatorTests
    {
        [Fact]
        public void CalculateNetTotal_SingleInvoiceLine_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, false)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 2)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(3.00m, result);
        }

        [Fact]
        public void CalculateNetTotal_MultipackInvoiceLine_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, true)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 3)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(3.00m, result);
        }

        [Fact]
        public void CalculateNetTotal_SingleInvoiceLineWithDiscount_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, false)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 2),
                new DiscountLine(0.10m)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(2.70m, result);
        }

        [Fact]
        public void CalculateNetTotal_ManyInvoiceLines_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product 1", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, false),
                new Product("1234567890124", "Test Product 2", VATPercentage.Standard, 2.50m, UnitOfMeasure.Pieces, false),
                new Product("1234567890125", "Test Product 3", VATPercentage.Standard, 3.50m, UnitOfMeasure.Pieces, false)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 2),
                new InvoiceLine("1234567890124", 3),
                new InvoiceLine("1234567890125", 4)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(24.50m, result);
        }

        [Fact]
        public void CalculateNetTotal_ManyInvoiceLinesWithDiscount_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product 1", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, false),
                new Product("1234567890124", "Test Product 2", VATPercentage.Standard, 2.50m, UnitOfMeasure.Pieces, false),
                new Product("1234567890125", "Test Product 3", VATPercentage.Standard, 3.50m, UnitOfMeasure.Pieces, false)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 2),
                new InvoiceLine("1234567890124", 3),
                new InvoiceLine("1234567890125", 4),
                new DiscountLine(0.10m)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(22.05m, result);
        }

        [Fact]
        public void CalculateNetTotal_ManyMultipackInvoiceLines_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product 1", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, true),
                new Product("1234567890124", "Test Product 2", VATPercentage.Standard, 2.50m, UnitOfMeasure.Pieces, true),
                new Product("1234567890125", "Test Product 3", VATPercentage.Standard, 3.50m, UnitOfMeasure.Pieces, true)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 3),
                new InvoiceLine("1234567890124", 4),
                new InvoiceLine("1234567890125", 6)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(24.50m, result);
        }

        [Fact]
        public void CalculateNetTotal_ManyMultipackInvoiceLinesWithDiscount_Success()
        {
            var products = new List<Product>
            {
                new Product("1234567890123", "Test Product 1", VATPercentage.Standard, 1.50m, UnitOfMeasure.Pieces, true),
                new Product("1234567890124", "Test Product 2", VATPercentage.Standard, 2.50m, UnitOfMeasure.Pieces, true),
                new Product("1234567890125", "Test Product 3", VATPercentage.Standard, 3.50m, UnitOfMeasure.Pieces, true)
            };

            var lines = new List<Line>
            {
                new InvoiceLine("1234567890123", 3),
                new InvoiceLine("1234567890124", 4),
                new InvoiceLine("1234567890125", 6),
                new DiscountLine(0.10m)
            };

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(22.05m, result);
        }

        [Fact]
        public void CalculateNetTotal_DefaultInput_Success()
        {
            var lines1 = File.ReadAllLines(@"C:\Users\MarkG\Dropbox\HTL_Leonding\2_Klasse\Programmieren\CSharp\030_Invoice_Calculator\Invoice.csv");
            var lines2 = File.ReadAllLines(@"C:\Users\MarkG\Dropbox\HTL_Leonding\2_Klasse\Programmieren\CSharp\030_Invoice_Calculator\Products.csv");

            var importer1 = new LineImporter();
            var importer2 = new ProductImporter();
            var lines = importer1.Import(lines1).ToList();
            var products = importer2.Import(lines2).ToList();

            var calculator = new InvoiceCalculator(products, lines);
            var result = calculator.CalculateNetTotal();

            Assert.Equal(19.43m, result);
        }

       }
}