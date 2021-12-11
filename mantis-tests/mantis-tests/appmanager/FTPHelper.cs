using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FTPHelper : HelperBase
    {
        private FtpClient client;
        public FTPHelper(ApplicationManager manager) : base(manager) 
        {
            client = new FtpClient();
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackupFile(String path)
        { 
            
        }

        public void RestoreBackupFile(String path)
        { 
            
        }

        public void Upload(String path, Stream localFile)
        { 
            
        }
    }
}
