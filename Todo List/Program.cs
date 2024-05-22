
using System;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Todo_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todos = new List<string>();



            Console.WriteLine("Hello!");

            bool shallExit = false;
            while (!shallExit)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

                var userChoice = Console.ReadLine();




                switch (userChoice)
                {
                    case "S":
                    case "s":
                        SeeAllTodos();
                        break;
                    case "A":
                    case "a":
                        AddToDo();
                        break;
                    case "R":
                    case "r":
                        RemoveTodo();
                        break;
                    case "E":
                    case "e":
                        shallExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }

            Console.ReadKey();

            void AddToDo()
            {
                string description;
                do
                {
                    Console.WriteLine("Enter the TODO description:");
                    description = Console.ReadLine();
                }
                while (!IsDescriptionValid(description));

                todos.Add(description);

            }

            bool IsDescriptionValid(string description)
            {
                if (description == "")
                {
                    Console.WriteLine("The description cannot be empty");
                    Console.WriteLine();
                    return false;
                }
                if (todos.Contains(description))
                {
                    Console.WriteLine("The description must be unique.");
                    return false;
                }
                return true;

            }


            void SeeAllTodos()
            {
                if (todos.Count == 0)
                {
                    ShowNoTodosMessage();
                    return;
                }

                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{i + 1}. {todos[i]}");
                }
            }


            void RemoveTodo()
            {
                if (todos.Count == 0)
                {
                    ShowNoTodosMessage();
                    return;
                }

                int index;
                do
                {
                    Console.WriteLine("Select the index of the TODO you want to remove");
                    SeeAllTodos();
                } while (!TryReadIndex(out index));

                RemoveTodoAtIndex(index - 1);
            }



            void RemoveTodoAtIndex(int index)
            {
                var todoToBeRemoved = todos[index];
                todos.RemoveAt(index);
                Console.WriteLine("TODO removed: " + todoToBeRemoved);
            }

            bool TryReadIndex(out int index)
            {
                var userInput = Console.ReadLine();
                if (userInput == "")
                {
                    index = 0;
                    Console.WriteLine("Selected index cannot be empty");
                    Console.WriteLine();
                    return false;
                }
                if (int.TryParse(userInput, out index) &&
                    index >= 1 &&
                    index <= todos.Count)
                {

                    return true;
                }

                Console.WriteLine("The given index is not valid.");
                return false;

            }

            static void ShowNoTodosMessage()
            {
                Console.WriteLine("No TODOs have been added yet.");
            }
        }
    }

}

