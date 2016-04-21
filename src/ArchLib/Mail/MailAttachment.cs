using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ArchLib.Mail
{
    public class MailAttachment
    {
        public byte[] Bytes { get; set; }

        public string ShowName { get; set; }

        private byte[] FileToBytes(string fileName)
        {
            byte[] bytes = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
            }
            return bytes;
        }

        public MailAttachment(string filePath)
        {
            Bytes = FileToBytes(filePath);
            ShowName = System.IO.Path.GetFileName(filePath);
        }

        public MailAttachment(string filePath, string showName)
        {
            Bytes = FileToBytes(filePath);
            ShowName = GetRealShowName(showName);
        }

        /// <summary>
        /// 邮件附件因为是服务器上保存为文件，所有不能成为文件名的字符换成空格
        /// </summary>
        /// <param name="showName"></param>
        /// <returns></returns>
        public static string GetRealShowName(string showName)
        {
            return showName.Replace("/", " ").
               Replace("\\", " ").
               Replace(":", " ").
               Replace("?", " ").Replace("\"", " ").Replace("<", " ").Replace(">", " ").Replace("|", " ");
        }

    }

    public class MailAttachmentList
    {

        List<MailAttachment> attachmentList = new List<MailAttachment>();

        List<MailAttachment> AttachmentList { get { return attachmentList; } set { } }

        public void AddFile(string filePath)
        {
            MailAttachment m = new MailAttachment(filePath);
            AttachmentList.Add(m);
        }

        public void AddFile(string filePath, string showName)
        {
            MailAttachment m = new MailAttachment(filePath, showName);
            AttachmentList.Add(m);
        }

        public byte[][][] GetByteArray()
        {
            if (AttachmentList.Count == 0)
                return null;

            byte[][][] fi = new byte[AttachmentList.Count][][];
            for (int i = 0; i <= AttachmentList.Count - 1; i++)
            {
                fi[i] = new byte[2][];

                fi[i][0] = System.Text.Encoding.GetEncoding("GB2312").GetBytes(AttachmentList[i].ShowName);
                fi[i][1] = AttachmentList[i].Bytes;
            }
            return fi;
        }

    }
}
