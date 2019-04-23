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
                //    FullName = "Vasya",
                //    Adress = "Astana"
                //};

                //reciversRepository.Add(reciver);
                //var resultReciver = reciversRepository.GetAll();

                //var mail = new Mail
                //{
                //    ReciverId = resultReciver.ToList()[0].Id,
                //    Theme = "Che tam?",
                //    Text = "Kogda domashki zakroesh?"
                //};
                //mailsRepository.Add(mail);
                //var resultMail = mailsRepository.GetAll();

                reciversRepository.Delete(reciversRepository.GetAll().ToList()[0]);
            }
        }
    }
}
