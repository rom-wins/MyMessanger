
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMessanger
{
    class MessangerClientAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Message> GetMessageHTTPAsync(int MessageID)
        {

            var responceString = await client.GetStringAsync("http://localhost:5000/api/Messanger/" + MessageID.ToString());
            if (responceString != null)
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responceString);
                return deserializedMsg;
            }

            return null;
        }
        public bool SendMessage(Message msg)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messanger");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader (dataStream);
            string responceFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return true;

        }
    }
}
