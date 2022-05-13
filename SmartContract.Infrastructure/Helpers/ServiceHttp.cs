using RestSharp;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Helpers
{
    public static class ServiceHttp
    {
        public static async Task<string> CallHttpGet(string url, string token = null)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;

                var request = new RestRequest(Method.GET);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                request.AddHeader("Content-Type", "application/json");

                if (!string.IsNullOrWhiteSpace(token))
                {
                    var _authHeader = new AuthenticationHeaderValue("Bearer", token);
                    request.AddHeader("Authorization", $"{_authHeader.Scheme} {_authHeader.Parameter}");
                }

                IRestResponse responseClient = await client.ExecuteAsync(request);

                if (responseClient.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return responseClient.Content;
                }

                throw new Exception($"StatusCode : {responseClient.StatusCode} Error : { responseClient.ErrorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(GeneralUtils.GetExMessage(ex));
            }
        }

        public static async Task<string> CallHttpPost(
            string jsonTxt
            , string url
            , string token = null
            , string scope = null
            , List<ParameterHttp> parameterList = null
            , string contenttype = null
            , bool IsBasic = false)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;

                var request = new RestRequest(Method.POST);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                if (!String.IsNullOrEmpty(contenttype))
                {
                    request.AddHeader("Content-Type", contenttype);
                }
                else
                {
                    request.AddHeader("Content-Type", "application/json");
                }
                //request.AddHeader("Authorization", $"{_authHeader.Scheme} {_authHeader.Parameter}");
                if (!String.IsNullOrEmpty(jsonTxt))
                {
                    request.AddParameter("application/json,application/json", jsonTxt, ParameterType.RequestBody);
                }

                if (parameterList != null && parameterList.Count > 0)
                {
                    foreach (var item in parameterList)
                    {
                        request.AddParameter(item.name, item.value);
                    }
                }

                if (!string.IsNullOrEmpty(scope))
                {
                    request.AddHeader("scopes", scope);
                }

                if (IsBasic && !String.IsNullOrEmpty(token))
                {
                    request.AddHeader("Authorization", $"Basic {token}");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        var _authHeader = new AuthenticationHeaderValue("Bearer", token);
                        request.AddHeader("Authorization", $"{_authHeader.Scheme} {_authHeader.Parameter}");
                    }
                }

                IRestResponse responseClient = await client.ExecuteAsync(request);

                if (responseClient.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return responseClient.Content;
                }

                //if (scope == "ebudgeting.prpo")
                //    return responseClient.Content;

                throw new Exception($"StatusCode : {responseClient.StatusCode} Error : { responseClient.Content}");
            }
            catch (Exception ex)
            {
                throw new Exception(GeneralUtils.GetExMessage(ex));
            }

        }

    }
}
