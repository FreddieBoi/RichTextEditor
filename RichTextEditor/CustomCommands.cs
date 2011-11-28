using System.Windows.Input;

namespace RichTextEditor
{

    static class CustomCommands
    {
        public static RoutedCommand Open = new RoutedCommand();
        public static RoutedCommand Save = new RoutedCommand();
        public static RoutedCommand SaveAs = new RoutedCommand();
        public static RoutedCommand Print = new RoutedCommand();
    }

}
