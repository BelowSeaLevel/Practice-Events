using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExplanationAndTry
{
    /// <summary>
    /// This class must be called in the "Program" class before it works.
    /// This shows how to use the delegate and event within the default "Program" class,
    /// and the default "Main" method.
    /// </summary>
    class EventInMainClass
    {
        public delegate void ShoutOutEventHandler(object source, EventArgs args);
        public event ShoutOutEventHandler publisherEvent;

        IAmSubscriber amSubscriber = new IAmSubscriber();

        public void MainMethod()
        {
            publisherEvent += amSubscriber.SayHiSubscriber;

            CallUpEvent();


            Console.WriteLine("press any key to continue.");
            Console.ReadKey();
        }

        protected void CallUpEvent()
        {
            publisherEvent?.Invoke(this, EventArgs.Empty);
        }

    }

    class IAmSubscriber
    {
        public void SayHiSubscriber(object source, EventArgs e)
        {
            Console.WriteLine("Hello from the subscriber class!");
        }
    }
}
