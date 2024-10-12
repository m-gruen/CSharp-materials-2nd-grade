namespace ServiceFeeCalculator.Logic;

public abstract class RepairJob
{
    public string Description { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Successful { get; set; }
    protected double TotalHours => (End - Start).TotalHours;
    protected int StartedHours => (int)Math.Ceiling(TotalHours);
    public abstract decimal CalculateFee();

    public void SetProperties(string description, string start, string end, string successful)
    {
        Description = description;
        Start = DateTime.Parse(start);
        End = DateTime.Parse(end);
        Successful = successful == "y" || successful == "yes";
    }
}
