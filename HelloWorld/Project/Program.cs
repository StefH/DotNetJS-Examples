using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using DotNetJS;
using Microsoft.JSInterop;

// Namespace is used as the name for both the generated .js file
// and main export object of the UMD library.
namespace HelloWorld
{
    public static class Program
    {
        // Main is invoked by the JavaScript runtime on boot.
        public static async Task Main()
        {
            // Invoking 'getName()' function from JavaScript.
            var hostName = JS.Invoke<string>("getName");

            // Writing to JavaScript console output.
            Console.WriteLine($"Hello {hostName}, DotNet here!");

            var Customers = new List<string>
            {
                "abc",
                "123"
            }.AsQueryable();

            var query = Customers
                .OrderBy("it")
                .Select("it + \"?\"")
                .ToDynamicArray();

            foreach (var c in query)
            {
                Console.WriteLine(c);
            }

            await Task.Delay(100);
        }

        [JSInvokable] // The method is invoked from JavaScript.
        public static string GetName() => "DotNet";

        [JSInvokable] // The method is invoked from JavaScript.
        public static string TestException(string x) => throw new Exception("!!!");
    }
}