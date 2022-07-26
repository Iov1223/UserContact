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
            }
            Console.WriteLine(text + ContactInfo[num]);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* ContactINFO _contact = new ContactINFO();
             string RE_email = @"\w*@\w*[.]\w*";
             string text = "1) Логин в системе: ";
             _contact.SortArgs(args, RE_email, 2, text);
             string RE_ip = @"\w*[.]\w*[.]\w*[.]\w*";
             text = "2) IP-адрес: ";
             _contact.SortArgs(args, RE_ip, 1, text);
             string RE_date = @"\w*[.]\w*[.]\w*";
             text = "3) Адрес эл.почты: ";
             _contact.SortArgs(args, RE_date, 3, text);
             string RE_name = @"\'";
             text = "4) Дата заключения договора: ";
             _contact.SortArgs(args, RE_name, 0, text);*/
            string[] ContactInfo = new string[4];

            string RE_email = @"\w*@\w*[.]\w*";
            Regex regex = new Regex(RE_email, RegexOptions.IgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                MatchCollection matches = regex.Matches(args[i]);
                if (matches.Count > 0)
                {
                    ContactInfo[2] = args[i];
                }
            }
            string RE_ip = @"\w*[.]\w*[.]\w*[.]\w*";
            regex = new Regex(RE_ip, RegexOptions.IgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                MatchCollection matches = regex.Matches(args[i]);
                if (matches.Count > 0)
                {
                    ContactInfo[1] = args[i];
                }
            }
            string RE_date = @"\w*[.]\w*[.]\w*";
            regex = new Regex(RE_date, RegexOptions.IgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                MatchCollection matches = regex.Matches(args[i]);
                if (matches.Count > 0)
                {
                    ContactInfo[3] = args[i];
                }
            }
            string RE_name = @"\'";
            regex = new Regex(RE_name, RegexOptions.IgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                MatchCollection matches = regex.Matches(args[i]);
                if (matches.Count > 0)
                {
                    ContactInfo[0] = args[i];
                }
            }
            Console.WriteLine("{0}) Логин в системе: {1}", 1, ContactInfo[0]);
            Console.WriteLine("{0}) IP-адрес: {1}", 2, ContactInfo[1]);
            Console.WriteLine("{0}) Адрес эл.почты: {1}", 3, ContactInfo[2]);
            Console.WriteLine("{0}) Дата заключения договора: {1}", 4, ContactInfo[3]);
        }
    }
}
