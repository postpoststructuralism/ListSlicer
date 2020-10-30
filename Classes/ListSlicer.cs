using System;
using System.Collections.Generic;
using System.Text;

namespace ListSlicer
{
    public static class ListSlicer
    {
        public static int runCnt = 0;

        public static void Print(TestParams tp)
        {
            Console.WriteLine(string.Format("{0}Test run #{1} [{2}]:",
                (runCnt > 0 ? Environment.NewLine : string.Empty), ++runCnt, tp.PrintLists()));

            var result = ListSlicer.Slice(tp.OriginalList, tp.RequestedLists);
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
            int originalListIndex = 0;
            foreach (int subListLength in subListLengths)
            {
                List<int> subList = new List<int>();
                for (int i = 0; i < subListLength; i++)
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
