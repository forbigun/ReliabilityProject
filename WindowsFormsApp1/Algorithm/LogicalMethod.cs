using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reliability
{
    /// <summary>
    /// Логико-вероятностный метод
    /// </summary>
    class LogicalMethod
    {

        public LogicalMethod()
        {

        }
        /// <summary>
        /// Рассчитывает интенсивность отказов системы
        /// </summary>
        /// <param name="P"> Вероятность безотказной работы системы</param>
        /// <param name="time"> Время работы системы </param>
        /// <returns></returns>
        private double CalculateLyambda(double P,int time)
        {
            return -(Math.Log(P)/(double)time);
        }
        /// <summary>
        /// Рассчитывает среднее время наработки системы до отказа 
        /// </summary>
        /// <param name="lymbda"> Интенсивность отказов</param>
        /// <returns></returns>
        private double CalculateTsr(double lymbda)
        {
            return 1.0 / lymbda;
        }
        /// <summary>
        /// Рассчитывает Гамма-процентную наработку до отказа всей системы
        /// </summary>
        /// <param name="T"> Время работы системы</param>
        /// <param name="gamma"> Гамма-процент</param>
        /// <returns></returns>
        private double CalculateTy(double T, int gamma)
        {
            double osnovanie = ((double)gamma / 100.0);
            return -T * Math.Log(osnovanie);
        }
        /// <summary>
        /// Делит расчетную формулу на несколько частей по знаку +
        /// </summary>
        /// <param name="formula"> Итоговая формула для расчета</param>
        /// <returns></returns>

        private List<string> DivideFormula(string formula)
        {
            int startIndex;
            int endIndex;
            List<string> results = new List<string>();
            List<int> indices = new List<int>() { 0 };
            char search = '+';
            // Ищем все вхождения знака ПЛЮС
            int index = formula.IndexOf(search);
            if(index < 0)
            {
                startIndex = 0;
                endIndex = formula.Length;
                results.Add(formula.Substring(startIndex, endIndex));
                return results;
            }
            while (index > -1)
            {
                indices.Add(index);
                index = formula.IndexOf(search, index + 1);
            }
            int count = indices.Count();
            // Копируем каждую последовательность до очередного знака + в список
            for (int i = 0; i < count - 1; i++)
            {
                startIndex = indices[i] != 0 ? indices[i] + 1 : 0;
                endIndex = indices[i + 1];
                results.Add(formula.Substring(startIndex, endIndex - startIndex));
            }
            results.Add(formula.Substring(indices[count - 1] + 1, formula.Length - indices[count - 1] - 1));
            return results;
        }
        /// <summary>
        /// Осуществляет последовательное сложение всех формул и рассчитывает вероятность безотказной работы системы
        /// </summary>
        /// <param name="formulas"> Список всех формул для их поочередного сложения</param>
        /// <returns></returns>
        private double CalculateAll(List<string> formulas)
        {
            List<double> listofValues = new List<double>(formulas.Count);
            foreach (string str in formulas)
            {
                Expression parser = new Expression(str);
                listofValues.Add(parser.calculate());
            }
            return listofValues.Sum();
        }

        /// <summary>
        /// Рассчитывает вероятность безотказной работы системы
        /// </summary>
        /// <param name="ElementsList">Список элементов системы</param>
        /// <param name="algebraicForm">Алгебраическая форма СДНФ</param>
        /// <returns></returns>
        public void ReliabilityCalculate(Elements ElementsList, string algebraicForm)
        {
            string finalStr = algebraicForm;
            double Tsr;
            double Ty;
            double lymbda;
            double P;
            string formula = algebraicForm;
            foreach(Element element in ElementsList.ElementsList)
            {
                finalStr = finalStr.Replace(element.LogicArg.ToString(), $"{element.P:0.000000}");
                formula = formula.Replace(element.LogicArg.ToString(),$"{element.P}");
            }
            DataContainer.FinalAlgebraicFormula = finalStr;
            formula = formula.Replace(",", ".");
            List<string> expressions = DivideFormula(formula);
            P = CalculateAll(expressions);
            lymbda = CalculateLyambda(P,DataContainer.Time);
            Tsr = CalculateTsr(lymbda);
            Ty = CalculateTy(Tsr,DataContainer.GammaProject);
            ReliabilityResultsContainer.Results = new ReliabilityResults(Ty,Tsr,P,lymbda);
        }
    }
}
