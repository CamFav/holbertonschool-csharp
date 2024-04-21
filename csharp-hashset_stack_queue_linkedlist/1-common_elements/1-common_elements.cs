using System;
using System.Collections.Generic;

class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        // Find common elements
        HashSet<int> set = new HashSet<int>(list1);
        set.IntersectWith(list2);

        List<int> commonElements = new List<int>(set);
        commonElements.Sort();

        return commonElements;
    }
}
