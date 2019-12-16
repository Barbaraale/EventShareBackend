using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace EventShareBackend_master.Controllers
{
    
    public class EnviarEvnetoApr : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult EnviaEmail()
        {
			string emailDestinatario = Request.Form["txtEmail"];
			SendMail(emailDestinatario);
            return RedirectToAction("Home");
        }

        public bool SendMail(string email)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("tictech1.info@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Teste Para Event";
                _mailMessage.IsBodyHtml = true;
				_mailMessage.Body = "<p>Veja essa imagem</p> <br/><br/><img src='https://i.imgur.com/7CdeQzC.png'>";
                _mailMessage.Body = "<p>Veja essa imagem</p> <br/><br/><img src='https://i.imgur.com/4RswGot.png'>";

				 //CONFIGURAÇÃO COM PORTA
				SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("tictech1.info@gmail.com", "tictechsala14");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}