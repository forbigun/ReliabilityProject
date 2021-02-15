namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьКомпонентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модульToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ERIMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВыбранныйКомпонентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripButton();
            this.OpenProjectStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveProjectStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CalculateReliabilityButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.PropertyTab = new System.Windows.Forms.TabPage();
            this.ReliabilityTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepByStepPage = new System.Windows.Forms.TabPage();
            this.materialMultiLineTextBox1 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.ReliabilityTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StepByStepPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProjectToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.сформироватьОтчетToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(789, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ProjectToolStripMenuItem
            // 
            this.ProjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewToolStripMenuItem,
            this.OpenProjectToolStripMenuItem,
            this.SaveProjectToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.ProjectToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
            this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.ProjectToolStripMenuItem.Text = "Проект";
            // 
            // CreateNewToolStripMenuItem
            // 
            this.CreateNewToolStripMenuItem.Image = global::Reliability.Properties.Resources.Чистый_лист;
            this.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem";
            this.CreateNewToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.CreateNewToolStripMenuItem.Text = "Создать новый";
            // 
            // OpenProjectToolStripMenuItem
            // 
            this.OpenProjectToolStripMenuItem.Image = global::Reliability.Properties.Resources.open;
            this.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem";
            this.OpenProjectToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.OpenProjectToolStripMenuItem.Text = "Открыть";
            this.OpenProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
            // 
            // SaveProjectToolStripMenuItem
            // 
            this.SaveProjectToolStripMenuItem.Image = global::Reliability.Properties.Resources.Save1;
            this.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem";
            this.SaveProjectToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.SaveProjectToolStripMenuItem.Text = "Сохранить";
            this.SaveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Image = global::Reliability.Properties.Resources.SaveAs;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // сформироватьОтчетToolStripMenuItem
            // 
            this.сформироватьОтчетToolStripMenuItem.Enabled = false;
            this.сформироватьОтчетToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сформироватьОтчетToolStripMenuItem.Name = "сформироватьОтчетToolStripMenuItem";
            this.сформироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.сформироватьОтчетToolStripMenuItem.Text = "Сформировать отчет";
            this.сформироватьОтчетToolStripMenuItem.Click += new System.EventHandler(this.сформироватьОтчетToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКомпонентToolStripMenuItem,
            this.удалитьВыбранныйКомпонентToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(251, 48);
            // 
            // добавитьКомпонентToolStripMenuItem
            // 
            this.добавитьКомпонентToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модульToolStripMenuItem,
            this.ERIMenuItem});
            this.добавитьКомпонентToolStripMenuItem.Name = "добавитьКомпонентToolStripMenuItem";
            this.добавитьКомпонентToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.добавитьКомпонентToolStripMenuItem.Text = "Добавить компонент";
            // 
            // модульToolStripMenuItem
            // 
            this.модульToolStripMenuItem.Name = "модульToolStripMenuItem";
            this.модульToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.модульToolStripMenuItem.Text = "Новый элемент";
            this.модульToolStripMenuItem.Click += new System.EventHandler(this.модульToolStripMenuItem_Click);
            // 
            // ERIMenuItem
            // 
            this.ERIMenuItem.Name = "ERIMenuItem";
            this.ERIMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ERIMenuItem.Text = "ЭРИ из базы данных";
            this.ERIMenuItem.Click += new System.EventHandler(this.ERIMenuItem_Click);
            // 
            // удалитьВыбранныйКомпонентToolStripMenuItem
            // 
            this.удалитьВыбранныйКомпонентToolStripMenuItem.Name = "удалитьВыбранныйКомпонентToolStripMenuItem";
            this.удалитьВыбранныйКомпонентToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.удалитьВыбранныйКомпонентToolStripMenuItem.Text = "Удалить выбранный компонент";
            this.удалитьВыбранныйКомпонентToolStripMenuItem.Click += new System.EventHandler(this.удалитьВыбранныйКомпонентToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.OpenProjectStripButton,
            this.SaveProjectStripButton,
            this.SaveAsStripButton,
            this.toolStripSeparator1,
            this.CalculateReliabilityButton,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(789, 39);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.AutoSize = false;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = global::Reliability.Properties.Resources.Чистый_лист;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(30, 30);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ToolTipText = "Новый проект";
            // 
            // OpenProjectStripButton
            // 
            this.OpenProjectStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenProjectStripButton.Image = global::Reliability.Properties.Resources.open;
            this.OpenProjectStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenProjectStripButton.Name = "OpenProjectStripButton";
            this.OpenProjectStripButton.Size = new System.Drawing.Size(34, 36);
            this.OpenProjectStripButton.Text = "toolStripButton3";
            this.OpenProjectStripButton.ToolTipText = "Открыть";
            // 
            // SaveProjectStripButton
            // 
            this.SaveProjectStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveProjectStripButton.Image = global::Reliability.Properties.Resources.save;
            this.SaveProjectStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveProjectStripButton.Name = "SaveProjectStripButton";
            this.SaveProjectStripButton.Size = new System.Drawing.Size(34, 36);
            this.SaveProjectStripButton.Text = "toolStripButton1";
            this.SaveProjectStripButton.ToolTipText = "Сохранить проект";
            // 
            // SaveAsStripButton
            // 
            this.SaveAsStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsStripButton.Image = global::Reliability.Properties.Resources.SaveAs;
            this.SaveAsStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsStripButton.Name = "SaveAsStripButton";
            this.SaveAsStripButton.Size = new System.Drawing.Size(34, 36);
            this.SaveAsStripButton.Text = "toolStripButton2";
            this.SaveAsStripButton.ToolTipText = "Сохранить проект как";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(15, 39);
            // 
            // CalculateReliabilityButton
            // 
            this.CalculateReliabilityButton.AutoSize = false;
            this.CalculateReliabilityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CalculateReliabilityButton.Image = global::Reliability.Properties.Resources.Расчет;
            this.CalculateReliabilityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CalculateReliabilityButton.Name = "CalculateReliabilityButton";
            this.CalculateReliabilityButton.Size = new System.Drawing.Size(30, 30);
            this.CalculateReliabilityButton.Text = "toolStripButton1";
            this.CalculateReliabilityButton.ToolTipText = "Расчет надежности";
            this.CalculateReliabilityButton.Click += new System.EventHandler(this.CalculateReliabilityButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(15, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(101, 36);
            this.toolStripLabel1.Text = "Путь проекта";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(450, 30);
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(190, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Состав системы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Enabled = false;
            this.treeView1.HideSelection = false;
            this.treeView1.LineColor = System.Drawing.Color.Blue;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(184, 382);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(198, 417);
            this.tabControl1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(789, 421);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.PropertyTab);
            this.tabControl2.Controls.Add(this.ReliabilityTab);
            this.tabControl2.Controls.Add(this.StepByStepPage);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(578, 417);
            this.tabControl2.TabIndex = 0;
            // 
            // PropertyTab
            // 
            this.PropertyTab.Location = new System.Drawing.Point(4, 25);
            this.PropertyTab.Name = "PropertyTab";
            this.PropertyTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertyTab.Size = new System.Drawing.Size(570, 388);
            this.PropertyTab.TabIndex = 0;
            this.PropertyTab.Text = "Свойства ";
            this.PropertyTab.UseVisualStyleBackColor = true;
            // 
            // ReliabilityTab
            // 
            this.ReliabilityTab.Controls.Add(this.dataGridView1);
            this.ReliabilityTab.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReliabilityTab.Location = new System.Drawing.Point(4, 25);
            this.ReliabilityTab.Name = "ReliabilityTab";
            this.ReliabilityTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReliabilityTab.Size = new System.Drawing.Size(570, 388);
            this.ReliabilityTab.TabIndex = 1;
            this.ReliabilityTab.Text = "Параметры безотказности";
            this.ReliabilityTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(564, 382);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Наименование";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Значение";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StepByStepPage
            // 
            this.StepByStepPage.Controls.Add(this.materialMultiLineTextBox1);
            this.StepByStepPage.Location = new System.Drawing.Point(4, 22);
            this.StepByStepPage.Name = "StepByStepPage";
            this.StepByStepPage.Padding = new System.Windows.Forms.Padding(3);
            this.StepByStepPage.Size = new System.Drawing.Size(570, 391);
            this.StepByStepPage.TabIndex = 2;
            this.StepByStepPage.Text = "Пошаговое решение";
            this.StepByStepPage.UseVisualStyleBackColor = true;
            // 
            // materialMultiLineTextBox1
            // 
            this.materialMultiLineTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialMultiLineTextBox1.Depth = 0;
            this.materialMultiLineTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialMultiLineTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox1.Hint = "";
            this.materialMultiLineTextBox1.Location = new System.Drawing.Point(3, 3);
            this.materialMultiLineTextBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox1.Name = "materialMultiLineTextBox1";
            this.materialMultiLineTextBox1.ReadOnly = true;
            this.materialMultiLineTextBox1.Size = new System.Drawing.Size(564, 385);
            this.materialMultiLineTextBox1.TabIndex = 0;
            this.materialMultiLineTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 391);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "График";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.RoyalBlue;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(564, 385);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "График зависимости ВБР от времени";
            this.chart1.Titles.Add(title1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 488);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(805, 527);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прогнозирование надежности";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ReliabilityTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StepByStepPage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьКомпонентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модульToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВыбранныйКомпонентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateNewToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton CalculateReliabilityButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage PropertyTab;
        private System.Windows.Forms.TabPage ReliabilityTab;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TabPage StepByStepPage;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox1;
        private System.Windows.Forms.ToolStripMenuItem OpenProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveProjectStripButton;
        private System.Windows.Forms.ToolStripButton SaveAsStripButton;
        private System.Windows.Forms.ToolStripButton OpenProjectStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem ERIMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

