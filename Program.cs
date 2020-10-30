using System;
using System.Collections.Generic;

namespace ListSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            ListSlicer.Print(new TestParams(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, new List<int>() { 2, 3, 1 }));
            ListSlicer.Print(new TestParams(new List<int>(), new List<int>() { 2, 3, 1 }));
            ListSlicer.Print(new TestParams(new List<int>() { 1, 2, 3 }, new List<int>() { 2, 3, 1 }));
        }
    }
}
