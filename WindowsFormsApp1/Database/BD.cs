using System.Collections.Generic;
using System.Linq;

namespace Reliability.Database
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    class BD
    {
        public ReliabilityContext context { get;  }
        public BD()
        {
            context = new ReliabilityContext();
        }
        public List<ERI> GetElementsList()
        {
            var elements = context.ERI.ToList();
            return elements;
        }

        public List<Class> GetClassList()
        {
            var classes = context.Class.ToList();
            return classes;
        }

        public List<ERI> GetListOfCondensators()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 1);
            List<ERI> condensators = query.ToList();
                return condensators;
        }

        public List<ERI> GetListOfResistors()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 2);
            List<ERI> resistors = query.ToList();
            return resistors;
        }

        public List<ERI> GetListOfIMS()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 3);
            List<ERI> IMS = query.ToList();
            return IMS;
        }

        public List<ERI> GetListOfSemiconductor()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 4);
            List<ERI> semiconductor = query.ToList();
            return semiconductor;
        }


        public List<ERI> GetListOfTransformators()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 5);
            List<ERI> transformator = query.ToList();
            return transformator;
        }

        public List<ERI> GetListOfOptoelectr()
        {
            IQueryable<ERI> query = context.ERI.Where(c => c.IDClass == 6);
            List<ERI> optoelectr = query.ToList();
            return optoelectr;
        }

    }
}
