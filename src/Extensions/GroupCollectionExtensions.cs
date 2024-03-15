
using PolyhydraGames.Core.Global.Collection;


namespace PolyhydraGames.Core.Maui.Extensions;


public static class GroupCollectionExtensions
{
    public static List<IGroupedCollection<T>> ToSimpleGroupedCollection<T>(this IEnumerable<T> items,
        Func<T, string> title)
    {
        var groupedCriteria = ToAlphabeticGroupedCriteria((T i, char z) =>
        {
            var desc = title(i);
            if (string.IsNullOrEmpty(desc)) return false;
            return desc[0] == z;
        });
        var list = items.ToList();
        var grouped = list.ToGroupedCollection(groupedCriteria);
        return grouped;
    }

    public static List<GroupedCriteria<T>> ToAlphabeticGroupedCriteria<T>(Func<T, char, bool> test)
    {
        var crit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var grouped = crit.ToGroupedCriteria(test);
        return grouped;
    }

    public static List<GroupedCriteria<T>> ToGroupedCriteria<T, T2>(this IEnumerable<T2> sortCriteria,
        Func<T, T2, bool> test, Func<T2, string>? longNameFunc = null, Func<T2, string>? shortNameFunc = null)
    {
        var criteria = new List<GroupedCriteria<T>>();
        foreach (var item in sortCriteria)
        {
            var longName = longNameFunc == null ? item?.ToString() : longNameFunc.Invoke(item);
            var shortName = shortNameFunc == null ? item?.ToString() : shortNameFunc.Invoke(item);
            criteria.Add(new GroupedCriteria<T>(i => test(i, item), longName, shortName));
        }

        return criteria;
    }

    public static List<IGroupedCollection<T>> ToGroupedCollection<T>(this IList<T> items,
        IList<GroupedCriteria<T>> groupedCriteria, bool excludeEmptyGroups = true)
    {
        var results = new List<IGroupedCollection<T>>();

        foreach (var item in groupedCriteria)
        {
            var localCollection = new GroupedCollection<T>
            {
                LongName = item.LongName,
                ShortName = item.ShortName
            };
            localCollection.AddRange(items.Where(item.MeetsCriteria));
            if (localCollection.Any() || excludeEmptyGroups == false)
                results.Add(localCollection);
        }

        return results;
    }
}