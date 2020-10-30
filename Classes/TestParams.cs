using System;
using System.Collections.Generic;
using System.Text;

namespace ListSlicer
{
    public class TestParams
    {
        public List<int> OriginalList { get; set; }
        public List<int> RequestedLists { get; set; }

        public TestParams(List<int> originalList, List<int> requestedList)
        {
            OriginalList = originalList;
            RequestedLists = requestedList;
        }

        public string PrintLists()
        {
            string retVal = string.Format("[originalList: {0}, sublist lengths: {1}]:",
                ListToString(OriginalList),
                ListToString(RequestedLists));

            return retVal;
        }

        private string ListToString(List<int> requestedList)
        {
            string retVal = string.Empty;
            if (requestedList.Count == 0)
            {
                return retVal;
            }

            for (int i = 0; i < requestedList.Count - 1; i++)
            {
                retVal += string.Format("{0},", requestedList[i]);
            }

            retVal += requestedList[requestedList.Count - 1];

            return retVal;
        }
    }
}
