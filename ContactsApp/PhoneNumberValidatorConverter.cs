using System;
using System.Globalization;
using System.Windows.Data;

namespace ContactsApp
{
    public class PhoneNumberValidatorConverter : IValueConverter
    {
        // Convert để kiểm tra số điện thoại
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra nếu giá trị trống thì không thay đổi gì
            if (value == null || value.ToString().Length == 0)
            {
                return value; // Nếu chưa nhập gì, trả về giá trị ban đầu (rỗng)
            }

            // Nếu giá trị không đủ 10 chữ số, thay đổi thành "0000000000"
            if (value.ToString().Length != 10)
            {
                return "0000000000";
            }

            return value;  // Nếu đủ 10 chữ số, giữ nguyên giá trị
        }

        // Không cần thực hiện gì khi giá trị đi ngược lại
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}