using System;
using System.Collections.Generic;
using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;

namespace HelloWorld
{
    public class HandlebarsTest
    {
        public IEnumerable<object[]> Test()
        {
            var handlebars = Handlebars.Create();
            HandlebarsHelpers.Register(handlebars, options => { options.UseCategoryPrefix = false; });

            var tests = new[]
            {
                "{{Abs -1}}",
                "{{Abs -1.1234}}",

                "{{Add 1 2}}",
                "{{Add 1 '2'}}",

                "{{Sign -1}}",
                "{{Sign " + long.MinValue + "}}",
                "{{Sign -1.1234}}",
                "{{Abs -1,1234}}",

                "{{Min 42 5}}",
                "{{Min 42 5.2}}",
                "{{Min 42.1 5}}",

                "{{this}}",
                "{{[Constants.Math.PI]}}",
                "{{#IsMatch \"Hello\" \"Hello\"}}yes{{else}}no{{/IsMatch}}",
                "{{#IsMatch \"Hello\" \"hello\"}}yes{{else}}no{{/IsMatch}}",
                "{{#IsMatch \"Hello\" \"hello\" 'i'}}yesI{{else}}noI{{/IsMatch}}",
                "{{#StartsWith \"Hello\" \"x\"}}Hi{{else}}Goodbye{{/StartsWith}}",
                "{{Skip [\"a\", \"b\", \"c\", 1] 1}}",

                "{{StartsWith \"abc\" \"!def\"}}",
                "{{Append \"abc\" \"!def\"}}",
                "{{Capitalize \"abc def\"}}",
                "{{Ellipsis \"abcfskdagdghsjfjd\" 5}}",
                "{{Reverse \"abc def\"}}",
                "{{Truncate \"abc def\" 166}}",
                "{{Camelcase \"abc def\"}}",
                "{{Pascalcase \"abc def\"}}",
                "{{Uppercase \"abc\"}}",
                "{{Lowercase \"XYZ\"}}",
                "{{Format x \"o\"}}",
                "{{Now}}",
                "{{UtcNow}}",
                "{{Now \"yyyy-MM-dd\"}}",
                "{{Format (Now) \"yyyy-MM-dd\"}}",
                // "{{Xeger.Generate \"[1-9]{1}\\d{3}\"}}",
                // "{{Random Type=\"Integer\" Min=1000 Max=9999}}"
            };

            foreach (string test in tests)
            {
                var t = new
                {
                    x = DateTime.Now
                };
                var template = handlebars.Compile(test);
                var result = template.Invoke(t);
                Console.WriteLine($"{test} : {result}");

                yield return new object[] { test, result };
            }

            Console.WriteLine(new string('-', 80));
        }
    }
}