using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace UserContact
{
    public class ContactINFO 
    {
        private string[] ContactInfo = new string[4];
        public void SortArgs(string[] args, string reg, int num, string text)
        {
            Regex regex = new Regex(reg, RegexOptions.IgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                MatchCollection matches = regex.Matches(args[i]);
                if (matches.Count > 0)
                {
                    ContactInfo[num] = args[i];
                }
                /* Не могу понять, почему без закомментированной части всё работает, стоит только раскомментировать
                 * и ввести один из аргументов неправильно - работает некорректно
                 * (логин вводится в одинарных кавычках: 'iov1223')
                else
                {
                    ContactInfo[num] = "Неверный ввод данных.";
                }*/
            }
            Console.WriteLine(text + ContactInfo[num]);
        }
        public void IfEmptyArgs()
        {
            Console.WriteLine("Введите данные пользователя (IP-адрес, электронная почта, дата регистрации, имя в сети) в произвольном порядке:");
            for (int i = 0; i < ContactInfo.Length; i++)
            {
                ContactInfo[i] = Console.ReadLine();
            }
            ContactINFO _contact = new ContactINFO();

            string text = "1) Логин в системе: ";
            var regex_NAME = @"\'";
            _contact.SortArgs(ContactInfo, regex_NAME, 0, text);

            text = "2) IP-адрес: ";
            var regex_IP = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
            _contact.SortArgs(ContactInfo, regex_IP, 1, text);

            text = "3) Адрес эл.почты: ";
            var regex_EMAIL = @"(\w*@\w*[.]\w*)|(\w*[.]\w*@\w*[.]\w*)";
            _contact.SortArgs(ContactInfo, regex_EMAIL, 2, text);

            text = "4) Дата заключения договора: ";
            var regex_DATE = @"(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}";
            _contact.SortArgs(ContactInfo, regex_DATE, 3, text);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        { 
            ContactINFO _contact = new ContactINFO();
            if (args.Length == 4)
            {
                string text = "1) Логин в системе: ";
                var regex_NAME = @"\'";
                _contact.SortArgs(args, regex_NAME, 0, text);

                text = "2) IP-адрес: ";
                var regex_IP = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
                _contact.SortArgs(args, regex_IP, 1, text);

                text = "3) Адрес эл.почты: ";
                var regex_EMAIL = @"(\w*@\w*[.]\w*)|(\w*[.]\w*@\w*[.]\w*)";
                _contact.SortArgs(args, regex_EMAIL, 2, text);

                text = "4) Дата заключения договора: ";
                var regex_DATE = @"(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}";
                _contact.SortArgs(args, regex_DATE, 3, text);
            }
            else
            {
                _contact.IfEmptyArgs();
            }
          
        }
    }
}
