using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
	public class SqlCommandController : Controller
	{
		private readonly IConfiguration configuration;
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly AppSettings _mySet;

		public SqlCommandController(IRepositoryWrapper repo
			, IRepositoryBase db
			, IMapper mapper
			, IOptions<AppSettings> settings
			, IConfiguration config)
		{
			_repo = repo;
			_db = db;
			_mapper = mapper;
			_mySet = settings.Value;
			configuration = config;
		}

		public IActionResult SqlView()
		{
			var appSettingsSection = configuration.GetConnectionString("smartContractContext");

			return View(new CommandMain() { ConnectionString = appSettingsSection });
		}

		[HttpPost]
		public IActionResult SqlView(CommandMain indata)
		{
			try
			{
				var connectionString = configuration.GetConnectionString("smartContractContext");

				string constr = connectionString;
				OracleConnection con = new OracleConnection(constr);
				con.Open();

				OracleCommand cmd = new OracleCommand(indata.StringSql, con);

				OracleDataReader reader = cmd.ExecuteReader();
				indata.ResponseMessage = SqlDatoToJson(reader);
				reader.Close();

				// Clean up
				cmd.Dispose();
				con.Dispose();

				return View(indata);
			}
			catch (Exception ex)
			{
				return View(new CommandMain()
				{
					StringSql = indata.StringSql,
					ErrorMessage = GeneralUtils.GetExMessage(ex)
				});
			}

		}

		public IActionResult SqlCreateUpdate()
		{
			return View(new CommandMain());
		}

		[HttpPost]
		public IActionResult SqlCreateUpdate(CommandMain indata)
		{
			try
			{
				var connectionString = configuration.GetConnectionString("smartContractContext");

				string constr = connectionString;
				OracleConnection con = new OracleConnection(constr);
				con.Open();

				OracleCommand cmd = new OracleCommand(indata.StringSql, con);

				indata.rowsUpdated = cmd.ExecuteNonQuery();

				// Clean up
				cmd.Dispose();
				con.Dispose();

				return View(indata);
			}
			catch (Exception ex)
			{
				return View(new CommandMain()
				{
					StringSql = indata.StringSql,
					ErrorMessage = GeneralUtils.GetExMessage(ex)
				});
			}

		}

		private String SqlDatoToJson(OracleDataReader dataReader)
		{
			var dataTable = new DataTable();
			dataTable.Load(dataReader);
			string JSONString = string.Empty;
			JSONString = JsonConvert.SerializeObject(dataTable);
			return JSONString;
		}

	}
}
