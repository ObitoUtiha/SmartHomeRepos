using Newtonsoft.Json;
using SmartHomeApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SmartHomeApp.Model.ActivityHistories;

namespace SmartHomeApp
{
    public class ApiConnect
    {
        private static string BaseUrl = "http://192.168.0.104:5195/api/";

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async static Task<Users> AuthorisationAsync(Users user)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(BaseUrl + "Authorisationcs", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Users>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async static Task<bool> PostUser(Users user)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(BaseUrl + "Users/Registration",
                    new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));


                return response.IsSuccessStatusCode;

            }
        }

        public async static Task<List<Devices>> GetDeviceAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(BaseUrl + "Devices");
                return JsonConvert.DeserializeObject<List<Devices>>(response);
            }
        }

        public async static Task<List<Homes>> GetUserHomes(int UserId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(BaseUrl + "Homes/HomesOfUser/" + UserId);
                return JsonConvert.DeserializeObject<List<Homes>>(response);
            }
        }

        public async static Task<bool> PostUserInHomeAsync(UserInHomes userInHomes)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "UserInHomes");

                request.Content = new StringContent(JsonConvert.SerializeObject(userInHomes), Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }

        public async static Task<bool> PostHomeAsync(Homes home)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "Homes");

                request.Content = new StringContent(JsonConvert.SerializeObject(home), Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }

        public async static Task<bool> PutHomeAsync(int id, Homes homes)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "Homes/" + id);

                request.Content = new StringContent(JsonConvert.SerializeObject(homes), Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                    return response.IsSuccessStatusCode;
                else
                    return false;
            }
        }

        public async static Task<bool> DeleteHomeAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, BaseUrl + "Homes/" + id);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                    return response.IsSuccessStatusCode;
                else
                    return false;
            }
        }


    }
}
