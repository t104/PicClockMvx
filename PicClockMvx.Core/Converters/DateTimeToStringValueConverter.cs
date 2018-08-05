using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace PicClockMvx.Core.Converters
{
    public class DateTimeToStringValueConverter
        : MvxValueConverter<DateTime, string>
    {
        public DateTimeToStringValueConverter()
        {
        }
		protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
		{
            var format = parameter as string;
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "yyyy/MM/dd";
            }
            return value.ToString(format);
		}

		protected override DateTime ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
		{
            var format = parameter as string;
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "yyyy/MM/dd";
            }
            DateTime dt;
            if (DateTime.TryParseExact(value, format, null,
                                       DateTimeStyles.None, out dt))
            {
                return dt;
            }
            throw new InvalidOperationException();
		}
	}
}
