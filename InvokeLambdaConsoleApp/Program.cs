using System;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace InvokeLambdaConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAmazonLambda client = new AmazonLambdaClient();
            string functionName = "AWSLambdaEcho";
            string invokeArgs = "\"Hello World\"";

            Console.WriteLine("Invokation Args: " + invokeArgs);

            var response = await client.InvokeAsync(
                new InvokeRequest
                {
                    FunctionName = functionName,
                    Payload = invokeArgs,
                });

            //StreamReader sr = new StreamReader(response.Payload);
            //Console.WriteLine(sr.ReadToEnd());

            string payloadString = Encoding.ASCII.GetString(response.Payload.ToArray());

            Console.WriteLine("Lambda Response: " + payloadString);

            Console.ReadLine();
        }
    }
}
