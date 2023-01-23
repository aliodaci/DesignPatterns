using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesign
{
    
    class Program
    {   static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager._sender = new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public MessageSenderBase _sender { get; set; }

        public void UpdateCustomer()
        {
            _sender.Send(new Body());
            Console.WriteLine("Customer Updated");
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved");
        }

        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via SmsSender",body.Text);
            
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via EmailSender",body);
        }
    }

}
