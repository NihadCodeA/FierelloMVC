namespace Fierello.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(string rootPath,string folderName,IFormFile file)
        {
            string name= file.FileName;
            if (name.Length > 64)
            {
                name= name.Substring(name.Length-64,64);
            }
            name = Guid.NewGuid().ToString() + name;
            string path = Path.Combine(rootPath,folderName,name);
            using(FileStream fs=new FileStream(path,FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return name;
        }
    }
}
