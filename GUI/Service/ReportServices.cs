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
    public class ReportServices
    {
        public async Task<List<ReportVM>> BaoCaoTongKetMon(int SubjectID, int SemeterID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Report/BaoCaoTongKetMon?subjectID={SubjectID}&semeterID={SemeterID}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<ReportVM>>(data.data.ToString());
                    }
                }
            }
            return new List<ReportVM>();
        }

        public async Task<List<ReportVM>> BaoCaoTongKetHocKy(int SemeterID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync($"api/Report/BaoCaoTongKetHocKy?semeterID={SemeterID}");

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ResponeseMessage>(resp);

                    if (data.data != null)
                    {
                        return JsonConvert.DeserializeObject<List<ReportVM>>(data.data.ToString());
                    }
                }
            }
            return new List<ReportVM>();
        }
        

    }
}
