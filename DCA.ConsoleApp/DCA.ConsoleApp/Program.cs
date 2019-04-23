using DCA.DataAccess;
using DCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var reciversRepository = new ReciversRepository())
            using (var mailsRepository = new MailsRepository())
            {
                //var reciver = new Reciver
                //{
                //    FullName = "Askar",
                //    Adress = "Astana"
                //};

                //reciversRepository.Add(reciver);
                //var resultReciver = reciversRepository.GetAll();
                
                var i = 0;
                for (; i < reciversRepository.GetAll().ToList().Count; i++)
                {
                    Console.WriteLine($"{reciversRepository.GetAll().ToList()[i].FullName} - {i}"); 
                }
                Console.WriteLine("Выберете пользователя адресат:");
                i = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите тему письма");
                var theme = Console.ReadLine();

                Console.WriteLine("Введите текст письма");
                var text = Console.ReadLine();

                var mail = new Mail
                {
                    ReciverId = reciversRepository.GetAll().ToList()[i].Id,
                    Theme = theme,
                    Text = text
                };
                mailsRepository.Add(mail);
                var resultMail = mailsRepository.GetAll();
                
                reciversRepository.Delete(reciversRepository.GetAll().ToList()[i]);


            }

            Console.ReadLine();
        }
    }
}
