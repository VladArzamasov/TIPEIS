using AmortizationOSBusinessLogic.BindingModels;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class MailLogic
    {
        public MailLogic()
        {
        }

        public void sendMailTurnoverBalance()
        {
            SmtpClient client = CreateClient();
            string basis = "Оборотно-сальдовая ведомость";

            MailMessage message = CreateMsg(basis, "emailforlab7@gmail.com");

            string path = "D:\\Отчеты\\Оборотно-сальдовая ведомость.pdf";
            Attachment attach = CreateAtt(path);

            message.Attachments.Add(attach);

            client.Send(message);
        }
        public void sendMailStatementDepreciationCalculation()
        {
            SmtpClient client = CreateClient();
            string basis = "Ведомость расчета износа";

            MailMessage message = CreateMsg(basis, "emailforlab7@gmail.com");

            string path = "D:\\Отчеты\\Ведомость расчета износа.pdf";
            Attachment attach = CreateAtt(path);

            message.Attachments.Add(attach);

            client.Send(message);
        }
        public void sendMailStatementDepreciationDistribution()
        {
            SmtpClient client = CreateClient();
            string basis = "Ведомость распределения износа по счетам затрат";

            MailMessage message = CreateMsg(basis, "emailforlab7@gmail.com");

            string path = "D:\\Отчеты\\Ведомость распределения износа по счетам затрат.pdf";
            Attachment attach = CreateAtt(path);

            message.Attachments.Add(attach);

            client.Send(message);
        }
        private MailMessage CreateMsg(string info, string address)
        {
            MailMessage msg = new MailMessage();

            msg.Subject = info;
            msg.Body = info;
            msg.From = new MailAddress("emailforlab7@gmail.com");
            msg.To.Add(address);
            msg.IsBodyHtml = true;

            return msg;
        }

        private Attachment CreateAtt(string path)
        {
            Attachment attach = new Attachment(path, MediaTypeNames.Application.Octet);

            ContentDisposition disposition = attach.ContentDisposition;

            disposition.CreationDate = System.IO.File.GetCreationTime(path);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(path);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(path);

            return attach;
        }

        private SmtpClient CreateClient()
        {
            SmtpClient client = new SmtpClient();

            client.Host = "smtp.gmail.com";
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("emailforlab7@gmail.com", "9fG-BWP-Geq-fcr");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;
        }
    }
}
