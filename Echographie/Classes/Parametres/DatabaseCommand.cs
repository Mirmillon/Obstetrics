using System.Windows.Input;

namespace Echographie.Classes.Parametres
{
    public class DatabaseCommand
    {
        private static RoutedUICommand sendDatabase;

        public static RoutedUICommand SendDatabase {get {return sendDatabase; }}

        static DatabaseCommand()
        {
            InputGestureCollection gestures = new InputGestureCollection();

            gestures.Add(new KeyGesture(Key.A, ModifierKeys.Control, "Control-A"));

            sendDatabase = new RoutedUICommand("Send database", "Send", typeof(DatabaseCommand), gestures);
        }
    }
}
