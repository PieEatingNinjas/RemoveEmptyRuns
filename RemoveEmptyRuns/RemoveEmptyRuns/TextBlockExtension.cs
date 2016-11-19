using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace RemoveEmptyRuns
{
    public class TextBlockExtension
    {
        public static bool GetRemoveEmptyRuns(DependencyObject obj)
        {
            return (bool)obj.GetValue(RemoveEmptyRunsProperty);
        }

        public static void SetRemoveEmptyRuns(DependencyObject obj, bool value)
        {
            obj.SetValue(RemoveEmptyRunsProperty, value);

            if (value)
            {
                var tb = obj as TextBlock;
                if (tb != null)
                {
                    tb.Loaded += Tb_Loaded;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }

        public static readonly DependencyProperty RemoveEmptyRunsProperty =
            DependencyProperty.RegisterAttached("RemoveEmptyRuns", typeof(bool), 
                typeof(TextBlock), new PropertyMetadata(false));



        public static bool GetPreserveSpace(DependencyObject obj)
        {
            return (bool)obj.GetValue(PreserveSpaceProperty);
        }

        public static void SetPreserveSpace(DependencyObject obj, bool value)
        {
            obj.SetValue(PreserveSpaceProperty, value);
        }

        public static readonly DependencyProperty PreserveSpaceProperty =
            DependencyProperty.RegisterAttached("PreserveSpace", typeof(bool), 
                typeof(Run), new PropertyMetadata(false));


        private static void Tb_Loaded(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBlock;
            tb.Loaded -= Tb_Loaded;

           var spaces = tb.Inlines.Where(a => a is Run 
                && string.IsNullOrWhiteSpace(((Run)a).Text) 
                && !GetPreserveSpace(a)).ToList();
            spaces.ForEach(s => tb.Inlines.Remove(s));
        }
    }
}
