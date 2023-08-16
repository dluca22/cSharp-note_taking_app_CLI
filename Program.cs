namespace YT_course;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the notes app, write 'help' for commands");


        /*  notes is a global dictionary, since thye variable that gets passed around is just the reference to the dictionary,
         not the dictionary itself, any modification to it does not have to be a return
         and will take effect on the global instance of the notes dictionary */

        IDictionary <int, string> notes = new Dictionary<int, string>();
        bool keepRunning = true;
        while(keepRunning){
            keepRunning = DisplayMenu(notes);
        }

    }

    private static bool DisplayMenu(IDictionary <int, string> notes){

        string input = null;

        do{
            Console.WriteLine();
            Console.Write("Type your command: ");
            input = Console.ReadLine();
        }while (input == null);

        // clears the console if needed
        // Console.Clear();
        switch (input.ToLower())
        {
            case "help":
                PrintHelp();
                break;

            case "add":
                AddNote(notes);
                break;

            case "delete":
                DeleteNote(notes);
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
                Console.WriteLine("Byeeeee!!");
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
            "deleteall - deletes all notes after confirmation",
            "exit - exits the app"};

        Console.WriteLine("These are the available command");

        foreach (string command in availableCommands)
        {
            Console.WriteLine(command);
        }
    }

    private static void AddNote(IDictionary<int, string> notes)
    {
        Console.Write("type your note here => ");
        string newNote = Console.ReadLine();

        KeyValuePair<int, string> newNoteAddition = new KeyValuePair<int, string>(notes.Count, newNote);
        // notes.Add(newNoteAddition);
        notes.Add(newNoteAddition.Key, newNoteAddition.Value);

        Console.WriteLine("added: {0}", newNoteAddition);
    }

    private static void DeleteNote(IDictionary<int, string> notes)
    {
        ListNotes(notes);
        Console.Write("Type the note number to delete: ");
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

        if (notes.ContainsKey(index)) {
            // check key before removing it
           notes.Remove(index);
           // rewrites the order of the notes for readability and also to avoid error in new insert with conflict of Key already in use
           ShiftOrder(notes);
        } else {
            Console.WriteLine("That note does not exist, type 'list' for all available notes");
        }
    }

    private static void ShiftOrder(IDictionary<int, string> notes){

        var list = new List<string>();
        foreach(var note in notes)
        {
            list.Add(note.Value);
        }

        notes.Clear();
        for(int i = 0; i < list.Count; i++)
        {
            notes.Add(i,list[i]);
        }

    }


    private static void DeleteAll(IDictionary<int, string> notes)
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
    }

    private static void ListNotes(IDictionary<int, string> notes)
    {
        if(notes.Count == 0){
            Console.WriteLine("== List is empty ==");
        } else {
            foreach (KeyValuePair<int, string> kvp in notes)
            {
                Console.WriteLine("{0}) {1}", kvp.Key, kvp.Value);
            }
        }
    }

    private static void RetrieveOneNote(IDictionary<int, string> notes)
    {
        Console.Write("Type index: ");
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
