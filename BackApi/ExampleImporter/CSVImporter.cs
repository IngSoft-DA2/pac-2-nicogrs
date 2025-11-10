using IImporter;
using System;


namespace ExampleImporter
{
    public class CSVImporter : ImporterInterface
    {
        public string GetName()
        {
            return "CSV Importer";
        }
    }
}
