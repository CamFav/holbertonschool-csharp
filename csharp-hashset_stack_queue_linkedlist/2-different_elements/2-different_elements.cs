// method that returns a sorted list of all elements present in one or the other list but not both.
using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        HashSet<int> set1 = new HashSet<int>(list1);
        HashSet<int> set2 = new HashSet<int>(list2);

        set1.ExceptWith(set2);
        set2.ExceptWith(list1);

        set1.UnionWith(set2);

        List<int> differentElements = new List<int>(set1);
        differentElements.Sort();

        return differentElements;
    }
}
