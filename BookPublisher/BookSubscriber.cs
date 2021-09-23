using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace BookPublisher
{
    public class BookSubscriber : ReceiveActor
    {
        public BookSubscriber()
        {
            Receive<NewBookMessage>(HandleNewBookMessage);
        }

        private void HandleNewBookMessage(NewBookMessage book)
        {
            Console.WriteLine($"Book: {book.BookName} got published - message received by {Self.Path.Name}!");
        }
    }
}
