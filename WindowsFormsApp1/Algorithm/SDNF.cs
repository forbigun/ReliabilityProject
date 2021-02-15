using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reliability
{
    static class SDNF
    {
        /// <summary>
        /// Вычисляет значение логической функции для текущего сочетания значений её аргументов. 
        /// В случае, если оно истинно, то на основе значений всех аргументов формируется очередная по счёту дизъюнкция для записи СДНФ
        /// </summary>
        private static bool Evaluate(String input)
        {
            String expr = "(" + input + ")";
            Stack<char> ops = new Stack<char>();
            Stack<bool> vals = new Stack<bool>();

            for (int i = 0; i < expr.Length; i++)
            {
                char ch = expr[i];
                if (ch.Equals('(')) ops.Push(ch);
                else if (ch.Equals('+')) ops.Push(ch);
                else if (ch.Equals('*')) ops.Push(ch);
                else if (ch.Equals('!')) ops.Push(ch);
                else if (ch.Equals(')'))
                {
                    int count = ops.Count;
                    if (count == 0)
                        continue;

                    char op = ops.Pop();
                    while (count > 0)
                    {
                        if (op.Equals('('))
                            break;

                        bool v = vals.Pop();

                        if (op.Equals('+'))
                            v = vals.Pop() || v;
                        else if (op.Equals('!'))
                            v = !v;

                        bool inner_oper = false;

                        do
                        {
                            count--;
                            if (op.Equals('*'))
                            {
                                v = vals.Pop() && v;
                                if (count > 0)
                                    op = ops.Pop();

                                inner_oper = true;
                            }
                        } while (count > 0 && op.Equals('*'));

                        vals.Push(v);
                        if (count > 0 && !inner_oper)
                            op = ops.Pop();
                    }
                }
                else vals.Push(ch == '1');
            }
            return vals.Pop();
        }
        /// <summary>
        /// Перебирает все возможные сочетания нулей и единиц для каждого из аргументов функции.
        /// Функция возвращает список всех возможных значений аргумента на данном шаге, 
        /// каждое из которых затем добавляется к значениям аргументов, полученных на предыдущем шаге
        /// </summary>
        /// <param name="operands">Список аргументов</param>
        /// <param name="pos_index">Позиция нужного аргумента</param>
        private static List<String> Digits_form(List<char> operands, int pos_index)
        {
            if (pos_index < operands.Count)
            {
                String operand = operands[pos_index].ToString();
                List<String> output_forms = Digits_form(operands, pos_index + 1);

                List<String> result_forms = new List<string>();
                foreach (String output_form in output_forms)
                    for (byte value = 0; value <= 1; value++)
                        result_forms.Add(output_form.Replace(operand, value.ToString()));
                return result_forms;
            }
            else
                return new List<string>() { String.Concat(operands.Select(s => s.ToString())) };
        }
        /// <summary>
        /// Преобразует логическую функцию в СДНФ
        /// </summary>
        public static String GetSDNF(String expr_str)
        {
            List<char> operands;
            String converted_expr = Convert_to_expr(expr_str, out operands);

            StringBuilder result = new StringBuilder();
            List<String> output_forms = Digits_form(operands, 0);
            int count = 0;
            bool value;
            foreach (String output_form in output_forms)
            {
                String input = converted_expr;
                for (int index = 0; index < operands.Count; index++)
                    input = input.Replace(operands[index], output_form[index]);

                value = Evaluate(input);
                if (value)
                {
                    if (count > 0)
                        result.Append('V');

                    result.Append('(');
                    for (int index = 0; index < operands.Count; index++)
                    {
                        if (output_form[index] == '0')
                            result.Append('!');
                        result.Append(operands[index]);
                        if (index < operands.Count - 1)
                            result.Append('^');
                    }
                    result.Append(')');
                    count++;
                }
            }
            return result.ToString();
        }
        /// <summary>
        /// Преобразует СДНФ в расчетную формулу
        /// </summary>
        private static String Convert_to_expr(String expr_str, out List<char> operands, bool convert_neg = false)
        {
            operands = new List<char>();
            StringBuilder result = new StringBuilder();
            bool scan_neg = false;
            for (int index = 0; index < expr_str.Length; index++)
            {
                char ch = expr_str[index];
                switch (ch)
                {
                    case '(':
                    case ')':
                        result.Append(ch);
                        break;
                    case ' ':
                        break;
                    case 'v':
                    case 'V':
                        result.Append('+');
                        break;
                    case '^':
                        result.Append('*');
                        break;
                    case '!':
                    case '¬':
                    case '┐':
                        if (convert_neg)
                        {
                            result.Append("(1-");
                            scan_neg = true;
                        }
                        else
                            result.Append("!");
                        break;
                    default:
                        if (!operands.Contains(ch))
                            operands.Add(ch);
                        result.Append(ch);
                        if (scan_neg)
                        {
                            result.Append(')');
                            scan_neg = false;
                        }
                        break;
                }
            }
            return result.ToString();
        }
        /// <summary>
        /// Преобразует СДНФ в алгебраическую форму
        /// </summary>
        public static String Convert_to_expr(String expr_str)
        {
            List<char> operands;
            return Convert_to_expr(expr_str, out operands, true);
        }

    }
}
