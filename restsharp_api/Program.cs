using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace restsharp_api
{

    class Person {

        public string name;
        public int age;

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost/test_api");

            //            Person person = new Person("hydro", 26);

            JObject req = new JObject();

            JArray reqArray = new JArray();

            JObject prod = new JObject(
                new JProperty("Test3",3)
                );

            prod.Add("test1", 1);
            //prod.Add("test2", 2);

            reqArray.Add(prod);
            req.Add("SmartSwitch", reqArray);

            reqArray = new JArray();

            prod = new JObject(
                new JProperty("Test3", 5)
                );

            prod.Add("test2", 2);
            reqArray.Add(prod);
            req.Add("SmartCurtain", reqArray);

            //JObject req2 = new JObject(
            //    new JProperty("Test4", 45)
            //    );

            var request = new RestRequest("index.php",Method.POST,DataFormat.Json);
            //request.AddParameter("id", req);
            //request.AddJsonBody(person);
            request.AddParameter("application/json", req, ParameterType.RequestBody);

            //sendAllDeviceWarrantyAsync();
            Console.WriteLine("Before");
            Task<int> task = startAsync();
            //task.Start();
            task.Wait();
            Console.WriteLine("After");

            //request.AddParameter("application/json", req2, ParameterType.RequestBody);

            try
            {

                

                

            }
            catch (Exception ex) {

                Console.WriteLine("Error In RestSharpRequest:" + ex);

            }

            Console.ReadLine();
        }

        public static async Task<int> startAsync() {
            int x = await sendAllDeviceWarrantyAsync();
            return x;
        }

        public static async Task<int> sendAllDeviceWarrantyAsync()
        {

            try
            {

                JObject req = new JObject();

                JArray reqArray = new JArray();

                JObject prod = new JObject(
                    new JProperty("Test3", 3)
                    );

                prod.Add("test1", 1);
                //prod.Add("test2", 2);

                reqArray.Add(prod);
                req.Add("SmartSwitch", reqArray);

                reqArray = new JArray();

                prod = new JObject(
                    new JProperty("Test3", 5)
                    );

                prod.Add("test2", 2);
                reqArray.Add(prod);
                req.Add("SmartCurtain", reqArray);

                var client = new RestClient("http://localhost/test_api");

                var request = new RestRequest("index.php", Method.POST);

                request.AddParameter("application/json", req, ParameterType.RequestBody);

                var response2 = await client.ExecuteAsync(request);

                Console.WriteLine("Status2:" + response2.StatusCode + "\nResponse2:" + response2.Content);

                //client.ExecuteAsync(request, response =>
                //{
                //    Console.WriteLine("Status:" + response.StatusCode + "\nResponse:" + response.Content);
                //});

                //client.ExecuteAsync(request, response =>
                //{
                //    Console.WriteLine("Status3:" + response.StatusCode + "\nResponse3:" + response.Content);
                //});

            }
            catch (Exception ex)
            {
                //Global.DebugConsoleWriteErrorWithTime("Error In Sending All Device Warranty:" + ex);
            }

            return 1;
        }
    }
}
