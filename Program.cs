using System;
using System.Collections.Generic;

namespace ListSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            ListSlicer.Print(new List<int>() { 1,2,3,4,5,6,7,8}, new List<int>() { 2,3, 1});            
        }
    }

    public static class ListSlicer
    {
        public static void Print(List<int> originalList, List<int> subListLengths)
        {
            var result = ListSlicer.Slice(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, new List<int>() { 2, 3, 1 });

            int listCnt = 0;
            foreach (List<int> l in result)
            {
                Console.WriteLine(string.Format("List# {0}:", ++listCnt));
                foreach (int item in l)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static List<List<int>> Slice(List<int> originalList, List<int> subListLengths)
        {
            List<List<int>> retVal = new List<List<int>>();
            if (subListLengths == null || originalList == null)
            {
                throw new ArgumentException("Neither original list, nore subListsLengths can be null");
            }

            if (subListLengths.Count == 0)
            {
                retVal[0] = originalList;
                return retVal;
            }

            int requestedItemCnt = GetRequestedItemCnt(subListLengths);
            //if (requestedItemCnt > originalList.Count)
            //{
            //    throw new ArgumentException("More sub-list items have been requested than the original list contains.");
            //}

            int originalListIndex = 0;
            foreach (int subListLength in subListLengths)
            {
                List<int> subList = new List<int>();
                for (int i=0; i<subListLength; i++)
                {
                    if (originalListIndex < originalList.Count)
                    {
                        subList.Add(originalList[originalListIndex]);
                    }
                    originalListIndex++;
                }

                retVal.Add(subList);
            }

            return retVal;
        }

        private static int GetRequestedItemCnt(List<int> requestedItems)
        {
            int retVal = 0;
            foreach (int item in requestedItems)
            {
                retVal += item;
            }

            return retVal;
        }
    }
}
