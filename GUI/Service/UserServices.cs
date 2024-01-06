using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static GUI.Common.GeneralModel;

namespace GUI.Service
{
    public class UserServices
    {
        public async Task<int> Login(string username, string password)
        {
            // return 0 : Sai tên tài khoản
            // return 1 : Đăng nhập thành công
            // return 2 : Sai mật khẩu
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { userName = username, password }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/User/Login", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    return int.Parse(data.data.ToString());

                }
                else
                {
                    return 2;
                }
            }
        }

        public async Task<int> Register(string email, string username, string password, string confirmpass)
        {
            // return 0 : tài khoản đã tồn tại
            // return 1 : Đăng ký thành công
            // return 2 : Mật khẩu xác nhận lại ko đúng
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { email, userName = username, password, confirmPassword = confirmpass }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/User/Register", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    return int.Parse(data.data.ToString());
                }
                else
                {
                    return 2;
                }
            }
        }

        public async Task<bool> CheckUserForGetPass(string email, string username)
        {
            // return 0 : tài khoản đã tồn tại
            // return 1 : Đăng ký thành công
            // return 2 : Mật khẩu xác nhận lại ko đúng
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { email, userName = username }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/User/CheckUserForGetPass", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    return bool.Parse(data.data.ToString());
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> ResetPass(string email, string username, string password)
        {
            // return 0 : tài khoản đã tồn tại
            // return 1 : Đăng ký thành công
            // return 2 : Mật khẩu xác nhận lại ko đúng
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { email, userName = username, password }), Encoding.UTF8, "application/json");
                var result = await client.PutAsync("api/User/ResetPass", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    return bool.Parse(data.data.ToString());
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
