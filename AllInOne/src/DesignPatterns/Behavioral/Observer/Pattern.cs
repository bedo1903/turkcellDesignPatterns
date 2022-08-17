using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /*
     * Problem:
     * 
     * Bir nesne üzerinde yapılacak bir işlemin varolan diğer nesneleri de etkileyeceği bir senaryonuz var. Event fırlatmadan bu ihtiyacınızı nasıl giderirsiniz?
     */
    public interface IObserver
    {
        void ColorChange(Color color);
    }

    public interface ISubscription
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void Notify();
    }

    public class ColorChangedSubscription : ISubscription
    {
        private List<IObserver> observers =new List<IObserver>();

        private Color color;
        public Color Color
        {
            get { return color; }
            set { 
                color = value;
                Notify();
            }
        }
        public void Notify()
        {
            observers.ForEach(o => o.ColorChange(color));
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}

