using System;

namespace Reliability
{
    /// <summary>
    /// Элемент системы
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Наименование элемента
        /// </summary>
        public string Name { get;  set; }
        /// <summary>
        /// Интенсивность отказов элемента
        /// </summary>
        public double Lyambda { get;  set; }
        /// <summary>
        /// Вероятность безотказной работы элемента
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// Логическая переменная элемента
        /// </summary>
        public char LogicArg { get; set; }
        public Element(string name,char logicArg)
        {
            this.Name = name;
            this.LogicArg = logicArg;
        }

        /// <summary>
        /// Меняет имя элемента
        /// </summary>

        public void ChangeName(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// Меняет логический параметр элемента
        /// </summary>
        /// <param name="logicArg"> Логический параметр</param>
        public void ChangeLogicArg(char logicArg)
        {
            this.LogicArg = logicArg;
        }
        /// <summary>
        /// Присваивает интенсивность отказов данному элементу и вычисляет вероятность его безотказной работы
        /// </summary>
        /// <param name="lymbda"> Интенсивность отказов</param>
        public void SetLyambdaAndCalculateP(double lyambda)
        {
            this.Lyambda = lyambda*Math.Pow(10, -6);
            P = Math.Pow(Math.E,(double)(-Lyambda*DataContainer.Time));
        }
    }
}
