using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Winnovative;

namespace SmartContract.Web.Controllers
{
    public class FilesController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IWebHostEnvironment _env;

        public FilesController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
            _mySet = settings.Value;
        }

        public ActionResult OpenIMG(String PathFolder, String FileFtp)
        {
            try
            {
                String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{PathFolder}//{FileFtp}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                return new FileStreamResult(responseStream, "image/png");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IActionResult Render(string fileftp, string type)
        {
            try
            {
                if (string.IsNullOrEmpty(fileftp))
                    return RedirectToAction("SystemNoti", "Authorize", new { message = "File not found." });

                //String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//T01//2564//TEST_FTP.pdf";
                String SubFolder = type.Replace("\\", "//");
                String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{SubFolder}//{fileftp}";


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                return new FileStreamResult(responseStream, "application/pdf");



                //return File(memory, mimeType, fileftp);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = ex.Message });
            }
        }

        public async Task<IActionResult> RenderPdf(ParameterCondition indata, String fmtype = null, bool? download = null)
        {
            String url = String.Empty;
            try
            {
                HtmlToPdfConverter htmlToPdfConverter = null;
                htmlToPdfConverter = new HtmlToPdfConverter(793);

                //htmlToPdfConverter.LicenseKey = "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og=";

                htmlToPdfConverter.PdfDocumentOptions.ShowHeader = true;
                htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;
                htmlToPdfConverter.PdfHeaderOptions.HeaderHeight = 20;

                byte[] outPdfBuffer = null;

                //var DomainName = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                url = $"{_mySet.SubDomainServer}";

                url += $"/FM/{fmtype}?IsPDF=true";
                if (!String.IsNullOrEmpty(indata.VendorIdCurr))
                    url = $"{url}&VendorIdCurr={indata.VendorIdCurr}";
                if (!String.IsNullOrEmpty(indata.DepartmentCodeCurr))
                    url = $"{url}&DepartmentCodeCurr={indata.DepartmentCodeCurr}";
                if (!String.IsNullOrEmpty(indata.Style))
                    url = $"{url}&Style={indata.Style}";
                if (!String.IsNullOrEmpty(indata.Station))
                    url = $"{url}&Station={indata.Station}";
                if (!String.IsNullOrEmpty(indata.StationReq))
                    url = $"{url}&StationReq={indata.StationReq}";
                if (!String.IsNullOrEmpty(indata.IdSmctMaster))
                    url = $"{url}&IdSmctMaster={indata.IdSmctMaster}";
                if (!String.IsNullOrEmpty(indata.SigningTypeEn))
                    url = $"{url}&SigningTypeEn={indata.SigningTypeEn}";
                if (!String.IsNullOrEmpty(indata.Menu) && indata.Menu != "null")
                    url = $"{url}&Menu={indata.Menu}";
                if (!String.IsNullOrEmpty(indata.MenuEn) && indata.MenuEn != "null")
                    url = $"{url}&MenuEn={indata.MenuEn}";

                url = $"{url}&ContractTypeId={indata.ContractTypeId}";
                url = $"{url}&ContractTypeIdEn={SecurityRepo.Encrypt(indata.ContractTypeId)}";

                // Enable footer in the generated PDF document
                htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;

                // Draw footer elements
                if (htmlToPdfConverter.PdfDocumentOptions.ShowFooter)
                    DrawFooter(htmlToPdfConverter, indata, fmtype, true, false);

                outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

                //Send the PDF file to browser
                FileResult fileResult = new FileContentResult(outPdfBuffer, "application/pdf");

                //String _SigningType = String.Empty;
                //if (!String.IsNullOrEmpty(indata.SigningTypeEn))
                //    _SigningType = SecurityRepo.Decrypt(indata.SigningTypeEn);

                //CA หนังสือขออนุมัติ
                if (fmtype.StartsWith("FM_APPROVAL") && outPdfBuffer.Length > 0 && indata.UserNameCA != null && indata.PasswordCA != null)
                {
                    String _UserNameCA = indata.UserNameCA;
                    String _PasswordCA = indata.PasswordCA;

                    if (indata.PasswordCA == "8888" || indata.PasswordCA == "9999")
                    {
                        var CAModels = _repo.GeneralRepo.GetAuthCAFix(indata.PasswordCA);
                        _UserNameCA = CAModels.UserNameCA;
                        _PasswordCA = CAModels.PasswordCA;
                    }

                    var responseApi = await _repo.SoapService.authenAndUserInfoAsync(new ServiceIAMAuthentication.authenWSRequest()
                    {
                        domainName = _mySet.IAMs.domainName,
                        userName = _UserNameCA,
                        password = _PasswordCA
                    });
                    if (responseApi != null && responseApi.@return.message == "OK")
                    {
                        outPdfBuffer = await _repo.ContractShareNhso.PDFCAFile(outPdfBuffer, responseApi.@return.userInfo.info, null, null, 1);
                    }
                }


                await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);

                if (download.HasValue && download.Value)
                {
                    fileResult.FileDownloadName = "Print.pdf";
                }

                return Json(new ResultModelJson<String>
                {
                    Status = true,
                    Result = $"Render Success {fmtype}",
                    MessagDetail = url
                });
                //return fileResult;
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    MessagError = GeneralUtils.GetExMessage(ex),
                    MessagDetail = url
                });
            }
        }

        private void DrawFooter(HtmlToPdfConverter htmlToPdfConverter, ParameterCondition indata, String fmtype, bool addPageNumbers, bool drawFooterLine)
        {

            if (fmtype != "FM_APPROVAL_REQ")
            {
                var url = $"{_mySet.SubDomainServer}/FM";
                url = $"{url}/Footer?IsPDF=true";

                if (!String.IsNullOrEmpty(indata.VendorIdCurr))
                    url = $"{url}&VendorIdCurr={indata.VendorIdCurr}";
                if (!String.IsNullOrEmpty(indata.DepartmentCodeCurr))
                    url = $"{url}&DepartmentCodeCurr={indata.DepartmentCodeCurr}";
                if (!String.IsNullOrEmpty(indata.Style))
                    url = $"{url}&Style={indata.Style}";
                if (!String.IsNullOrEmpty(indata.Station))
                    url = $"{url}&Station={indata.Station}";
                if (!String.IsNullOrEmpty(indata.StationReq))
                    url = $"{url}&StationReq={indata.StationReq}";
                if (!String.IsNullOrEmpty(indata.IdSmctMaster))
                    url = $"{url}&IdSmctMaster={indata.IdSmctMaster}";
                if (!String.IsNullOrEmpty(indata.SigningTypeEn))
                    url = $"{url}&SigningTypeEn={indata.SigningTypeEn}";

                url = $"{url}&ContractTypeId={indata.ContractTypeId}";
                url = $"{url}&ContractTypeIdEn={SecurityRepo.Encrypt(indata.ContractTypeId)}";

                htmlToPdfConverter.PdfFooterOptions.FooterHeight = 85;
                htmlToPdfConverter.PdfFooterOptions.FooterBackColor = Color.White;
                HtmlToPdfElement footerHtml = new HtmlToPdfElement(url);
                footerHtml.FitHeight = true;
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerHtml);
            }

            // Add page numbering
            if (addPageNumbers)
            {
                TextElement footerText = new TextElement(530, 55, 1000, 10,
                    "ฉบับที่ 05", new System.Drawing.Font(new System.Drawing.FontFamily("AngsanaUPC"), 10, System.Drawing.GraphicsUnit.Point), Color.White);

                footerText.ForeColor = Color.Black;
                footerText.EmbedSysFont = true;
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerText);

                String _FM = String.Empty;
                /// _Space ใช้กับ FM ที่มีไม่ถึง 10 หน้า
                String _Space = String.Empty;
                if (indata.ContractTypeId == "01")
                {
                    _FM = "FM-403 02 001";
                }
                else if (indata.ContractTypeId == "11")
                {
                    _FM = "FM-403 00 008";
                    _Space = " ";
                }

                TextElement footerText2 = new TextElement(41, 65, 1000, 50,
                    $"{_FM}{_Space}                                                                                                                       " +
                    $"หน้า &p; / &P;{_Space}                                                                                                                      " +
                    "วันที่ 5 มีนาคม 2564", new System.Drawing.Font(new System.Drawing.FontFamily("AngsanaUPC"), 10, System.Drawing.GraphicsUnit.Point), Color.White);

                footerText2.ForeColor = Color.Black;
                footerText2.EmbedSysFont = true;
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerText2);
            }

            if (drawFooterLine)
            {
                float footerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
                            htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;
                LineElement footerLine = new LineElement(0, 0, footerWidth, 0);
                footerLine.ForeColor = Color.Gray;
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerLine);
            }
        }

        public IActionResult PrintTest()
        {
            return View();
        }

        public async Task<IActionResult> FileFTPCA(ParameterCondition indata)
        {
            try
            {
                String _UserNameCA = indata.UserNameCA;
                String _PasswordCA = indata.PasswordCA;

                if (indata.PasswordCA == "8888" || indata.PasswordCA == "9999")
                {
                    var CAModels = _repo.GeneralRepo.GetAuthCAFix(indata.PasswordCA);
                    _UserNameCA = CAModels.UserNameCA;
                    _PasswordCA = CAModels.PasswordCA;
                }

                var responseApi = await _repo.SoapService.authenAndUserInfoAsync(new ServiceIAMAuthentication.authenWSRequest()
                {
                    domainName = _mySet.IAMs.domainName,
                    userName = _UserNameCA,
                    password = _PasswordCA
                });
                if (responseApi != null && responseApi.@return.message == "OK")
                {
                    var SmctMasterFile = _repo.Context.SmctMasterFiles.Where(x => x.IdSmctMaster == indata.IdSmctMaster && x.Used);
                    //หนังสืออนุมัติ------------------------------------------------------------
                    var _FileReq = SmctMasterFile.FirstOrDefault(x => x.FileType == "F10");
                    if (_FileReq != null)
                    {
                        String pathFolder = $"FM/FM_APPROVAL_REQ/{_FileReq.PathFolder}";
                        String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{pathFolder}//{_FileReq.FileFtp}";
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;
                        request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        byte[] outPdfBuffer = null;
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                reader.BaseStream.CopyTo(ms);
                                outPdfBuffer = ms.ToArray();
                                outPdfBuffer = await _repo.ContractShareNhso.PDFCAFile(outPdfBuffer, responseApi.@return.userInfo.info, null, null, 1);

                                //CA ไฟล์จาก FTP และ Upload ไฟล์ไปที่ FTP
                                MemoryStream stream = new MemoryStream(outPdfBuffer);
                                IFormFile file = new FormFile(stream, 0, outPdfBuffer.Length, "FM_APPROVAL_REQ", "FM_APPROVAL_REQ.pdf");
                                _repo.UploadFiles.FTPSaveFile(file, _FileReq.FileFtp, pathFolder);
                            }
                        }
                    }

                    //นิติกรรมสัญญา----------------------------------------------------------

                    String MainFolder = "Attach/T";
                    String _FileType = "F3";
                    if (indata.SigningType == SigningTypes.Electronic) //ลงนามจริงในเอกสาร
                    {
                        MainFolder = "FM/FM_CONTRACT_T";
                        _FileType = "F11";
                    }

                    //_FileType
                    //F3 ไฟล์แสกนนิติกรรมสัญญา
                    //F11 ไฟล์นิติกรรมสัญญา
                    var _FileContract = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == indata.IdSmctMaster && x.Used && x.FileType == _FileType);
                    if (_FileContract != null)
                    {
                        String pathFolder = $"{MainFolder}{indata.ContractTypeId}/{_FileContract.PathFolder}";
                        String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{pathFolder}//{_FileContract.FileFtp}";
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;
                        request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        byte[] outPdfBuffer = null;
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                String _SignImage = responseApi.@return.userInfo.signImage;
                                if (indata.SigningType == SigningTypes.Paper) _SignImage = null;

                                reader.BaseStream.CopyTo(ms);
                                outPdfBuffer = ms.ToArray();
                                //String PathFileTemp = $@"{_env.ContentRootPath}\‪‪Tempfiles\files\FM\FM_CONTRACT_T{indata.ContractTypeId}\{_File.FileFtp}";
                                string PathFileTemp = Path.Combine($"{_env.WebRootPath}\\", $"files\\Tempfiles\\FM\\FM_CONTRACT_T{indata.ContractTypeId}\\{_FileContract.FileFtp}");
                                if (indata.SigningType == SigningTypes.Electronic)
                                {
                                    System.IO.File.WriteAllBytes(PathFileTemp, outPdfBuffer);
                                }

                                int pdfPageCount = 1;
                                if (indata.SigningType == SigningTypes.Electronic) pdfPageCount = System.IO.File.ReadAllText(PathFileTemp).Split(new string[] { "/Type /Page" }, StringSplitOptions.None).Count() - 2;
                                outPdfBuffer = await _repo.ContractShareNhso.PDFCAFile(outPdfBuffer, responseApi.@return.userInfo.info, _SignImage, indata.SendmailType, pdfPageCount);
                                System.IO.File.Delete(PathFileTemp);

                                //CA ไฟล์จาก FTP และ Upload ไฟล์ไปที่ FTP
                                MemoryStream stream = new MemoryStream(outPdfBuffer);
                                IFormFile file = new FormFile(stream, 0, outPdfBuffer.Length, "FM_CONTRACT", "FM_CONTRACT.pdf");
                                _repo.UploadFiles.FTPSaveFile(file, _FileContract.FileFtp, pathFolder);
                            }
                        }

                    }

                    //เงื่อนไขการจ่ายเงิน
                    var _FilePay = SmctMasterFile.FirstOrDefault(x => x.FileType == "F12");
                    if (_FilePay != null)
                    {
                        String pathFolder = $"FM/FM_PAY_{indata.PeriodType}/{_FilePay.PathFolder}";
                        String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{pathFolder}//{_FilePay.FileFtp}";
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;
                        request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        byte[] outPdfBuffer = null;
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                reader.BaseStream.CopyTo(ms);
                                outPdfBuffer = ms.ToArray();
                                outPdfBuffer = await _repo.ContractShareNhso.PDFCAFile(outPdfBuffer, responseApi.@return.userInfo.info, null, null, 1);

                                //CA ไฟล์จาก FTP และ Upload ไฟล์ไปที่ FTP
                                MemoryStream stream = new MemoryStream(outPdfBuffer);
                                IFormFile file = new FormFile(stream, 0, outPdfBuffer.Length, "FM_PAY", "FM_PAY.pdf");
                                _repo.UploadFiles.FTPSaveFile(file, _FilePay.FileFtp, pathFolder);
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception($"iAMWS : {responseApi.@return.message} ");
                }

                return Json(new ResultModelJson<String>
                {
                    Status = true,
                    Result = $"Real CA Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }


    }
}
