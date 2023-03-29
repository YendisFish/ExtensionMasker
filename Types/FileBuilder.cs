namespace ExtensionMasker.Types;

internal class FileBuilder
{
    public static void BuildFrom(string name, byte[] buf)
    {
        FileStream fs = File.Create(name);

        Console.WriteLine($"Created file: {fs.Name}");
        Console.WriteLine($"Writing bytes...");
        
        fs.Write(buf, 0, buf.Length);
    }
}