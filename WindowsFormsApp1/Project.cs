using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace Reliability
{
    /// <summary>
    /// Текущий проект
    /// </summary>
    class Project
    {
        /// <summary>
        /// Список элементов системы
        /// </summary>
        public Elements ProjectElemets { get; set; }
        /// <summary>
        /// Логическая функция работоспособности системы
        /// </summary>       
        public string LogicFunction { get; set; }
        /// <summary>
        /// Путь, по которому был сохранен проект
        /// </summary>
        public string Path { get; set; } 
        public string Name { get;  set; }
        public int Time { get; set; }
        public int Gamma { get; set; }
        public Project()
        {

        }
        public Project(Elements elements)
        {
            ProjectElemets = new Elements(elements);
        }

        /// <summary>
        /// Сохраняет проект
        /// </summary>
        public void SaveProject()
        {
            string finalPath;
            SaveFileDialog saveProject = new SaveFileDialog();
            saveProject.DefaultExt = ".rlb";
            saveProject.Filter = "Reliability project|*.rlb";
            if (File.Exists(Path)) finalPath = Path;
            else if (saveProject.ShowDialog() == DialogResult.OK && saveProject.FileName.Length > 0) finalPath = saveProject.FileName;
            else return;
            using (StreamWriter sw = new StreamWriter(finalPath, false))
            {
                LogicFunction = LogicFunction ?? DataContainer.LogicFuntion;
                Path = finalPath;
                Name =  DataContainer.ProjectName;
                Gamma =  DataContainer.GammaProject;
                Time =  DataContainer.Time;
                string output = JsonConvert.SerializeObject(this);
                sw.Write(output);
            }
        }

        /// <summary>
        /// Сохранить проект как
        /// </summary>
        public void SaveProjectAs()
        {
            SaveFileDialog saveProject = new SaveFileDialog();
            saveProject.DefaultExt = ".rlb";
            saveProject.Filter = "Reliability project|*.rlb";
            if (saveProject.ShowDialog() == DialogResult.OK && saveProject.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveProject.FileName, false))
                {
                    LogicFunction = DataContainer.LogicFuntion;
                    Path = saveProject.FileName;
                    Name = DataContainer.ProjectName;
                    Gamma = DataContainer.GammaProject;
                    Time = DataContainer.Time;
                    string output = JsonConvert.SerializeObject(this);
                    sw.Write(output);
                }
            }
        }

        /// <summary>
        /// Открывает проект
        /// </summary>
        public static Project OpenProject()
        {          
            OpenFileDialog openProject = new OpenFileDialog();
            openProject.DefaultExt = ".rlb";
            openProject.Filter = "Reliability project|*.rlb";
            if (openProject.ShowDialog() == DialogResult.OK && openProject.FileName.Length > 0)
            {
                using (StreamReader reader = new StreamReader(openProject.FileName))
                {
                    var filetext = reader.ReadToEnd();
                    var CurrentProject = JsonConvert.DeserializeObject<Project>(filetext);
                    if (openProject.FileName != CurrentProject.Path) CurrentProject.Path = openProject.FileName;
                    return CurrentProject;
                }
            }
            else return null;
        }


    }
}

