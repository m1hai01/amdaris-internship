using System;
using System.IO;
using System.Threading.Tasks;

public class FileSystemCRUD
{
    // store the directory path where log files will be stored
    private readonly string logDirectory = "logs";

    //you check if the log directory exists
    public FileSystemCRUD()
    {
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }

    public async Task Create(string data)
    {
        //try-catch block to handle exceptions that might occur during the operation
        try
        {
            await Task.Delay(100); // Simulating an asynchronous operation
            Console.WriteLine($"Data '{data}' created successfully.");
            LogToFile("Create method", "success");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create data: {ex.Message}");
            LogToFile("Create method", "failure: " + ex.Message);
            throw;
        }
    }

    public async Task<string> Read()
    {
        try
        {
            await Task.Delay(100); // Simulating an asynchronous operation
            Console.WriteLine("Data read successfully.");
            LogToFile("Read method", "success");
            return "Some Read Data";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read data: {ex.Message}");
            LogToFile("Read method", "failure: " + ex.Message);
            throw;
        }
    }

    public async Task Update(string newData)
    {
        try
        {
            await Task.Delay(100); // Simulating an asynchronous operation
            Console.WriteLine($"Data updated to '{newData}' successfully.");
            LogToFile("Update method", "success");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update data: {ex.Message}");
            LogToFile("Update method", "failure: " + ex.Message);
            throw;
        }
    }

    public async Task Delete()
    {
        try
        {
            await Task.Delay(100); // Simulating an asynchronous operation
            throw new Exception("exception");

            Console.WriteLine("Data deleted successfully.");
            LogToFile("Delete method", "success");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete data: {ex.Message}");
            LogToFile("Delete method", "failure: " + ex.Message);
            throw;
        }
    }

    private async void LogToFile(string methodName, string outcome)
    {
        //constructs the name of the log file
        //combines the logDirectory variable (which specifies the directory where log files are stored)
        //with the current date formatted as "Logs_{date}.txt".
        string logFileName = Path.Combine(logDirectory, $"Logs_{DateTime.Now:yyyy-MM-dd}.txt");
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Method: {methodName}, Outcome: {outcome}";

        // opens the log file specified by logFileName for appending
        //If the file doesn't exist, it will be created.
        using (StreamWriter writer = File.AppendText(logFileName))
        {
            //This line asynchronously writes the log entry (logEntry) to the log file.
            //WriteLineAsync method writes the text followed by a line terminator asynchronously to the file.
            //It ensures that each log entry is written on a separate line.
            await writer.WriteLineAsync(logEntry);
        }
    }
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        FileSystemCRUD fileSystemCRUD = new FileSystemCRUD();

        try
        {
            // Example usage
            await fileSystemCRUD.Create("Data to be created");
            string data = await fileSystemCRUD.Read();
            Console.WriteLine($"Read data: {data}");
            await fileSystemCRUD.Update("Updated data");
            await fileSystemCRUD.Delete();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}