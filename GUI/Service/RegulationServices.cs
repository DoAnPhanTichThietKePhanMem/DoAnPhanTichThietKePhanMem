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
    public class RegulationServices
    {
        public async Task<tb_Regulations> GetInfoRegulation()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Regulation/GetInfoRegulation");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<tb_Regulations>(data.data.ToString());
                    }
                }
            }
            return new tb_Regulations();
        }
        public async Task<string> getQuantityClass()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Regulation/getQuantityClass");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return data.data.ToString();
                    }
                }
            }
            return string.Empty;
        }
        public async Task<string> getQuantitySubject()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync("api/Regulation/getQuantitySubject");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return data.data.ToString();
                    }
                }
            }
            return string.Empty;
        }

        public async Task<bool> UpdateRegulation(tb_Regulations newRegulation)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contentJson = new StringContent(JsonConvert.SerializeObject(new { newRegulation.ID,newRegulation.MinAge, newRegulation.MaxAge,newRegulation.MaxQuantity,newRegulation.ClassQuantity,newRegulation.SubjectQuantity,newRegulation.PassingGrade}), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/Regulation/UpdateRegulation", contentJson);

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
