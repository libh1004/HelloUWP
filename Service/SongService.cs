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
    public class SongService
    {
        public async Task<bool> Save(Song song)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSong.ApiBaseUri);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(song);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationSong.ApiDataType);
                    var result = await client.PostAsync(ConfigurationSong.ApiPostPath, contentToSend);
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
        public async Task<Song> FindById(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSong.ApiBaseUri);
                    var result = await client.GetAsync($"{ConfigurationSong.ApiPostPath}/{id}");
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    var song = Newtonsoft.Json.JsonConvert.DeserializeObject<Song>(resultContent);
                    return song;   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            } return null;
        }
        public async Task<bool> Update(Song updateSong, int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSong.ApiBaseUri);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(updateSong);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationSong.ApiDataType);
                    var result = await client.PutAsync($"{ConfigurationSong.ApiPostPath}/{id}", contentToSend);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSong.ApiBaseUri);
                    var result = await client.DeleteAsync($"{ConfigurationSong.ApiPostPath}/{id}");
                    var resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<bool> CreateMySong(Song song, string accessToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationAccount.ApiBaseUri);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(song);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ConfigurationAccount.ApiDataType);
                    var result = await client.PostAsync(ConfigurationSong.ApiPostMine, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<List<Song>> FindAllMySong(string accessToken)
        {
            List<Song> list = new List<Song>();
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSong.ApiBaseUri);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await client.GetAsync(ConfigurationSong.ApiPostMine);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(resultContent);
                    return list;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
