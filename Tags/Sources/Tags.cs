using System;
using System.Collections.Generic;

namespace InsaneOne.Tags
{
    public sealed class Tags
    {
        public event Action<IntTag> WasAdded, WasRemoved;
        
        readonly Dictionary<IntTag, int> addedTags = new Dictionary<IntTag, int>();
 
        public void Add(params IntTag[] tags)
        {
            foreach (var tag in tags)
                if (Has(tag))
                    addedTags[tag]++;
                else
                    FirstAddTag(tag);
        }

        public void AddOnce(params IntTag[] tags)
        {
            foreach (var tag in tags)
                if (!Has(tag))
                    FirstAddTag(tag);
        }

        void FirstAddTag(IntTag tag)
        {
            addedTags.Add(tag, 1);
            WasAdded?.Invoke(tag);
        }

        public void Remove(params IntTag[] tags)
        {
            foreach (var tag in tags)
            {
                if (!Has(tag))
                    return;

                addedTags[tag]--;

                if (addedTags[tag] > 0)
                    continue;

                addedTags.Remove(tag);
                WasRemoved?.Invoke(tag);
            }
        }

        public bool Has(IntTag tag) => addedTags.ContainsKey(tag);
        
        public int Count(IntTag tag)
        {
            addedTags.TryGetValue(tag, out var count);

            return count;
        }

        public bool HasAny(params IntTag[] tags)
        {
            for (var i = 0; i < tags.Length; i++)
                if (Has(tags[i]))
                    return true;

            return false;
        }

        public bool HasAll(params IntTag[] tags)
        {
            for (var i = 0; i < tags.Length; i++)
                if (!Has(tags[i]))
                    return false;

            return true;
        }

        public bool ConsumeTag(IntTag tag)
        {
            if (Has(tag))
            {
                Remove(tag);
                return true;
            }

            return false;
        }

        /// <summary>Removes all tags without raising events.</summary>
        public void Reset() => addedTags.Clear();

        /// <summary> Only for debugging purposes. </summary>
        public Dictionary<IntTag, int> GetTagsInternal() => addedTags;
    }
}