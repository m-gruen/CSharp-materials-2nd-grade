using ServiceFeeCalculator.Logic;

System.Console.Write("How many services were performed? ");
var numberOfServices = int.Parse(System.Console.ReadLine()!);

RepairJob[] jobs = new RepairJob[numberOfServices];

for (int i = 0; i < numberOfServices; i++)
{
    System.Console.Write("Enter Start Time: ");
    var start = System.Console.ReadLine()!;

    System.Console.Write("Enter End Time: ");
    var end = System.Console.ReadLine()!;

    System.Console.Write("Was the job successful? ");
    var successful = System.Console.ReadLine()!;

    System.Console.WriteLine("Enter Description: ");
    var description = System.Console.ReadLine()!;

    System.Console.Write("Enter Job Type ([b]asic, [r]egular, [c]omplex): ");
    var jobType = System.Console.ReadLine()!;

    var numberOfMechanics = 0;
    if (jobType == "b" || jobType == "r")
    {
        System.Console.Write("Enter number of mechanics: ");
        numberOfMechanics = int.Parse(System.Console.ReadLine()!);
    }

    RepairJob job = jobType switch
    {
        "b" => new BasicRepairJob(),
        "r" => new RegularRepairJob(),
        "c" => new ComplexRepairJob(),
        _ => throw new ArgumentException("Invalid job type")
    };

    job.SetProperties(description, start, end, successful);

    if (job is TeamRepairJob teamJob)
    {
        teamJob.NumberOfMechanics = numberOfMechanics;
    }

    jobs[i] = job;
}

var totalFee = 0m;

foreach(var job in jobs)
{
    System.Console.WriteLine(job);

    totalFee += job.CalculateFee();
}

System.Console.WriteLine($"Total Fee: {totalFee}");

