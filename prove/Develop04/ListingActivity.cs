class ListingActivity: Activity
{
    private static List<string> prompts = new List<string>{"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    private static string name = "Listing Activity";
    private static string message = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    public ListingActivity() : base(name, message)
    {
    }

    public override void RunActivity()
    {
        Random rand = new Random();
        int promptIndex = rand.Next(prompts.Count);
        Console.WriteLine(prompts[promptIndex]);
        for (int t = 10; t<0; t--) // hold each breath for 5 seconds
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write($"Think about what you will write, and begin typing in {t} seconds");
            Thread.Sleep(1000); // wait for one second before updating the animation
        }
        List<string> items = new List<string>();
        DateTime futureTime = DateTime.Now.AddSeconds(time);
        while (DateTime.Now < futureTime)
        {
            Console.Write($"{items.Count+1}. ");
            items.Add(Console.ReadLine());
        }
        Console.WriteLine($"Great job! You wrote down {items.Count} things!");
    }
}