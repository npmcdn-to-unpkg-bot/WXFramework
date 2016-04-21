using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using ArchLib.MailWebService;
using ArchLib.Mail;
using ArchLib.App;


namespace ArchLib
{
    public class MailSender
    {

        public void SendMail(MailInfo mailInfo)
        {
            SendMail(mailInfo.MailTo, mailInfo.CC, mailInfo.Subject, mailInfo.Body, mailInfo.AttachmentList.GetByteArray());
        }

        public static void SendMail(string toMail, string cc, string subject, string body, byte[][][] attachment)
        {
            MailCenterSoapClient m = new MailCenterSoapClient();
            string msg = "";
            m.sendMail("", toMail, cc, "", subject, body, attachment, SystemInfo.WebAppName, out msg);
            if (!string.IsNullOrEmpty(msg))
                throw new ApplicationException(string.Format("邮件发送错误:{0}",msg));
        }
      
    }
}
