namespace Garage.Logic;

public class Garage
{
    public ParkingSpot[] ParkingSpots { get; } = new ParkingSpot[50];

    public bool IsOccupied(int parkingSpotNumber) => ParkingSpots[parkingSpotNumber - 1] != null;

    public void Occupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)
    {
        ParkingSpots[parkingSpotNumber - 1] = new ParkingSpot
        {
            LicensePlate = licensePlate,
            EntryDate = entryTime
        };
    }

    public decimal Exit(int parkingSpotNumber, DateTime exitTime)
    {
        double elapsedMinutes = (exitTime - ParkingSpots[parkingSpotNumber - 1].EntryDate).TotalMinutes;
        ParkingSpots[parkingSpotNumber] = null!;
        if (elapsedMinutes < 15) { return 0; }
        else
        {
            return (decimal)(Math.Ceiling(elapsedMinutes / 30) * 3);
        }
    }

    public string GenerateReport()
    {
        string report = "| Spot | License Plate |\n| ---- | ------------- |";

        for (int i = 0; i < ParkingSpots.Length; i++)
        {
            ParkingSpot parkingSpot = ParkingSpots[i];

            report += $"\n| {i + 1,-4} |";

            if (parkingSpot == null) { report += "               |"; }
            else
            {
                report += $" {parkingSpot.LicensePlate,-13} |";
            }
        }
        return report;
    }
}
