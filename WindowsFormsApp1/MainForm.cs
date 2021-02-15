using Reliability;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;

namespace WindowsFormsApp1
{

    public partial class MainForm : Form
    {
        Project openProject;
        bool removed;
        string logicParametrs = "ABCDEFGHIJKLMNOPQRSTUW";
        Elements currentElements;
        DataGridView projectView = new DataGridView();
        DataGridView elementsView = new DataGridView();
        public MainForm()
        {
            InitializeComponent();
            currentElements = new Elements();
            toolStripSplitButton1.Click += new EventHandler(CreateNewProject);
            OpenProjectStripButton.Click += new EventHandler(OpenProjectToolStripMenuItem_Click);
            SaveProjectStripButton.Click += new EventHandler(SaveProjectToolStripMenuItem_Click);
            SaveAsStripButton.Click += new EventHandler(SaveAsToolStripMenuItem_Click);
            CreateNewToolStripMenuItem.Click += new EventHandler(CreateNewProject);
        }

        private void RestoreLogicParams()
        {
            logicParametrs = "ABCDEFGHIJKLMNOPQRSTUW";
        }

        private void ProjectViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (projectView.SelectedCells.Contains(projectView[1, 0]))
            {
                string newName = projectView[1, 0].Value.ToString();
                DataContainer.ProjectName = newName;
                treeView1.TopNode.Text = newName;
            }
            else if (projectView.SelectedCells.Contains(projectView[1, 1]))
            {
                int time = int.Parse(projectView[1, 1].Value.ToString());
                DataContainer.Time = time;
                if (currentElements.ElementsList.Count > 0)
                {
                    foreach (var el in currentElements.ElementsList)
                        el.SetLyambdaAndCalculateP(el.Lyambda * Math.Pow(10, 6));
                }
            }
            else if (projectView.SelectedCells.Contains(projectView[1, 2]))
            {
                int gamma = int.Parse(projectView[1, 2].Value.ToString());
                DataContainer.GammaProject = gamma;
                projectView[1, 2].Value = DataContainer.GammaProject;
            }
        }

