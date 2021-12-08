using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_UWP.ViewModels.Utilidades.Converters
{
    public class converterDateTimeOffset : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value ;

            return (DateTimeOffset)date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {    
            var date = (DateTimeOffset)value;
            return date.DateTime;
        }
    }
}
