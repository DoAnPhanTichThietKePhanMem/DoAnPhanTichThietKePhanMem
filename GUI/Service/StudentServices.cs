using GUI.Common;
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
    public class StudentServices
    {
        public async Task<List<StudentVM>> ListStudentRecord()
        {
            // return 0 : Sai tên tài khoản
            // return 1 : Đăng nhập thành công
            // return 2 : Sai mật khẩu
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Student/ListStudentRecord");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<StudentVM>>(data.data.ToString());
                    }
                }
            }
            return new List<StudentVM>();
        }


        public async Task<List<StudentVM>> SearchStudent(string search)
        {
            // return 0 : Sai tên tài khoản
            // return 1 : Đăng nhập thành công
            // return 2 : Sai mật khẩu
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Student/SearchStudent?stringSearch={search}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<StudentVM>>(data.data.ToString());
                    }
                }
            }
            return new List<StudentVM>();
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.DeleteAsync($"api/Student/DeleteStudent?ID={Id}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    return bool.Parse(data.data.ToString());
                }
            }
            return false;
        }
        public async Task<bool> UpdateStudent(tb_Students studentVM)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var contentJson = new StringContent(JsonConvert.SerializeObject(studentVM), Encoding.UTF8, "application/json");
                var result = await client.PutAsync("api/Student/UpdateStudent", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);


                    return bool.Parse(data.data.ToString());
                }
            }
            return false;
        }

        public async Task<bool> AddStudent(tb_Students studentVM)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var contentJson = new StringContent(JsonConvert.SerializeObject(studentVM), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Student/AddStudent", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);


                    return bool.Parse(data.data.ToString());
                }
            }
            return false;
        }
    }
}
