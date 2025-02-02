using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class PromptManager {
    public List<string> _prompts = new List<string>
    {
        "What is something that made you smile today?",
        "What is one thing you are grateful for today.",
        "What is something you learned today?",
        "How can you improve from your experiences today?",
        "What is something you can look back on and laugh about today?"
    };

    public Random rnd = new Random();

    public string GetPrompt() {
        int randPrompt = rnd.Next(_prompts.Count);
        return _prompts[randPrompt];
    }
}
