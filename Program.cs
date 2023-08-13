namespace YT_course;
class Program
{
    static void Main(string[] args)
    {
        StartNotesApp();

    }

    private static void StartNotesApp(){
        Console.WriteLine("Welcome to the notes app, write 'help' for commands");

        IDictionary <int, string> notes = new Dictionary<int, string>();

        string input = Console.ReadLine();

        // improve error handling here;
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
                ListNote(notes);
                break;

            case "one":
                RetrieveOneNote(notes);
                break;
            case "deleteall":
                DeleteAll(notes);
            default:
                Console.WriteLine("Incorrect input, see the list of available commands");
        }
    }

    private static IDictionary AddNote(IDictionary notes)
    {
        string newNote = Console.ReadLine();
        KeyValuePair<int, string> newNoteAddition = new KeyValuePair<int, string>(notes.Count, newNote);
        notes.add(newNoteAddition);

        Console.WriteLine("added: ", newNote);
        return notes;
    }

    private static IDictionary DeleteNote(IDictionary notes)
    {
        string input = Console.ReadLine();
        try
        {
            int index = int.Parse(input);
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

    private static IDictionary DeleteAll(IDictionary notes)
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

    private static void ListNotes(IDictionary notes)
    {
        foreach (KeyValuePair<int, string> kvp in notes)
        {
            Console.WriteLine("{0}) {1}", kvp.Key. kvp.Value);
        }
    }

    private static void RetrieveOneNote(IDictionary notes)
    {
        string input = Console.ReadLine();
        try
        {
            int index = int.Parse(input);
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
