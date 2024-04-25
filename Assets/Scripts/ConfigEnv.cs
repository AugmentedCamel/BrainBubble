using System.IO;
using UnityEngine;
 
public static class Config
{
    private static readonly string envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
 
    public static string OpenAI_API_Key { get; private set; }
 
    static Config()
    {
        if (File.Exists(envPath))
        {
            string[] lines = File.ReadAllLines(envPath);
            foreach (string line in lines)
            {
                if (line.StartsWith("OPENAI_API_KEY"))
                {
                    OpenAI_API_Key = line.Split('=')[1].Trim();
                }
                
            }
        }
        else
        {
            Debug.LogError(".env file not found");
        }
    }
}
