using System;

class Resume
{
    private string _name;
    Job job1;
    Job job2;
    List<Job> jobs = new List<Job>();

    public void Display()
    {
        _name = "Allison Rose";
        job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company =  "Microsoft";
        job1._startYear =  "2019";
        job1._endYear =  "2022";
        jobs.Add(job1);
        job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company =  "Apple";
        job2._startYear =  "2022";
        job2._endYear =  "2023";
        jobs.Add(job2);
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in jobs)
        {
            job.Display();
        }
    }
}