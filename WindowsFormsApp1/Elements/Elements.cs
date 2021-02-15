using System.Collections.Generic;

namespace Reliability
{
    /// <summary>
    /// Список элементов системы
    /// </summary>
    public class Elements
    {
        public List<Element> ElementsList { get; set; }

        public Elements()
        {
            ElementsList = new List<Element>();
        }

        public Elements(List<Element> ElList)
        {
            ElementsList = new List<Element>(ElList);
        }
        public Elements(Elements elements)
        {
            ElementsList = new List<Element>();
            foreach (Element element in elements.ElementsList)
            {
                ElementsList.Add(element);
            }
        }
    }
}
