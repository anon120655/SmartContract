using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
    public class UploadFiles : IUploadFiles
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;

        public UploadFiles(IRepositoryWrapper repo, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _mySet = settings.Value;
        }

        public async Task SaveFile(UploadFilesResource resource)
        {
            resource.SubDirectory = resource.SubDirectory ?? string.Empty;
            var target = Path.Combine($"{resource.ContentRootPath}\\", resource.SubDirectory);

            this.CreateDirectory(target);
            var fullTarget = target;

            foreach (var item in resource.Files)
            {
                if (item.Length <= 0) return;
                var filePath = Path.Combine(fullTarget, resource.FileNameServer);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
            }
        }

        public string GenFileName(IFormFile str, String id, string nametype)
        {
            if (str == null) return null;
            string filename = $"{id.ToString().ToUpperInvariant()}_{nametype}{Path.GetExtension(str.FileName)}";
            return filename;
        }

        private string CreateDirectory(string filefullpath)
        {
            //string Month = Convert.ToInt32(DateTime.Now.Month.ToString()) < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            //string Year = DateTime.Now.Year.ToString();
            //filefullpath = filefullpath + GetPathFolder();
            FileInfo fileInfo = new FileInfo(filefullpath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            return filefullpath;
        }

        public string GetPathFolder()
        {
            string Month = Convert.ToInt32(DateTime.Now.Month.ToString()) < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            string Year = DateTime.Now.Year.ToString();
            string Type = @"\";
            string folderpath = Year + Type + Month + Type;

            return folderpath;
        }

        public string GetMimeType(string file)
        {
            string extension = Path.GetExtension(file).ToLowerInvariant();
            switch (extension)
            {
                case ".txt": return "text/plain";
                case ".pdf": return "application/pdf";
                case ".doc": return "application/vnd.ms-word";
                case ".docx": return "application/vnd.ms-word";
                case ".xls": return "application/vnd.ms-excel";
                case ".xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".png": return "image/png";
                case ".jpg": return "image/jpeg";
                case ".jpeg": return "image/jpeg";
                case ".gif": return "image/gif";
                case ".csv": return "text/csv";
                default: return "";
            }
        }

        public async Task<UploadFilesServer> GetUploadFile(Guid UploadFileId)
        {
            return new UploadFilesServer();
        }

        public void FTPMakeDirectory(string folderName)
        {
            String PathFolder = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{folderName}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFolder);
            request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                Console.Write(response.StatusCode);
            }
        }

        public void FTPSaveFile(IFormFile FormFile, String fileFTP, String folderName)
        {
            String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{folderName}//{fileFTP}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
            request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (Stream ftpStream = request.GetRequestStream())
            {
                FormFile.CopyTo(ftpStream);
            }
        }

    }
}
