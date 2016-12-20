using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a 'WebRequest' object with the specified url. 
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://api.nbp.pl/api/cenyzlota/today");

            myWebRequest.Accept = "application/json";

            // Send the 'WebRequest' and wait for response.
            WebResponse myWebResponse = myWebRequest.GetResponse();

            // Obtain a 'Stream' object associated with the response object.
            Stream ReceiveStream = myWebResponse.GetResponseStream();

            StreamReader reader = new StreamReader(ReceiveStream);

            CenyZlota [] cena = JsonConvert.DeserializeObject<CenyZlota[]>(reader.ReadLine());  

            Console.WriteLine(cena[0].cena);
            Console.WriteLine(cena[0].data);
            Console.ReadKey();
        }
    }

    class CenyZlota
    {
        public DateTime data { get; set; }
        public float cena { get; set; }
    }
}