        private void ElementViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = treeView1.SelectedNode.Index;
            // При изменении названия элемента
            if (elementsView.SelectedCells.Contains(elementsView[1, 0]))
            {
                currentElements.ElementsList[index].ChangeName(elementsView[1, 0].Value.ToString());
                treeView1.SelectedNode.Text = $"{elementsView[1, 0].Value} ({currentElements.ElementsList[index].LogicArg})";
            }
            else if (elementsView.SelectedCells.Contains(elementsView[1, 1]))
            {
                double value;
                if (double.TryParse(elementsView[1, 1].Value.ToString(), out value))
                {
                    currentElements.ElementsList[index].SetLyambdaAndCalculateP(value);
                    elementsView[1, 2].Value = currentElements.ElementsList[index].P;
                }

            }
        }

        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger;
            var dataGrid = sender as DataGridView;
            // Проверка строкового формата
            if (dataGrid.SelectedCells.Contains(dataGrid[1, 0]))
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show("Данная строка не может быть пустой!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Проверка полей со временем и гамма-процентом в гриде с проектом
            if (dataGrid != elementsView && (dataGrid.SelectedCells.Contains(dataGrid[1, 1]) || dataGrid.SelectedCells.Contains(dataGrid[1, 2])))
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Допускается ввод только положительных целочисленных значений!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Проверка полей с интенсивностью и вероятностью в гриде с элементами
            if (dataGrid != projectView && dataGrid.SelectedCells.Contains(dataGrid[1, 1]))
            {
                double newValue;
                if (!Double.TryParse(e.FormattedValue.ToString(),
            out newValue) || newValue < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Допускается ввод только положительных значений!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RestoreLogicParams();

            // Динамически создаем ДатаГриды для редактирования данных
            projectView.Dock = elementsView.Dock = DockStyle.Fill;
            projectView.AutoSizeRowsMode = elementsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            projectView.RowTemplate.Height = elementsView.RowTemplate.Height = 30;
            projectView.MultiSelect = elementsView.MultiSelect = false;
            projectView.AllowUserToAddRows = elementsView.AllowUserToAddRows = false;
            projectView.AllowUserToDeleteRows = elementsView.AllowUserToDeleteRows = false;
            projectView.AllowUserToOrderColumns = elementsView.AllowUserToOrderColumns = false;
            projectView.AllowUserToResizeRows = elementsView.AllowUserToResizeRows = false;
            projectView.AllowUserToResizeColumns = elementsView.AllowUserToResizeColumns = false;
            projectView.AutoSizeColumnsMode = elementsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            projectView.RowHeadersVisible = elementsView.RowHeadersVisible = false;
            projectView.BackgroundColor = elementsView.BackgroundColor = SystemColors.MenuBar;
            projectView.CellBorderStyle = elementsView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            projectView.ColumnHeadersHeightSizeMode = elementsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectView.Columns.Add("PropertyName", "Наименование");
            projectView.Columns[0].ReadOnly = true;
            projectView.Columns.Add("PropertyValue", "Значение");
            projectView.Rows.Add("Наименование системы");
            projectView.Rows.Add("Планируемое время работы [ч]", DataContainer.Time);
            projectView.Rows.Add("Гамма процент [%]", DataContainer.GammaProject);
            elementsView.Columns.Add("PropertyName", "Наименование");
            elementsView.Columns[0].ReadOnly = true;
            elementsView.Columns.Add("PropertyValue", "Значение");
            elementsView.Rows.Add("Наименование элемента [1/ч]");
            elementsView.Rows.Add("Интенсивность отказов (10)" + '\u2076' + " [1/ч]");
            elementsView.Rows.Add("Вероятность безотказной работы");
            elementsView[1, 2].ReadOnly = true;
            projectView.Columns[0].SortMode = elementsView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            projectView.Columns[1].SortMode = elementsView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            // Подписываем гриды на события
            projectView.CellValidating += new DataGridViewCellValidatingEventHandler(CellValidating);
            projectView.CellValueChanged += new DataGridViewCellEventHandler(ProjectViewCellValueChanged);
            elementsView.CellValidating += new DataGridViewCellValidatingEventHandler(CellValidating);
            elementsView.CellValueChanged += new DataGridViewCellEventHandler(ElementViewCellValueChanged);


            dataGridView1.Rows.Add("Вероятность безотказной работы системы");
            dataGridView1.Rows.Add("Интенсивность отказов системы [1/ч]");
            dataGridView1.Rows.Add("Средняя наработка до отказа [ч]");
            dataGridView1.Rows.Add("Гамма-процентная наработка до отказа [ч]");
            dataGridView1.Font = new Font("Tahoma", 12);
            HideTabs();
        }

        private void HideTabs()
        {
            tabControl2.TabPages.Remove(StepByStepPage); tabControl2.TabPages.Remove(ReliabilityTab);
            tabControl2.TabPages.Remove(tabPage2);
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    удалитьВыбранныйКомпонентToolStripMenuItem.Enabled = treeView1.SelectedNode == treeView1.TopNode ? false : true;
                    добавитьКомпонентToolStripMenuItem.Enabled = treeView1.SelectedNode == treeView1.TopNode ? true : false;
                    модульToolStripMenuItem.Enabled = treeView1.SelectedNode != treeView1.TopNode ? false : true;
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// Добавляет новый элемент в проект
        /// </summary>
        private void модульToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = InputBox.ShowDialog("Введите наименование элемента: ", "Добавление элемента", "Необходимо ввести наименование элемента системы! ");
            if (name != null)
            {
                if (treeView1.SelectedNode.Level == 0 && logicParametrs.Length > 0)
                {
                    treeView1.Nodes[0].Nodes.Add($"{name} ({logicParametrs[0]})");
                    currentElements.ElementsList.Add(new Element(name, logicParametrs[0]));
                    currentElements.ElementsList = currentElements.ElementsList.OrderBy(n => n.LogicArg).ToList();
                    logicParametrs = logicParametrs.Remove(0, 1);
                }
            }
        }

        private void удалитьВыбранныйКомпонентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removed = true;
            currentElements.ElementsList.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
        }

        /// <summary>
        /// Переприсваивает всем элементам логическую переменную в алфавитном порядке
        /// </summary>
        private void SortElements()
        {
            RestoreLogicParams();
            int count = currentElements.ElementsList.Count;
            for (int i = 0; i < count; i++)
            {
                currentElements.ElementsList[i].ChangeLogicArg(logicParametrs[0]);
                treeView1.TopNode.Nodes[i].Text = $"{currentElements.ElementsList[i].Name} ({currentElements.ElementsList[i].LogicArg})";
                logicParametrs = logicParametrs.Remove(0, 1);
            }
        }

        private void CreateNewProject(object sender, EventArgs e)
        {
            DialogResult dialog = DialogResult.OK;
            if (treeView1.Nodes.Count > 0)
            {
                dialog = MessageBox.Show("Текущий проект будет закрыт. Все несохранненные данные будут утеряны. " +
             "Вы уверены, что хотите продолжить?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    treeView1.Nodes.Clear();
                    PropertyTab.Controls.Clear();
                    HideTabs();
                    //ReliabilityTab.Controls.Clear();
                    //StepByStepPage.Controls[0].Text = String.Empty;
                }
            }
            if (dialog == DialogResult.OK)
            {
                toolStripTextBox1.Text = "";
                string name = InputBox.ShowDialog("Введите наименование системы", "Создание проекта", "Необходимо ввести наименование проекта!");
                if (string.IsNullOrWhiteSpace(name)) return;
                HideTabs();
                currentElements = new Elements();
                openProject = new Project(currentElements);
                PropertyTab.Controls.Add(projectView);
                DataContainer.ProjectName = name;
                projectView[1, 0].Value = name;
                treeView1.Enabled = true;
                treeView1.Nodes.Add(name);
                treeView1.TopNode.BackColor = Color.Green;
                treeView1.TopNode.ForeColor = Color.White;
                RestoreLogicParams();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// Расчет надежности
        /// </summary>

        private void CalculateReliabilityButton_Click(object sender, EventArgs e)
        {
            if (currentElements.ElementsList.Count < 1)
            {
                MessageBox.Show("Перед расчетом необходимо добавить элементы в систему!", "Отсутствуют элементы для расчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LogicFunctionEditor editor = new LogicFunctionEditor(currentElements);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (!tabControl2.TabPages.Contains(ReliabilityTab))
                    tabControl2.TabPages.Add(ReliabilityTab);
                if (!tabControl2.TabPages.Contains(StepByStepPage))
                    tabControl2.TabPages.Add(StepByStepPage);
                if(!tabControl2.TabPages.Contains(tabPage2))
                    tabControl2.TabPages.Add(tabPage2);
                materialMultiLineTextBox1.Clear();
                UpdateReliabilityCalculations();
                сформироватьОтчетToolStripMenuItem.Enabled = true;
            }
        }

        private void UpdateReliabilityCalculations()
        {
            StringBuilder builder = new StringBuilder();
            dataGridView1[1, 0].Value = ReliabilityResultsContainer.Results.P;
            dataGridView1[1, 1].Value = ReliabilityResultsContainer.Results.Lymbda;
            dataGridView1[1, 2].Value = ReliabilityResultsContainer.Results.Tsr;
            dataGridView1[1, 3].Value = ReliabilityResultsContainer.Results.Ty;
            builder.AppendLine("Исходная логическая функция работоспособности:");
            builder.AppendLine(DataContainer.LogicFuntion);
            builder.AppendLine("Преобразуем логическую функцию в совершенную нормальную дизьюнктивную форму: ");
            builder.AppendLine(DataContainer.PerfectForm);
            builder.AppendLine("Заменяем логические операции на алгебраические: ");
            builder.AppendLine(DataContainer.AlgebraicPerfectForm);
            builder.AppendLine("Проведем замену логических переменных на соответствующие вероятности безотказной работы. В итоге, получим расчетную формулу: ");
            builder.AppendLine(DataContainer.FinalAlgebraicFormula);
            builder.AppendLine("\r\nВ результате, получили следующие показатели надежности системы: ");
            builder.AppendLine($"Вероятность безотказной работы P({DataContainer.Time}): {ReliabilityResultsContainer.Results.P:0.000000}");
            builder.AppendLine($"Среднее время наработки до отказа: {ReliabilityResultsContainer.Results.Tsr:0.}");
            builder.AppendLine($"Интенсивность отказов: {ReliabilityResultsContainer.Results.Lymbda}");
            builder.AppendLine($"Гамма-процентная наработка до отказа T({DataContainer.GammaProject}) = {ReliabilityResultsContainer.Results.Ty:0.}");
            materialMultiLineTextBox1.Text = builder.ToString();
            CreateGraphic();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PropertyTab.Controls.Clear();
            if (treeView1.SelectedNode.Level == 0)
            {
                try
                {
                    projectView.CurrentCell = null;
                }
                catch { }
                PropertyTab.Text = "Свойства проекта";
                PropertyTab.Controls.Add(projectView);
            }
            else
            {
                try
                {
                    elementsView.CurrentCell = null;
                }
                catch { }
                if (removed) //Если элемент удалялся, заново перестроить дерево
                {
                    SortElements();
                    removed = false;
                }
                PropertyTab.Text = "Свойства элемента";
                PropertyTab.Controls.Add(elementsView);
                int index = e.Node.Index;
                elementsView[1, 1].Value = currentElements.ElementsList[index].Lyambda == 0 ? string.Empty : currentElements.ElementsList[index].Lyambda.ToString();
                elementsView[1, 2].Value = currentElements.ElementsList[index].P == 0 ? string.Empty : currentElements.ElementsList[index].P.ToString();
                elementsView[1, 0].Value = currentElements.ElementsList[index].Name;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для расчета надежности сложных технических систем. " +
                "Разработал Хабибуллин Александр Эдуардович, студент группы 4413, КНИТУ-КАИ.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.OK;
            if (treeView1.Nodes.Count > 0)
            {
                dialogResult = MessageBox.Show("Текущий проект будет закрыт. Все несохранненные данные будут утеряны. " +
                "Вы уверены, что хотите продолжить?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (dialogResult == DialogResult.OK)
            {
                openProject = Project.OpenProject();
                if (openProject != null)
                {
                    RestoreLogicParams();
                    toolStripTextBox1.Text = openProject.Path;
                    currentElements = openProject.ProjectElemets;
                    if (treeView1.Nodes.Count > 0) treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(openProject.Name);
                    if (currentElements.ElementsList.Count > 0)
                    {
                        foreach (Element element in currentElements.ElementsList)
                        {
                            treeView1.TopNode.Nodes.Add(element.Name + " (" + element.LogicArg + ")");
                            logicParametrs = logicParametrs.Remove(logicParametrs.IndexOf(element.LogicArg), 1);
                        }
                    }
                    treeView1.Enabled = true;
                    treeView1.TopNode.BackColor = Color.Green;
                    treeView1.TopNode.ForeColor = Color.White;
                    projectView[1, 0].Value = DataContainer.ProjectName = openProject.Name;
                    projectView[1, 1].Value = DataContainer.Time = openProject.Time;
                    projectView[1, 2].Value = DataContainer.GammaProject = openProject.Gamma;
                }
            }
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentElements.ElementsList.Count > 0)
            {
                Project project = openProject;
                if (project.ProjectElemets.ElementsList.Count == 0) project.ProjectElemets = currentElements;//Если создавался новый проект
                project.SaveProject();
                toolStripTextBox1.Text = project.Path;
            }
            else MessageBox.Show("Проект пустой. Добавьте хотя бы один элемент!", "Ошибка при сохранении проекта", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentElements.ElementsList.Count > 0)
            {
                Project project = new Project(currentElements);
                project.SaveProjectAs();
                toolStripTextBox1.Text = project.Path;
            }
            else MessageBox.Show("Проект пустой. Добавьте хотя бы один элемент!", "Ошибка при сохранении проекта", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void сформироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelReport report = new ExcelReport(ReliabilityResultsContainer.Results);
            report.SaveReport();
            сформироватьОтчетToolStripMenuItem.Enabled = false;
        }

        private void ERIMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseForm form = new DataBaseForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (treeView1.SelectedNode.Level == 0 && logicParametrs.Length > 0)
                {
                    treeView1.Nodes[0].Nodes.Add($"{form.ERIName} ({logicParametrs[0]})");
                    currentElements.ElementsList.Add(new Element(form.ERIName, logicParametrs[0]));
                    currentElements.ElementsList[currentElements.ElementsList.Count - 1].SetLyambdaAndCalculateP(form.lymbda);
                    logicParametrs = logicParametrs.Remove(0, 1);
                }
            }
        }

        private void CreateGraphic()
        {
            chart1.Series[0].Points.Clear();
            int step = 10000;
            double lyambda = ReliabilityResultsContainer.Results.Lymbda;
            double P;
            chart1.ChartAreas[0].AxisX.Title = "Время работы t, ч";
            chart1.ChartAreas[0].AxisY.Title = "Вероятность безотказной работы P(t)";
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1000000;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            int i = 0;
            do
            {
                P = Math.Pow(Math.E, (double)(-lyambda * i));
                chart1.Series[0].Points.AddXY(i, P);
                i += step;
            }
            while (P > Math.Pow(10,-6));
        }
    }
}
