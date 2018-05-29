using System.Collections.Generic;

namespace ExtraCollection
{
    public static class ListExtension
    {
        // NOTE: unable to restrict by IList. IList is not writable (e.g. array can't change size itself, but it's also IList) 
        public static bool RemoveIf<TEntity>(
            this List<TEntity> list,
            System.Func<TEntity, bool> checker
        )
        {
            var removed = false;

            for (var i = 0; i < list.Count; i++)
            {
                var element = list[i];

                if (checker(element))
                {
                    list.RemoveAt(i);
                    removed = true;
                }
            }

            return removed;
        }
    }
}