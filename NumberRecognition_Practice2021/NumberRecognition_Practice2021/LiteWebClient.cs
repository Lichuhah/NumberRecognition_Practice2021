using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognition_Practice2021
{
    static public class LiteWebClient
    {
        static public WebClient GetWebClientForJson()
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            return WebClient;
        }

        static public void PostImage(int value, Image image, int networkId)
        {
            Picture picture = new Picture();
            picture.Value = value;
            picture.Image = ImageProcessor.GetByteFromImage(image);

            string json = JsonConvert.SerializeObject(picture);
            var WebClient = LiteWebClient.GetWebClientForJson();
            string response = WebClient.UploadString("https://localhost:44387/api/DataSet/" + networkId, json);
        }

        static public void PutNetwork()
        {

        }

        static public void PostNetwork(string name, byte[] p)
        {
            Network network = new Network();
            network.Name = name;
            network.Data = p;
            string json = JsonConvert.SerializeObject(network);
            var WebClient = LiteWebClient.GetWebClientForJson();
            string response = WebClient.UploadString("https://localhost:44387/api/Network", json);
        }

        static public Network GetNetwork(string id)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string url = "https://localhost:44387/api/Network/" + id;
            string json = WebClient.DownloadString(url);
            return JsonConvert.DeserializeObject<Network>(json);
        }
    }
}
