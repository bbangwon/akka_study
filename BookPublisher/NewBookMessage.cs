namespace BookPublisher
{
    public class NewBookMessage
    {
        public NewBookMessage(string name)
        {
            this.BookName = name;
        }

        public string BookName { get; }
    }
}
