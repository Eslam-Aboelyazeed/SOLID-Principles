namespace DIP
{

    #region Before

    //public class FileProcessor
    //{
    //    private FileReader _fileReader;
    //    private FileWriter _fileWriter;
    //    public FileProcessor()
    //    {
    //        _fileReader = new FileReader();
    //        _fileWriter = new FileWriter();
    //    }
    //    public void ProcessFile(string inputFilePath, string outputFilePath)
    //    {
    //        string fileContent = _fileReader.ReadFile(inputFilePath);
    //        // Process the file content
    //        _fileWriter.WriteFile(outputFilePath, fileContent);
    //    }
    //}
    //public class FileReader
    //{
    //    public string ReadFile(string filePath)
    //    {
    //        // Code to read file content
    //        return "File content";
    //    }
    //}
    //public class FileWriter
    //{
    //    public void WriteFile(string filePath, string content)
    //    {
    //        // Code to write file content
    //    }
    //}

    #endregion

    #region After

    public class FileProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public FileProcessor(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            // Process the file content
            _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }

    public interface IFileReader
    {
        string ReadFile(string filePath);
    }

    public interface IFileWriter
    {
        public void WriteFile(string filePath, string content);
    }

    public class FileReader : IFileReader
    {
        public string ReadFile(string filePath)
        {
            // Code to read file content
            return "File content";
        }
    }

    public class FileWriter :IFileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            // Code to write file content
        }
    }



    #endregion
}
