namespace YT_course;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the notes app, write 'help' for commands");

        IDictionary <int, string> notes = new Dictionary<int, string>();
        bool keepRunning = true;
        while(keepRunning){
            keepRunning = DisplayMenu(notes);
        }

    }

    private static bool DisplayMenu(IDictionary <int, string> notes){

        string input = null;

        while (input == null){
            input = Console.ReadLine();
        }

        switch (input.ToLower())
        {
            case "help":
                PrintHelp();
                break;

            case "add":
                notes = AddNote(notes);
                break;

            case "delete":
                notes = DeleteNote(notes);
                break;

            case "list":
                ListNotes(notes);
                break;

            case "one":
                RetrieveOneNote(notes);
                break;

            case "deleteall":
                DeleteAll(notes);
                break;

            case "exit":
                return false;

            default:
                Console.WriteLine("Incorrect input, see the list of available commands using 'help'");
                break;
        }
        return true;
    }

    private static void PrintHelp()
    {
        // commands as a string array just to learn about arrays and loops
        string[] availableCommands = new string[] {
            "list - shows a list of notes",
            "delete - deletes one note using the index",
            "add - adds one note",
            "one - retrieves one note based on index",
            "deleteall - deletes all notes after confirmation"};

        Console.WriteLine("These are the available command");

        foreach (string command in availableCommands)
        {
            Console.WriteLine(command);
        }
    }

    private static IDictionary<int, string> AddNote(IDictionary<int, string> notes)
    {
        Console.Write("type your note here => ");
        string newNote = Console.ReadLine();
        KeyValuePair<int, string> newNoteAddition = new KeyValuePair<int, string>(notes.Count, newNote);
        // notes.Add(newNoteAddition);
        notes.Add(newNoteAddition.Key, newNoteAddition.Value);

        Console.WriteLine("added: {0}", newNoteAddition);
        return notes;
    }

    private static IDictionary<int, string> DeleteNote(IDictionary<int, string> notes)
    {
        string input = Console.ReadLine();
        int index;
        try
        {
            index = int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine("Incorrect input, use index numbers only");
            return notes;
        }

        if(notes.ContainsKey(index))
        { // check key before removing it
           notes.Remove(index);
        }
        else
        {
            Console.WriteLine("That note does not exist, type 'list' for all available notes");
        }
        return notes;
    }

    private static IDictionary<int, string> DeleteAll(IDictionary<int, string> notes)
    {
        string response = Console.ReadLine();

        if(response == "y" || response == "yes")
        {
            Console.WriteLine("notes were deleted.");
            notes.Clear();
        }
        else{
            Console.WriteLine("no notes were harmed.");
        }
            return notes;
    }

    private static void ListNotes(IDictionary<int, string> notes)
    {
        foreach (KeyValuePair<int, string> kvp in notes)
        {
            Console.WriteLine("{0}) {1}", kvp.Key, kvp.Value);
        }
    }

    private static void RetrieveOneNote(IDictionary<int, string> notes)
    {
        string input = Console.ReadLine();
        int index;
        try
        {
            index = int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine("Incorrect input, use index numbers only");
            return;
        }

        if (notes.ContainsKey(index))
        {
            Console.WriteLine("you searched for '{0}'", notes[index]);
        }
        else
        {
            Console.WriteLine("you don't have set this note");
        }
        return;
    }

}
