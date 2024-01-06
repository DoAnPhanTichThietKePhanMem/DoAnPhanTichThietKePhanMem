using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GUI.Common;
using Newtonsoft.Json;
using static GUI.Common.GeneralModel;

namespace GUI.Service
{
    public class ClassServices
    {
        public async Task<List<tb_Groups>> GetInfoGrade()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Class/GetInfoGroup");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Groups>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Groups>();
        }

        public async Task<List<tb_Class>> GetInfoClass(int gradeId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Class/GetInfoClass?gradeId={gradeId}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Class>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Class>();
        }

        public async Task<List<tb_Students>> GetInfoStudentsOfClass(int classId, string studentNameSearch)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { classID = classId, studentNameSearch = studentNameSearch}), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Class/GetInfoStudentsOfClass",contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Students>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Students>();
        }

        public async Task<bool> CheckQuantityStudentOfclass(int classId, int quantityStudentsAddToClass)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { classID = classId, quantityStudentsAddToClass = quantityStudentsAddToClass }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Class/CheckQuantityStudentOfclass", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }

        public async Task<List<tb_Students>> GetInfoStudentsWithoutClass(string studentNameSearch)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Class/GetInfoStudentsWithoutClass?studentNameSearch={studentNameSearch}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Students>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Students>();
        }

        public async Task<bool> AddStudentIntoClass(int classId, int studentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { classID = classId, studentID = studentId }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Class/AddStudentIntoClass", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }

        public async Task<bool> DeleteStudentFromClass(int studentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.DeleteAsync($"api/Class/DeleteStudentFromClass?studentId={studentId}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }

        public async Task<tb_Class> GetInfoClassByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Class/GetInfoClassByName?name={name}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<tb_Class>(data.data.ToString());
                    }
                }
            }
            return null;
        }

        public async Task<bool> AddInfoClass(tb_Class newClass)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { groupId = newClass.GroupID, name = newClass.Name, quantity = newClass.Quantity, createdDate = newClass.CreatedDate, lastUpdatedDate = newClass.LastUpdatedDate, isDeleted = newClass.IsDeleted }), Encoding.UTF8, "application/json"); ;
                var result = await client.PostAsync("api/Class/AddInfoClass",contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }

        public async Task<bool> UpdateInfoNameClass(int classId, string newName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { classID = classId, newName = newName}), Encoding.UTF8, "application/json"); 
                var result = await client.PostAsync("/api/Class/UpdateInfoNameClass", contentJson);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }

        public async Task<bool> DeleteInfoClass(int classId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.DeleteAsync($"/api/Class/DeleteInfoClass?classId={classId}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return bool.Parse(data.data.ToString());
                    }
                }
            }
            return false;
        }
        

    }

}
