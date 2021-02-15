using Reliability.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reliability
{
    public partial class DataBaseForm : Form
    {
        BD database;
        List<ERI> condensators;
        List<ERI> resistors;
        List<ERI> IMS;
        List<ERI> semiconductors;
        List<ERI> transformators;
        List<ERI> opto;
        List<ERI> currentList;
        public string ERIName { get; private set; }
        public double lymbda { get; private set; }
        public DataBaseForm()
        {
            InitializeComponent();
            materialButton1.Click += (s, e) =>
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Необходимо выбрать элемент, чтобы прололжить!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string className = "";
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            className = "Конденсатор";
                            break;
                        case 1:
                            className = "Резистор";
                            break;
                        case 2:
                            className = "ИМС";
                            break;
                        case 3:
                            className = "Полупроводниковый прибор";
                            break;
                        case 4:
                            className = "Трансформатор";
                            break;
                        case 5:
                            className = "Оптоэлектронный прибор";
                            break;
                    }

                    lymbda = currentList[comboBox2.SelectedIndex].Lyambda;
                    ERIName = $"{className} {currentList[comboBox2.SelectedIndex].Name}";
                }
            };
        }

        private async void DataBaseForm_Load(object sender, EventArgs e)
        {

                await Task.Run(() => 
                {
                    try
                    {
                        database = new BD();
                        // Берем все списки элементов из базы данных
                        condensators = database.GetListOfCondensators();
                        resistors = database.GetListOfResistors();
                        IMS = database.GetListOfIMS();
                        semiconductors = database.GetListOfSemiconductor();
                        transformators = database.GetListOfTransformators();
                        opto = database.GetListOfOptoelectr();
                        var classList = database.GetClassList();
                        int count = classList.Count;
                        for (int i = 0; i < count; i++)
                        {
                            comboBox1.Items.Add(classList[i].Name);
                        }
                    }
                    catch (System.Data.Entity.Core.EntityException)
                    {
                        MessageBox.Show("Не удалось подключиться к базе данных!");
                    }
                }
                ) ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            comboBox2.Items.Clear();
            switch (index)
            {
                case 0:
                    currentList = condensators;
                    break;
                case 1:
                    currentList = resistors;
                    break;
                case 2:
                    currentList = IMS;
                    break;
                case 3:
                    currentList = semiconductors;
                    break;
                case 4:
                    currentList = transformators;
                    break;
                case 5:
                    currentList = opto;
                    break;
            }

            foreach (var eri in currentList)
            {
                comboBox2.Items.Add(eri.Name);
            }
        }
    }
}
