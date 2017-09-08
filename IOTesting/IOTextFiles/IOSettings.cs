using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTextFiles
{    
    public class IOSettings
    {
        private STable _stable;

        public IOSettings(STable stable)
        {
            _stable = stable;
        }

        public string GetPath()
        {
            // Програмата\Settings/settings.txt
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings");
            path = System.IO.Path.Combine(path, "settings.txt"); // Но е добре самия файл да е извън дир-та н апрограмата!

            // Други видиве директории:
            //string user = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //Console.WriteLine(user);
            //string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Console.WriteLine(desctop);

            return path;
        }
     

        public bool Save() 
        {
            // когато се запеметява, винаги да го правим в TRY-CATCH!!!
            try
            {
                string temp = "";
                temp = String.Join("\r\n", _stable.stable);

                //Запис на текстов файл:
                System.IO.File.WriteAllText(GetPath(), temp);

                return true;
            }
            catch {
            }

            return false;
        }

        public bool Open()
        {
            try
            {
                IniSettings();

                string temp = "", filePath = GetPath();
                    
                if(System.IO.File.Exists(filePath))  // проверка дали пътят е валиден
                {
                    System.IO.File.ReadAllText(filePath);

                    string[] table = temp.Replace("\r", "").Split('\n');

                    for (int i = 0; i < table.Length; i++)
                    {
                        _stable.stable[i] = table[i];
                    }
                }
                else
                {                 
                    return false;
                }

                System.Diagnostics.Process.Start(filePath);

                return true;
            }
            catch {                
            }
            return false;
        }

        private void IniSettings()
        {
            try
            {
                bool fileExist = System.IO.File.Exists(GetPath());

                if (!fileExist)
                {
                    string directory = System.IO.Path.GetDirectoryName(GetPath());

                    // Застраховане, че директорията съществува
                    if(!System.IO.Directory.Exists(directory))
                    {
                        System.IO.Directory.CreateDirectory(directory);
                    }

                    // Запаметяване съдържанието на файла
                    Save();
                }
            }
            catch 
            {
            }
        }
    }
}
