
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MyMessanger
{
    class MessangerClientAPI
    {
        public void TestNewtonsoftJson()
        {
            Message msg = new Message("RusAl", "Privet", DateTime.Now);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
            //{ "UserName":"RusAl","MessageText":"Privet","TimeStamp":"2022-06-14T16:29:04.9158952+08:00"}
            //RusAl<Privet>: 14.06.2022 16:29:04
        }

        public Message GetMessage(int MessageId)
        {

            WebRequest request = WebRequest.Create("http://localhost:5287/api/Messanger/" + MessageId.ToString());
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            //Console.WriteLine(status);

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            if ((status.ToLower() == "ok") && (responseFromServer != "Not found"))
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseFromServer);
                Console.WriteLine(deserializedMsg);
                return deserializedMsg;
            }

            return null;
        }

        public bool SendMessage(Message msg)
        {
            WebRequest request = WebRequest.Create("http://localhost:5287/api/Messanger");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader (dataStream);
            string responceFromServer = reader.ReadToEnd();
            //Console.WriteLine(responceFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            return true;

        }
    }
}
