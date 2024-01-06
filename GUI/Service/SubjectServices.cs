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
    public class SubjectServices
    {

        public async Task<List<tb_Subjects>> GetInfoSubjects()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Subject/GetInfoSubjects");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<tb_Subjects>>(data.data.ToString());
                    }
                }
            }
            return new List<tb_Subjects>();
        }
        public async Task<tb_Subjects> GetSubjectByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Subject/GetSubjectByName?name={name}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<tb_Subjects>(data.data.ToString());
                    }
                }
            }
            return null;
        }

        public async Task<bool> AddInfoSubject(tb_Subjects newSubject)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { name = newSubject.Name, createdDate = newSubject.CreatedDate, lastUpdatedDate = newSubject.LastUpdatedDate, isDeleted = newSubject.IsDeleted }), Encoding.UTF8, "application/json"); ;
                var result = await client.PostAsync("api/Subject/AddInfoSubject", contentJson);

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

        public async Task<bool> UpdateInfoNameSubject(int subjectId, string newName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { subjectID = subjectId, newName = newName }), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Subject/UpdateInfoNameSubject", contentJson);

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

        public async Task<bool> DeleteInfoSubject(int subjectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.DeleteAsync($"api/Subject/DeleteInfoSubject?subjectId={subjectId}");

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
