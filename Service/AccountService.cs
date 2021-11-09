using HelloUWP.Configuration;
using HelloUWP.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Service
{
    public class AccountService
    {
        public async Task<bool> Register(Account account)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAccount.ApiBaseUri);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(account);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationAccount.ApiDataType);
                    var result = await client.PostAsync(ConfigurationAccount.ApiPostPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<Token> Login(string email, string password)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAccount.ApiBaseUri);
                    var loginInfo = new
                    {
                        email = email,
                        password = password
                    };
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(loginInfo);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationAccount.ApiDataType);
                    var result = await client.PostAsync(ConfigurationAccount.ApiLoginPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(resultContent);
                    Helper helper = new Helper();
                    helper.WriteFile(token.access_token);
                    return token;
                }  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Account> GetProfile(string accessToken)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAccount.ApiBaseUriProfile);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await client.GetAsync(ConfigurationAccount.ApiGetProfile);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    var convertResultContent = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(resultContent);
                    return convertResultContent;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
