using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("[---------------------------]");
        Console.WriteLine("[-VRChat-LocalTest-Launcher-]");
        Console.WriteLine("[-Author---Extr3lackLiu-----]");
        Console.WriteLine("[--EXE-------Cyconi---------]");
        Console.WriteLine("[---------------------------]");

        Random random = new Random();
        string randomid = (10000 + random.Next(10000)).ToString() + (10000 + random.Next(10000)).ToString();

        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.vrcw", SearchOption.AllDirectories);

        // Display the files and let the user select one
        for (int i = 0; i < files.Length; i++)
        {
            var fileName = Path.GetFileName(files[i]);

            if (fileName.Contains("wrld_4432ea9b-729c-46e3-8eaf-846aa0a37fdd"))
                fileName = fileName.Replace("wrld_4432ea9b-729c-46e3-8eaf-846aa0a37fdd", "VRChat Home");

            if (fileName.Contains("wrld_ba913a96-fac4-4048-a062-9aa5db092812"))
                fileName = fileName.Replace("wrld_ba913a96-fac4-4048-a062-9aa5db092812", "VRChat Hub");

            if (fileName.Contains("wld_7d3d25ec-663e-406e-96a3-e2c4fc0d8104"))
                fileName = fileName.Replace("wld_7d3d25ec-663e-406e-96a3-e2c4fc0d8104", "Tutorial");


            Console.WriteLine($"{i + 1}. {fileName}");
        }
            
        
        Console.Write("Select a file by entering its number (leave blank = 1): ");
        string fileInput = Console.ReadLine();
        int selectedIndex = string.IsNullOrEmpty(fileInput) || int.Parse(fileInput) == 0 ? 0 : int.Parse(fileInput) - 1;
        string path = files[selectedIndex];

        Console.Write("Amount of Instances to Create (leave blank = 1): ");
        string input = Console.ReadLine();
        int clientCount = string.IsNullOrEmpty(input) ? 1 : int.Parse(input);

        for (int i = 0; i < clientCount; i++)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(Environment.CurrentDirectory, "VRChat.exe"),
                Arguments = $"--url=create?roomId={randomid}&hidden=true&name=BuildAndRun&url=file:///{path} --enable-debug-gui --enable-sdk-log-levels --enable-udon-debug-logging --no-vr --watch-worlds",
                WorkingDirectory = Environment.CurrentDirectory
            };
            Process.Start(startInfo);
        }
    }
}

