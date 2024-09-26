using System.Collections.Generic;

public static class ListExtensions {
    private static readonly Dictionary<object, List<int>> activeItemsDict = new();

    public static T GetRandomItem<T>(this IList<T> list) {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static T GetRandomItemAndRemoveIt<T>(this IList<T> list) {
        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        T randomItem = list[randomIndex];
        list.RemoveAt(randomIndex);

        return randomItem;
    }

    //public static T GetRandomItemWithoutRepetition<T>(this IList<T> list) {
    //    if (list == null || list.Count == 0) {
    //        throw new ArgumentException("List cannot be null or empty.");
    //    }

    //    if (!activeItemsDict.TryGetValue(list, out var activeItems)) {
    //        activeItems = new List<int>(list.Count);
    //        for (int i = 0; i < list.Count; i++) {
    //            activeItems.Add(i);
    //        }
    //        activeItemsDict[list] = activeItems;
    //    }

    //    if (activeItems.Count == 0) {
    //        return default;

    //        // Repopulate active items when all items have been used
    //        for (int i = 0; i < list.Count; i++) {
    //            activeItems.Add(i);
    //        }
    //    }

    //    int randomIndex = UnityEngine.Random.Range(0, activeItems.Count);
    //    int selectedIndex = activeItems[randomIndex];
    //    activeItems.RemoveAt(randomIndex);

    //    return list[selectedIndex];
    //}

    //public static void ActivateItem<T>(this IList<T> list, T item) {
    //    if (list == null) {
    //        throw new ArgumentException("List cannot be null.");
    //    }

    //    if (!activeItemsDict.TryGetValue(list, out var activeItems)) {
    //        return; // If the list is not being tracked, there's nothing to deactivate
    //    }

    //    int index = list.IndexOf(item);
    //    if (index >= 0 && !activeItems.Contains(index)) {
    //        activeItems.Add(index); // Re-add the item back to the active pool
    //    }
    //}

    //public static void DeactivateItem<T>(this IList<T> list, T item) {
    //    if (list == null) {
    //        throw new ArgumentException("List cannot be null.");
    //    }

    //    if (!activeItemsDict.TryGetValue(list, out var activeItems)) {
    //        activeItems = new List<int>(list.Count);
    //        activeItemsDict[list] = activeItems;
    //    }

    //    int index = list.IndexOf(item);
    //    if (index >= 0 && activeItems.Contains(index)) {
    //        activeItems.Remove(index); // Remove the item from the active pool
    //    }
    //}
}