namespace HelperClassesBJH
{
    using System;
    using Gtk;

    public class MessageBox
    {
        public static ResponseType Show(string msg, MessageType type = MessageType.Info, ButtonsType buttonsType = ButtonsType.Ok)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, type, buttonsType, msg);
            ResponseType userResponse = new ResponseType();
            md.Response += delegate (object o, ResponseArgs resp) 
            {
                    userResponse = resp.ResponseId;
            };

            ConsoleMessage.WriteLine(msg, type);
            md.Run();
            md.Destroy();
            return userResponse;
        }
    }

    public static class ConsoleMessage
    {
        /* METHODS */
        public static void WriteLine(string message, MessageType type = MessageType.Info)
        {
            DateTime dt = DateTime.Now;
            switch(type)
            {
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine(String.Format("{0:yyyy-MM-dd  HH:mm:ss.ff} | {1}", dt, message));
            MessageEventArgs e = new MessageEventArgs(dt, message, type);
            MessageOutput(null, e);
            Console.ResetColor();
        }
        /* EVENTS */
        public static event EventHandler<MessageEventArgs> MessageOutput = delegate {};

        /* CLASSES */

    }

    public class MessageEventArgs
    {
        public DateTime Dt { get; private set;}
        public string Message { get; private set;}
        public MessageType Type { get; private set;}

        /* CONSTRUCTORS */
        public MessageEventArgs()
        {

        }
        public MessageEventArgs(DateTime dt, string message, MessageType type)
        {
            Dt = dt;
            Message = message;
            Type = type;
        }
    }


}
