using System.Reflection;
using IImporter;

namespace BussinesLogic
{
    public class ImporterLogic
    {
        public List<string> GetAllImporters()
        {
            var importersPath = "./reflection";
            string[] filePaths = Directory.GetFiles(importersPath);
            List<string> availableImporters = new List<string>();

            foreach (string file in filePaths)
            {
                if (FileIsDll(file))
                {
                    FileInfo dllFile = new FileInfo(file);
                    Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
                    foreach (Type type in myAssembly.GetTypes())
                    {
                        if (ImplementsRequiredInterface(type))
                        {
                            ImporterInterface instance = (ImporterInterface)Activator.CreateInstance(type);
                            availableImporters.Add(instance.GetName());
                        }
                    }
                }
            }

            return availableImporters;
        }

        public bool FileIsDll(string file)
        {
            if (File.Exists(file))
            {
                return file.EndsWith(".dll");
            }
            return false;
        }

        public bool ImplementsRequiredInterface(Type type)
        {
            return typeof(ImporterInterface).IsAssignableFrom(type) 
                && !type.IsInterface 
                && type.IsPublic 
                && !type.IsAbstract;
        }
    }
}
