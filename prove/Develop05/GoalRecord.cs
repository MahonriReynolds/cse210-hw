
public class GoalRecord
{
    private string _filePath;
    private List<Goal> _goalList;
    private int _totalPoints;

    public GoalRecord(string filePath)
    {
        this._filePath = filePath;
        IEnumerable<string> lines = File.ReadAllLines(this._filePath).Skip(1);
        this._goalList = [];
        foreach (string line in lines)
        {
            Goal newGoal = BuildGoal(line);
            this._goalList.Add(newGoal);
        }
        this._totalPoints = int.Parse(File.ReadAllLines(this._filePath).First());
    }

    private Goal BuildGoal(string goalString)
    {
        string[] parts = goalString.Split("|");
        string type = parts[0];

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
        }
        return new EternalGoal("", "", 0);
    }

    public List<Goal> GetGoals()
    {
        return this._goalList;
    }

    public void SaveGame()
    {
        using (StreamWriter outputFile = new StreamWriter(this._filePath))
        {
            outputFile.WriteLine(this._totalPoints);
            foreach (Goal goal in this._goalList)
            {
                outputFile.WriteLine(goal.ToStorage());
            }
        }
    }

    public string GetLvl()
    {
        string firstLine = File.ReadLines(this._filePath).First();
        int totalPoints = int.Parse(firstLine);

        double multiplier = 1.25;
        int currentLevel = 1;
        int pointsForNextLevel = 125;
        int pointsInCurrentLevel = totalPoints;

        while (pointsInCurrentLevel >= pointsForNextLevel)
        {
            pointsInCurrentLevel -= pointsForNextLevel;
            pointsForNextLevel = (int)(pointsForNextLevel * multiplier);
            currentLevel++;
        }

        double progress = (double)pointsInCurrentLevel / (pointsForNextLevel / multiplier);

        string ratio = $"{pointsInCurrentLevel} / {(int)(pointsForNextLevel / multiplier)} points";

        int progressBarLength = 50;
        int filledLength = (int)(progressBarLength * progress);
        string progressBar = new string('█', filledLength).PadRight(progressBarLength, '░');

        string result = $"lvl: {currentLevel}\n{ratio}\n{progressBar}";

        return result;
    }

    public void RemoveGoal(int idx)
    {
        this._goalList.RemoveAt(idx);
    }

    public void AddGoal(string newGoalString)
    {
        this._goalList.Add(this.BuildGoal(newGoalString));
    }

    public Goal GrabGoal(int goalIdx)
    {
        return this._goalList[goalIdx];
    }

    public void GainPoints(int points)
    {
        this._totalPoints += points;
    }
}


