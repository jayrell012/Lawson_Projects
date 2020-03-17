using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VSBO_Item_List_Generator.SQL
{
    class FTPCon
    {
        public void FTP(string server, string fileName, string userName, string password, string fullName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", server, fileName)));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);


            Stream ftpStream = request.GetRequestStream();
            FileStream fs = File.OpenRead(fullName);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            double read = 0;
            do
            {
                byteRead = fs.Read(buffer, 0, 1024);
                ftpStream.Write(buffer, 0, byteRead);
                read += (double)byteRead;
                double percentage = read / total * 100;
            } while (byteRead != 0);
            fs.Close();
            ftpStream.Close();
        }

        public bool FTPConnectionCheck(string hostFolder, string userName, string password)
        {
            try
            {
                FtpWebRequest myFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(hostFolder));
                myFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                myFTP.Credentials = new NetworkCredential(userName, password);
                WebResponse response = myFTP.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
