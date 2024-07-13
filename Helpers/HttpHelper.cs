namespace MovieNest.Helpers
{
    public static class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResponseAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
    }
}
