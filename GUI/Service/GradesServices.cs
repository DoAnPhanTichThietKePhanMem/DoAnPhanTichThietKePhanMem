using GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static GUI.Common.GeneralModel;

namespace GUI.Service
{
    public class GradesVM
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int? SemesterID { get; set; }
        public string Semester { get; set; }
        public int? SubjectID { get; set; }
        public string SubjectName { get; set; }
        public double? Grade15 { get; set; }
        public double? Grade45 { get; set; }
        public double? GradeSemester { get; set; }
    }
    public class GradesServices
    {
        public async Task<List<GradesVM>> GetGradesList(int ClassID, int SemeterID, int SubjectID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Grades/GetGradesList/{ClassID}/{SemeterID}/{SubjectID}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<GradesVM>>(data.data.ToString());
                    }
                }
            }
            return new List<GradesVM>();
        }


        public async Task<List<tb_Students>> GetInfoStudentsOfClass(int classId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Grades/GetInfoStudentsOfClass/{classId}");

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


        public async Task<List<tb_Semesters>> GetInfoSemeters()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Grades/GetInfoSemeters");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Semesters>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Semesters>();
        }

        public async Task<bool> AddGrades(tb_TranScripts ts)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(ts), Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"api/Grades/AddGrades", contentJson);

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


        public async Task<bool> UpdateGrades(tb_TranScripts ts)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(ts), Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"api/Grades/UpdateGrades", contentJson);

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

        public async Task<bool> CheckGrades(tb_TranScripts ts)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(ts), Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"api/Grades/CheckGrades", contentJson);

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

        public async Task<bool> DeleteGrades(int Id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.DeleteAsync($"api/Grades/DeleteGrades?ID={Id}");

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
