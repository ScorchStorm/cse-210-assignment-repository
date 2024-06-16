class ReflectionActivity : Activity
{
    private static string name = "Reflection Activity";
    private static string message = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    private static List<string> prompts = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    private static List<string> followupQuestions = new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};
        public ReflectionActivity() : base(name, message)
    {
    }

    public override void RunActivity()
    {
        int runTime = 5; // how long the activity has been running for
        Random rand = new Random();
        int promptIndex = rand.Next(prompts.Count);
        Console.WriteLine(prompts[promptIndex]);
        DelayAnimation(5);
        while (runTime < time)
        {
            int followupQuestionsIndex = rand.Next(followupQuestions.Count);
            Console.WriteLine(followupQuestions[followupQuestionsIndex]);
            DelayAnimation((10 < time - runTime) ? 10 : time - runTime);
            runTime += 10;
        }
    }
}