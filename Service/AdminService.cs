using HelloUWP.Configuration;
using HelloUWP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Service
{
    public class AdminService
    {
        List<Song> listSong = new List<Song>();
        List<Account> listAccount = new List<Account>();
        public async Task<List<Account>> FindAllAccount(string accessToken)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAdmin.ApiBaseUri);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await client.GetAsync(ConfigurationAdmin.ApiGetAccounts);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    listAccount = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(resultContent);
                    return listAccount;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<Song>> FindAllSong(string accessToken)
        {
            List<Song> listSong = new List<Song>();
            try
            {
                using (var httpContent = new HttpClient())
                {
                    httpContent.BaseAddress = new Uri(ConfigurationAdmin.ApiBaseUri);
                    httpContent.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await httpContent.GetAsync(ConfigurationAdmin.ApiGetSongs);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    listSong = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(resultContent);
                    return listSong;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Song> UpdateSong(string accessToken, int id, Song updateSong)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAdmin.ApiBaseUri);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(updateSong);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationAdmin.ApiDataType);
                    var result = await client.PutAsync($"{ConfigurationAdmin.ApiGetSongs}/{id}", contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    var update = Newtonsoft.Json.JsonConvert.DeserializeObject<Song>(resultContent);
                    return update;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task DeleteSong(string accessToken, int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAdmin.ApiBaseUri);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await client.DeleteAsync($"{ConfigurationAdmin.ApiGetSongs}/{id}");
                    string resultContent = await result.Content.ReadAsStringAsync();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
