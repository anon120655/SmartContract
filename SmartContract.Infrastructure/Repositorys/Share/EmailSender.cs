using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class EmailSender : IEmailSender
	{
		private readonly IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly AppSettings _mySet;
		private IHttpContextAccessor _httpContextAccessor;

		public EmailSender(IRepositoryWrapper repo, IRepositoryBase db, IOptions<AppSettings> settings
			, IHttpContextAccessor httpContextAccessor)
		{
			_db = db;
			_repo = repo;
			_mySet = settings.Value;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task SendEmail(ResourceEmail resource)
		{
			try
			{
				if (_mySet.EmailSetting.IsSentMail)
				{
					var _setting = _mySet.EmailSetting;
					resource.SenderName = _setting.SenderName;
					resource.Sender = _setting.Sender;
					resource.Password = _setting.Password;
					resource.MailServer = _setting.MailServer;
					resource.MailPort = _setting.MailPort;

					if (!String.IsNullOrEmpty(_mySet.EmailSetting.DefualtMail))
					{
						resource.Email = _mySet.EmailSetting.DefualtMail;
					}
					var mimeMessage = new MimeMessage();

					mimeMessage.Body = resource.Builder.ToMessageBody();
					mimeMessage.From.Add(new MailboxAddress(resource.SenderName, resource.Sender));
					mimeMessage.To.Add(new MailboxAddress(resource.Email));

					if (_mySet.ServerSite.ToUpper() != "PRO")
					{
						resource.Subject = $"({_mySet.ServerSite.ToUpper()}){resource.Subject}";
					}

					mimeMessage.Subject = resource.Subject;

					using (var client = new SmtpClient())
					{
						client.ServerCertificateValidationCallback = (s, c, h, e) => true;

						await client.ConnectAsync(resource.MailServer, resource.MailPort, false);

						//1.ถ้ามี sender pwd จะส่งไป auth ปกติ
						//2.ถ้ามี sender แต่ไม่มี pwd จะส่งไป auth ปกติ แต่จะไม่ส่ง pwd ไป
						//3.ถ้าไม่มี sender ไม่มี pwd จะไม่ส่งไป auth เลย
						if (!String.IsNullOrEmpty(resource.UserName) && !String.IsNullOrEmpty(resource.Password) ||
							!String.IsNullOrEmpty(resource.UserName) && String.IsNullOrEmpty(resource.Password))
						{
							await client.AuthenticateAsync(resource.UserName, resource.Password);
						}

						await client.SendAsync(mimeMessage);
						await client.DisconnectAsync(true);

						resource.IsCompleted = true;
						resource.StatusMessage = "OK";
						await this.LogSendEmail(resource);
					}
				}
			}
			catch (Exception ex)
			{
				resource.IsCompleted = false;
				resource.StatusMessage = GeneralUtils.GetExMessage(ex);
				await this.LogSendEmail(resource);
			}
		}

		public async Task LogSendEmail(ResourceEmail resource)
		{
			LogSendmail logSendmail = new LogSendmail()
			{
				CreateUser = _repo.UserService.GetIdUserSmct(),
				CreateDate = DateTime.Now,
				Template = resource.Template,
				Emailto = resource.Email,
				Subject = resource.Subject,
				Message = resource.Message,
				IsCompleted = resource.IsCompleted,
				StatusMessage = resource.StatusMessage,
				PkId = resource.PkId,
				RefId = resource.RefId,
			};
			await _db.InsterAsync(logSendmail);
			await _db.SaveAsync();

		}

	}
}
