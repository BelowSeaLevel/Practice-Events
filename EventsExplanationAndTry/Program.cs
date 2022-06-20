using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsExplanationAndTry
{
    class Program
    {

        static void Main()
        {
            // Instantiate the Classes.
            var publisher = new Publisher();
            var subscriber = new Subscriber();
            var EventMain = new EventInMainClass();
            EventMain.MainMethod();

            // subscribes the subscriber to the publisher.
            // we do this with the "+=". (Class.event += Class.Method.)
            // Notice with the method we do not use (). We are not making a call, this is a reference to the method.
            publisher.publisherEvent += subscriber.OnEventHasBeenRaised;


            publisher.CallingTheRaiseEvent();
            


            Console.ReadKey();
        }


    }

    public class Publisher
    {
        // delegate.
        // determits the shape or the signature of the method in the subscriber.
        public delegate void ShoutOutEventHandler(object source, EventArgs args);

        // Event based on the delegate.
        public event ShoutOutEventHandler publisherEvent;

        public void CallingTheRaiseEvent()
        {
            // The waiting 4 seconds is for demo purpose.
            // To see or we realy raise the event.
            Console.WriteLine("Calling the event in 4 seconds...");

            // Waits for 4 seconds.
            Thread.Sleep(4000);

            // We call the onRaiseEvent method.
            // Who checks for subscribers and raises the event.
            onRaiseEvent();
        }

        // Method to raise the event.
        protected virtual void onRaiseEvent()
        {
            // Checks or there are any subscribers to this event.
            if (publisherEvent != null)
            {
                // Raises the event
                // this = the current object.
                publisherEvent(this, EventArgs.Empty);
            }
        }
    }


    public class Subscriber
    {
        // Notice that this Method is the same as the delegate
        // "void", "object source" and "EventArgs e"
        public void OnEventHasBeenRaised(object source, EventArgs e)
        {
            Console.WriteLine("The event has been raised!");
        }
    }

}

