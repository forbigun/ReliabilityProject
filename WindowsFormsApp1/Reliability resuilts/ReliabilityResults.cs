namespace Reliability
{
    class ReliabilityResults
     {
        public double Lymbda { get; private set; }
        public double Ty { get; private set; }
        /// <summary>
        /// Среднее время наработки до отказа
        /// </summary>
        public double Tsr { get; private set; }
        /// <summary>
        /// Вероятность безотказной работы системы
        /// </summary>
        public double P { get; private set; }

        public ReliabilityResults(double Ty, double Tsr, double P, double lymbda)
        {
            this.Ty = Ty;
            this.Tsr = Tsr;
            this.P = P;
            this.Lymbda = lymbda;
        }
    }
}
