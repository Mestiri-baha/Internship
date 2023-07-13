using Newtonsoft.Json;

namespace HomeComponent.Services
{
    public class GenericService<T>
    {
        private readonly HttpClient _HttpClient; 
        public GenericService (HttpClient httpClient)
        {
            _HttpClient = httpClient; 
        }
        public async Task<IEnumerable<T>> GetData()
        {
            //we still need to reformulate it ! 
            var response = await _HttpClient.GetAsync("URI"); 
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<T>>(json);
            return data; 

        }
    }
}
