using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._company = "Some Company";
        job1._jobTitle = "Software Guy";
        job1._startYear = 1234;
        job1._endYear = 2345;

        Job job2 = new Job();
        job2._company = "Some Other Company";
        job2._jobTitle = "Hardware Guy";
        job2._startYear = 3456;
        job2._endYear = 4567;

        Resume resume1 = new Resume();
        resume1._name = "Some Name";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.DisplayResume();
    }
}