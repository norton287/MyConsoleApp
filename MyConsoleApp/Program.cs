using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyConsoleApp
{
    class Program
    {
        private static readonly Stopwatch _stopwatch = new Stopwatch();

        private static void Main()
		{

            _stopwatch.Restart();

            var searchEntireString = new SearchEntireString();
            searchEntireString.StringSearch();

            var searchSubString = new SearchSubString();
            searchSubString.SubString();
            
            var searchStartsWith = new SearchStartsWith();
            searchStartsWith.StartsWith();

            var searchEndsWith = new SearchEndsWith();
            searchEndsWith.EndsWith();

            _stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Total Time To Do All Searches {0}", _stopwatch.Elapsed);
            Console.ReadKey();
        }
	}

    public class BuildStringList
    {
        public readonly List<string> StringList = new List<string>();

        public void BuildList()
        {
            StringList.Add(
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            StringList.Add(
                "Sed odio morbi quis commodo odio aenean sed adipiscing diam. In ornare quam viverra orci sagittis eu volutpat odio facilisis. Morbi tempus iaculis urna id volutpat lacus laoreet non. Adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus urna.");
            StringList.Add(
                "Lorem ipsum dolor sit amet consectetur adipiscing elit. Feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit. Vitae aliquet nec ullamcorper sit amet risus. A iaculis at erat pellentesque adipiscing commodo elit at.");
            StringList.Add(
                "Mattis aliquam faucibus purus in massa tempor. Nibh venenatis cras sed felis eget velit aliquet sagittis id. Purus sit amet luctus venenatis lectus. Venenatis urna cursus eget nunc scelerisque viverra mauris in aliquam.");
            StringList.Add(
                "Sed blandit libero volutpat sed cras ornare arcu. Eu facilisis sed odio morbi quis. Ornare aenean euismod elementum nisi quis eleifend quam. Penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.");
        }
    }

    public class SearchEntireString
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void StringSearch()
        {
            _stopwatch.Restart();

            var buildStringList = new BuildStringList();
            buildStringList.BuildList();

            var myList = buildStringList.StringList;

            foreach (var Result in myList.Select(s => s.Contains("Lorem ipsum dolor sit amet")))
            {
                Console.WriteLine($"Does it contain the string we are searching for? {Result}");
            }

            _stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Total Time To Do StringSearch was {0}", _stopwatch.Elapsed);
            Console.WriteLine();
        }

    }

    public class SearchSubString
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void SubString()
        {
            _stopwatch.Restart();

            const string subString = "Sed odio morbi quis commodo odio aenean sed adipiscing diam.";

            var firstIndex = subString.IndexOf("Sed", StringComparison.Ordinal) + "Sed".Length;
            var lastIndex = subString.LastIndexOf(".", StringComparison.Ordinal);
            if (firstIndex >= 0 && subString.Length > firstIndex)
            {
                var stringFound = subString.Substring(firstIndex, lastIndex - firstIndex);
                Console.WriteLine($"Substring found was: '{stringFound}'");
            }

            _stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Total Time To Do SubString Search was {0}", _stopwatch.Elapsed);
            Console.WriteLine();
        }
    }

    public class SearchStartsWith
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void StartsWith()
        {
            _stopwatch.Restart();

            var buildStringList = new BuildStringList();
            buildStringList.BuildList();

            var myList = buildStringList.StringList;

            foreach (var Result in myList.Select(s => s.StartsWith("L", StringComparison.Ordinal)))
            {
                Console.WriteLine($"Starts with \"L\"? {Result}");
            }

            _stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Total Time To Do String Starts With was {0}", _stopwatch.Elapsed);
            Console.WriteLine();
        }
    }

    public class SearchEndsWith
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void EndsWith()
        {
            _stopwatch.Restart();

            var buildStringList = new BuildStringList();
            buildStringList.BuildList();

            var myList = buildStringList.StringList;

            foreach (var s in myList)
            {
                var Result = s.EndsWith(".", StringComparison.CurrentCultureIgnoreCase);
                Console.WriteLine($"Ends with '.'? {Result}");
            }

            _stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Total Time To Do String Ends With was {0}", _stopwatch.Elapsed);
            Console.WriteLine();
        }
    }
}

