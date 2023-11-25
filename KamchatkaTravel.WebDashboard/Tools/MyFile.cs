using Azure.Core;
using Microsoft.AspNetCore.Http;

namespace KamchatkaTravel.WebDashboard.Tools
{
    public static class MyFile
    {

        private static Dictionary<char, string> map = new Dictionary<char, string>
            {
                { 'а', "a" },
                { 'б', "b" },
                { 'в', "v" },
                { 'г', "g" },
                { 'д', "d" },
                { 'е', "e" },
                { 'ё', "yo" },
                { 'ж', "zh" },
                { 'з', "z" },
                { 'и', "i" },
                { 'й', "y" },
                { 'к', "k" },
                { 'л', "l" },
                { 'м', "m" },
                { 'н', "n" },
                { 'о', "o" },
                { 'п', "p" },
                { 'р', "r" },
                { 'с', "s" },
                { 'т', "t" },
                { 'у', "u" },
                { 'ф', "f" },
                { 'х', "kh" },
                { 'ц', "ts" },
                { 'ч', "ch" },
                { 'ш', "sh" },
                { 'щ', "sch" },
                { 'ъ', "" },
                { 'ы', "y" },
                { 'ь', "" },
                { 'э', "e" },
                { 'ю', "yu" },
                { 'я', "ya" },
            };
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="file">файл</param>
        /// <param name="path">начальный путь</param>
        /// <param name="entity">название сущности, для которой сохраняется картинка (для названия папки). Пример: Tour</param>
        /// <param name="entityInfo">данные о текущей сущности (для каждой записи сущности). Пример: Восхождение на вулкан Горелый</param>
        /// <returns></returns>
        public static async Task<string> SaveFile(IFormFile? file, string path, string entity, string entityInfo)
        {
            if (file == null)
                return string.Empty;

            if (file.Length > 0)
            {
                // Создает уникальное название
                var title = Guid.NewGuid() + "_" + CleanFileName(file.FileName);
                var pathToFile = Path.Combine("img", entity, CleanFileName(entityInfo));
                var filePath = Path.Combine(path, pathToFile);
                if (!Directory.Exists(filePath))
                {
                    //создаем папку, если её нету
                    Directory.CreateDirectory(filePath);
                }
                //полный путь с названием файла
                filePath = Path.Combine(filePath, title);
                pathToFile = Path.Combine(pathToFile, title);
                //сохраняем файл
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return "\\" + pathToFile;
            }
            return string.Empty;
        }

        public static string CleanFileName(string fileName)
        {
            fileName = ConvertCyrillicintoEnglish(fileName);
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static string ConvertCyrillicintoEnglish(string str)
        {
            str = str.ToLower();
            return string.Concat(str.Select(c =>
            {
                try
                {
                    return map[c];
                }
                catch
                {
                    return c.ToString();
                }
            }));
        }
    }
}
