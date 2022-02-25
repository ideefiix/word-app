namespace api.Services
{
    public class TranslateService
    {
        private HttpClient client;

        public TranslateService()
        {
            client = new HttpClient();
        }

        public async Task<string> translate(string en_query)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "x-rapidapi-host", "google-translate1.p.rapidapi.com" },
        { "x-rapidapi-key", "2de26ac0a2mshe6832abec6f4f0bp1928b9jsn699ea3509bb3" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "q", $"{en_query}" },
        { "target", "sv" },
        { "source", "en" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                //"{\"data\":{\"translations\":[{\"translatedText\":\"ko\"}]}}"
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                string[] bodyParts = body.Split('"');
                string word = bodyParts[bodyParts.Length - 2];
                return word;
            }
        }
    }
}