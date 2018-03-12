using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterCS
{
    class TestAttribute : System.Attribute
    {

    }

    [Test] class X
    {
        public string Name { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var list = new[] { "Apple", "Pear", "Banana", "Grape", "Pineapple", "Apple", "Kiwi", "lemon", "lime" };

                // what is ForEach? Why do we call ToList()?
                list.ToList().ForEach(x => Console.WriteLine($"fruit is {x}"));

                // What is action?
                Action<string> a = (x) => Console.WriteLine($"fruit is {x}");
                list.ToList().Sort();
                list.ToList().ForEach(a);

                Console.WriteLine("--------");

                // How do we do sort the fruit list in reverse?
                var fruitList = list.ToList();
                fruitList.Sort(/* what goes here */);
                fruitList.ForEach(a);

                // print the name and count of all duplicates in the fruit list:
                fruitList.GroupBy(x => x).Where(y => y.Count() > 1).Select(z => new { z.Key, Cnt = z.Count() }).ToList().ForEach(q => Console.WriteLine($"Key ={q.Key} count: {q.Cnt}"));
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
