using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace DraftLotteryWpf.Common
{
    public class ItemContainerToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var container = value as ContentControl;
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
            return itemsControl != null ? itemsControl.Items.IndexOf(container.DataContext) + 1 : -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
