using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface IUploadFiles
    {
        Task SaveFile(UploadFilesResource resource);
        string GetPathFolder();
        string GenFileName(IFormFile str, String id, string nametype);
        string GetMimeType(string file);
        Task<UploadFilesServer> GetUploadFile(Guid UploadFileId);

        void FTPMakeDirectory(String folderName);
        void FTPSaveFile(IFormFile FormFile, String fileFTP, String folderName);

    }
}
