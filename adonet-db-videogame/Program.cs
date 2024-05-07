namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a new videogame");
                Console.WriteLine("2. Search a videogame by Id");
                Console.Write("Scelta: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewGame();
                        break;
                    case "2":
                        SearchGameById();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }
            }
        }

        static void AddNewGame()
        {
            Console.WriteLine("Add a new game to the library:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Overview: ");
            string overview = Console.ReadLine();

            VideogameManager.InsertVideogame(name, overview);
            Console.WriteLine("New videogame added to library!");
        }
        static void SearchGameById()
        {
            Console.Write("Search a videogame by its ID: ");
            string inputId = Console.ReadLine();
            int id;

            if (int.TryParse(inputId, out id))
            {
                Videogame game = VideogameManager.GetVideogameById(id);
                if (game != null)
                {
                    Console.WriteLine($"A videogame has been found: {game.Name}");
                }
                else
                {
                    Console.WriteLine("No videogames has been found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}
