using System;
using System.IO;

namespace ToucherNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "file.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            try
            {
                if (!File.Exists(filePath))
                {
                    // Create the file if it doesn't exist
                    File.Create(filePath).Close();
                }

                // Update the file's last write time
                File.SetLastWriteTime(filePath, DateTime.Now);

                // Append the current timestamp to the file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(DateTime.Now);
                }

                Console.WriteLine("File touched successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
