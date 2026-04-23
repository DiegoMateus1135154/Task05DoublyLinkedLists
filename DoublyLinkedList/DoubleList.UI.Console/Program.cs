using DoubleList.Core;

var list = new DoublyLinkedList<string>();
var opt = string.Empty;

do
{
    opt = Menu();
    switch (opt)
    {
        case "0":
            Console.WriteLine(":::::::::: GAME OVER ::::::::::");
            Console.WriteLine("Thank you for using the program");
            break;

        case "1":
            Console.Write("Enter the data to Add: ");
            var addData = Console.ReadLine();
            if (addData != null)
            {
                list.Add(addData);
            }
            break;

        case "2":
            Console.WriteLine("List Forward: ");
            Console.WriteLine(list.GetForward());
            break;

        case "3":
            Console.WriteLine("List Backward: ");
            Console.WriteLine(list.GetBackward());
            break;

        case "4":
            list.SortDescending();
            Console.WriteLine("List sorted in descending order.");
            break;

        case "5":
            Console.WriteLine("Fashions in the list:");
            var fashions = list.GetFashions();
            foreach (var fashion in fashions)
            {
                Console.WriteLine(fashion);
            }
            break;

        case "6":
            Console.WriteLine("Fashion graph:");
            var graph = list.GetFashionGraph();
            if (graph.Count == 0)
            {
                Console.WriteLine("(no data)");
            }
            else
            {
                foreach (var line in graph)
                {
                    Console.WriteLine(line);
                }
            }
            break;

        case "7":
            Console.Write("Enter the data to search: ");
            var searchData = Console.ReadLine();
            Console.WriteLine(list.Exist(searchData!) ? $"The data '{searchData}' exists in the list" : $"The data '{searchData}' does not exist in the list");
            break;

        case "8":
            Console.Write("Enter the data to remove (one occurrence): ");
            var removeOnce = Console.ReadLine();
            if (removeOnce != null)
            {
                var removed = list.Remove(removeOnce);
                Console.WriteLine(removed ? $"Removed one occurrence of '{removeOnce}'." : $"Value '{removeOnce}' not found.");
            }
            break;

        case "9":
            Console.Write("Enter the data to remove (all occurrences): ");
            var removeAll = Console.ReadLine();
            if (removeAll != null)
            {
                var count = list.RemoveAll(removeAll);
                Console.WriteLine(count > 0 ? $"Removed {count} occurrence(s) of '{removeAll}'." : $"Value '{removeAll}' not found.");
            }
            break;
    }
} while (opt != "0");

string Menu()
{
    Console.WriteLine(":::::::: MENÚ ::::::::");
    Console.WriteLine();
    Console.WriteLine("1. Add Data");
    Console.WriteLine("2. Show list  forward");
    Console.WriteLine("3. Show list backward");
    Console.WriteLine("4. Sort Descending");
    Console.WriteLine("5. Show Fashions");
    Console.WriteLine("6. Fashion graph");
    Console.WriteLine("7. Show if the data exist");
    Console.WriteLine("8. Remove an occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    return Console.ReadLine() ?? "0";
}
