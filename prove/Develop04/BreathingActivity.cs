class BreathingActivity : Activity
{
    private static List<string> prompts = new List<string>{};
    private static List<string> followupQuestions = new List<string>{};
    private static string name = "Breathing Activity";
    private static string message = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    public BreathingActivity() : base(name, message)
    {
    }

    public override void RunActivity()
    {
        int runTime = 0; // how long the animation has been running for
        int i = 0;
        Console.WriteLine();
        string[] breaths = {"in", "out"};
        while (runTime < time )
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth-1) + "\r"); // clear the last console line so it can be updated
            for (int t = 0; t<5; t++) // hold each breath for 5 seconds
            {
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                Console.Write($"Breath {breaths[i%2]} for {5-t} seconds");
                Thread.Sleep(1000); // wait for one second before updating the animation
                runTime++;
            }
            i++;
        }
    }
}