using System.Reflection;

namespace WHSort
{
    internal class DirectoryExtension
    {
        /// <summary>
        /// Получаем путь до каталога с .sln файлом
        /// </summary>
        public static string? GetSolutionRoot()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            return Directory.GetParent(currentPath!)?.Parent?.Parent?.Parent?.FullName;
        }
    }
}
