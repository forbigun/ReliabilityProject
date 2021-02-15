using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reliability
{
    public partial class LogicFunctionEditor : Form
    {
        int position;
        string enabledParams;
        Elements listOfElements;
        private int selectedPosition//позиция курсора в текстбоксе
        {
            get
            {
                return position;
            }
            set
            {
                if (value < 0)
                    position = 0;
                else position = value;
            }
        }
        public LogicFunctionEditor(Elements elements)
        {
            InitializeComponent();
            listOfElements = new Elements(elements);          
            enabledParams = EnableParametrs();
            foreach (var control in tableLayoutPanel1.Controls.OfType<Button>())
            {
                if (char.IsLetter(control.Text[0]) && control.Text.Length == 1 && control.Text[0]!='v')
                {
                    if(enabledParams.Contains(control.Text[0]))
                    {
                        control.BackColor = Color.DarkOliveGreen;
                        control.Enabled = true;
                    }
                    else
                    {
                        control.BackColor = enabledParams.Contains(control.Text[0]) ? Color.DarkOliveGreen : Color.IndianRed;
                        control.Enabled = false;
                    }
    
                }
                control.Click += new EventHandler(ToolButtonsClick);
            }
        }

        private string EnableParametrs()
        {
            StringBuilder usingParams = new StringBuilder();
            foreach (Element element in listOfElements.ElementsList)
            {
                usingParams.Append(element.LogicArg);
            }
            return usingParams.ToString();
        }

        private void ToolButtonsClick(object sender, EventArgs e)
        {
            textBox1.Focus();
            Button button = sender as Button;
            if ((button.Text.Length == 1 && char.IsLetter(button.Text[0]) && button.Text[0] != 'v'
             || button.Text[0] == '('))
            {
                textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                if(char.IsLetter(button.Text[0]))
                {
                    button.Enabled = false;
                    button.BackColor = Color.IndianRed;
                }
                selectedPosition++;
            }
            switch (button.Text)
            {
                case ")":
                    if (selectedPosition > 0 && textBox1.Text.Where(n => n == ')').Count() < textBox1.Text.Where(n => n == '(').Count())
                    {
                        if (textBox1.Text[selectedPosition - 1] == '(')
                            MessageBox.Show("Выражение в скобках не может быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                            selectedPosition++;
                        }
                    }
                    break;
                case "Back":
                    if (selectedPosition > 0)
                    {
                        if (selectedPosition < textBox1.Text.Length && (textBox1.Text[selectedPosition] == '^' || textBox1.Text[selectedPosition] == 'v')
                          && char.IsLetter(textBox1.Text[selectedPosition - 1]))
                        {
                            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart - 1, 2);
                            selectedPosition -= 2;
                        }
                        else
                        {
                            if (textBox1.SelectionStart - 1 < 0)
                                return;
                            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart - 1, 1);
                            selectedPosition--;
                        }
                    }
                    break;
                case "Clear":
                    {
                        textBox1.Clear();
                        foreach (Button but in tableLayoutPanel1.Controls)
                        {
                            if (but.Text.Length == 1 && enabledParams.Contains(but.Text[0]) && !but.Enabled)
                            {
                                but.Enabled = true;
                                but.BackColor = Color.DarkOliveGreen;
                            }
                        }
                        selectedPosition = 0;
                        break;
                    }
                case "->":
                    {
                        if (selectedPosition < textBox1.Text.Length)
                        {
                            selectedPosition++;
                            textBox1.SelectionStart = selectedPosition;
                        }
                        break;
                    }
                case "<-":
                    {
                        if (selectedPosition != 0)
                        {
                            selectedPosition--;
                            textBox1.SelectionStart = selectedPosition;
                        }
                        break;
                    }
                case "^":
                    {
                        if (selectedPosition == textBox1.Text.Length && selectedPosition != 0 &&
                            (char.IsLetter(textBox1.Text[selectedPosition - 1]) || (textBox1.Text[selectedPosition - 1] == ')'))
                            && textBox1.Text[selectedPosition - 1] != 'v')
                        {
                            textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                            selectedPosition++;
                        }
                        if (selectedPosition < textBox1.Text.Length && selectedPosition > 0
                            && char.IsLetter(textBox1.Text[selectedPosition - 1]) && char.IsLetter(textBox1.Text[selectedPosition]))
                        {
                            textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                            selectedPosition++;
                        }
                        break;
                    }
                case "v":
                    {
                        if (selectedPosition == textBox1.Text.Length && selectedPosition != 0
                            && (char.IsLetter(textBox1.Text[selectedPosition - 1]) || (textBox1.Text[selectedPosition - 1] == ')'))
                            && textBox1.Text[selectedPosition - 1] != 'v')
                        {
                            textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                            selectedPosition++;
                        }
                        if (selectedPosition < textBox1.Text.Length && selectedPosition > 0
                            && char.IsLetter(textBox1.Text[selectedPosition - 1]) && char.IsLetter(textBox1.Text[selectedPosition]))
                        {
                            textBox1.Text = textBox1.Text.Insert(selectedPosition, button.Text);
                            selectedPosition++;
                        }
                        break;
                    }
            }
            CheckOperations();
            textBox1.SelectionStart = selectedPosition;
        }

        private void CheckOperations()
        {
            textBox1.Focus();
            string result = textBox1.Text;
            for (int i = 0; i < result.Length - 1; i++)
            {
                if (result[i] == ')' && char.IsLetter(result[i + 1]) && result[i + 1] != 'v')
                {
                    result = result.Insert(i + 1, "^");
                    selectedPosition++;
                }
                if (char.IsLetter(result[i]) && result[i] != 'v' && result[i + 1] != 'v' && (result[i + 1] == '(' || char.IsLetter(result[i + 1])))
                {
                    result = result.Insert(i + 1, "^");
                    selectedPosition++;
                }
                if (result[i] == ')' && result[i + 1] == '(')
                {
                    result = result.Insert(i + 1, "^");
                    selectedPosition++;
                }
            }         
            textBox1.Text = result;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void LogicFunctionEditor_Load(object sender, EventArgs e)
        {
            position = 0;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // пытаемся получить СДНФ, тем самым проверяем корректность ввода логической функции
            try
            {
                DataContainer.PerfectForm = SDNF.GetSDNF(textBox1.Text); //В случае успеха при построение СДНФ, сохраняем ее
                DataContainer.AlgebraicPerfectForm = SDNF.Convert_to_expr(DataContainer.PerfectForm); //Сохраняем алгебраическую форму
                DataContainer.LogicFuntion = textBox1.Text; // сохраняем логическую функцию
                LogicalMethod method = new LogicalMethod();
                method.ReliabilityCalculate(listOfElements,DataContainer.AlgebraicPerfectForm);
                DialogResult = DialogResult.OK;
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show("Ошибка в построение логической функции!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
