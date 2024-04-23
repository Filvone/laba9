using System;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
abstract class Message
{
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public DateTime Timestamp { get; set; }

    public abstract void Protocol();
    public Message(string sender, string recipient)
    {
        Sender = sender;
        Recipient = recipient; Timestamp = DateTime.Now;
    }
    ~Message()
    {
        Console.WriteLine("Message object destroyed.");
    }
}
abstract class ElectronicMessage : Message
{
    public string Subject { get; set; }    
    
    public ElectronicMessage(string sender, string recipient, string subject) : base(sender, recipient)
    {        
      Subject = subject;
    }
}

class Email : ElectronicMessage
{
    public string Body { get; set; }
    
    public Email(string sender, string recipient, string subject, string body) : base(sender, recipient, subject)
    {
        Body = body;
    }
    
    public override void Protocol()
    {
        Console.WriteLine("Protocol: Email");
    }
}

class SMS : Message
{    public string Text { get; set; }

public SMS(string sender, string recipient, string text) : base(sender, recipient)    {
    Text = text;
}

public override void Protocol()
{
    Console.WriteLine("Protocol: SMS");
}
}

class Program
{
    static void Main(string[] args)
    {
        Message[] messages = new Message[]
        {
            new Email("sender@example.com", "recipient@example.com", "Hello", "This is an email message."),
            new SMS("1234567890", "0987654321", "This is an SMS message.")
        };
        
        
        foreach (var message in messages)
        {
            message.Protocol();
            Console.WriteLine($"Sender: {message.Sender}"); Console.WriteLine($"Recipient: {message.Recipient}");
            Console.WriteLine($"Timestamp: {message.Timestamp}");
            
            if (message is Email email)
            {
                Console.WriteLine($"Subject: {email.Subject}");
                Console.WriteLine($"Body: {email.Body}");
            }
            else if (message is SMS sms)
            {
                Console.WriteLine($"Text: {sms.Text}");
            }

            Console.WriteLine();
        }
    }
}