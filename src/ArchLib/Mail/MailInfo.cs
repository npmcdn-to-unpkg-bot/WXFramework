using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchLib.Mail
{
    public class MailInfo
    {
        public MailInfo()
        {
            AttachmentList = new MailAttachmentList();
        }



        public string Subject { get; set; }

        public string Body { get; set; }

        public string MailTo { get; set; }

        public string CC { get; set; }

        public string BCC { get; set; }

        public MailAttachmentList AttachmentList { get; set; }
    }
}
