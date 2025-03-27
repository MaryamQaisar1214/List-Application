using System;
using System.IO;

class ToDoListApp
{
    // The path to the file where tasks will be stored
    static string filePath = "tasks.txt";

    // Method to add a task to the file
    static void AddTask(string task)
    {
        try
        {
            // Append the task to the file
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(task);
            }
            Console.WriteLine("Task added successfully!");
        }
        catch (Exception ex)
        {
            // Handle any file-related errors
            Console.WriteLine($"Error adding task: {ex.Message}");
        }
    }

    // Method to view tasks from the file
    static void ViewTasks()
    {
        try
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines (tasks) from the file
                string[] tasks = File.ReadAllLines(filePath);

                // If the file is empty, inform the user
                if (tasks.Length == 0)
                {
                    Console.WriteLine("No tasks found.");
                }
                else
                {
                    Console.WriteLine("Here are your tasks:");
                    // Display each task
                    foreach (var task in tasks)
                    {
                        Console.WriteLine("- " + task);
                    }
                }
            }
            else
            {
                // If no file exists, notify the user
                Console.WriteLine("No tasks file found.");
            }
        }
        catch (Exception ex)
        {
            // Handle any file reading errors
            Console.WriteLine($"Error reading tasks: {ex.Message}");
        }
    }

    // Main method to run the To-Do List application
    static void Main()
    {
        while (true)
        {
            // Display the menu options
            Console.WriteLine("\nTo-Do List App");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option (1-3): ");

            // Read the user's choice
            string option = Console.ReadLine();

            // Handle the different options
            if (option == "1")
            {
                Console.Write("Enter the task: ");
                string task = Console.ReadLine();
                AddTask(task); // Call the AddTask method
            }
            else if (option == "2")
            {
                ViewTasks(); // Call the ViewTasks method
            }
            else if (option == "3")
            {
                break; // Exit the program
            }
            else
            {
                // Handle invalid input
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}
