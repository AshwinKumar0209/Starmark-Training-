using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleConApp;
using System.Threading.Tasks;
using System.Threading;

namespace SampleFrameWork
{
    class QueueExample
    {
        private Queue<string> _recent = new Queue<string>();
        public void ViewItem(string item)
        {
            if (_recent.Count == 3) _recent.Dequeue();
            _recent.Enqueue(item);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(item);
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Our Recently viewed items");

            var data = _recent.Reverse();
            foreach (var subject in _recent)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(subject);
                Console.WriteLine("--------------------------------");
            }
        }
    }

    class Queue {
        static void Main(string[] args)
        {
            QueueExample it = new QueueExample();

            do
            {
                string item = utilities.Prompt("Enter Model Name");
                it.ViewItem(item);
            } while (true);
           

        }
    }
}
