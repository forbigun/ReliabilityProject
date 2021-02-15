namespace Reliability
{
    /// <summary>
    /// Данный класс хранит промежуточные результаты расчетов
    /// </summary>
    static class DataContainer
    {
        /// <summary>
        /// Логическая функция работоспособности
        /// </summary>
        public static string LogicFuntion { get; set; }
        /// <summary>
        /// Совершенная дизъюнктивная нормальная форма
        /// </summary>
        public static string PerfectForm { get; set; }
        /// <summary>
        /// Алгебраический вид СДНФ
        /// </summary>
        public static string AlgebraicPerfectForm { get; set; }
        /// <summary>
        /// Расчетная формула
        /// </summary>
        public static string FinalAlgebraicFormula { get; set; }

        /// <summary>
        /// Наименование системы
        /// </summary>
        public static string ProjectName { get; set; }
        /// <summary>
        /// Планируемое время работы системы
        /// </summary>
        public static int Time { get; set; } = 20000; 
        private static int gamma = 90;
        public static int GammaProject
        {
            get { return gamma; }
            set
            {
                if (value > 0 && value < 101)
                    gamma = value;
                if (value <= 0)
                    gamma = 5;
                if (value > 100)
                    gamma = 95;
            }
        }
    }
}
