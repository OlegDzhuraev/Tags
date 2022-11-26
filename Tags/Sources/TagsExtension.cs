using UnityEngine;

namespace InsaneOne.Tags
{
	public static class TagsExtension
	{
		public static bool HasMonoTags(this GameObject go) => go.TryGetComponent(out MonoTags _);

		public static Tags GetTags(this GameObject go)
		{
			if (!go.TryGetComponent(out MonoTags monoTags))
				monoTags = go.AddComponent<MonoTags>();

			return monoTags.Tags;
		}
		
		public static void AddTag(this GameObject go, params IntTag[] tags) => go.GetTags().Add(tags);
		public static void AddTagOnce(this GameObject go, params IntTag[] tags) => go.GetTags().AddOnce(tags);
		public static void RemoveTag(this GameObject go, params IntTag[] tags) => go.GetTags().Remove(tags);
		
		public static int CountTags(this GameObject go, IntTag tag) => go.GetTags().Count(tag);
		public static bool HaveTag(this GameObject go, IntTag tag) => go.GetTags().Have(tag);
		public static bool HaveAnyTags(this GameObject go, params IntTag[] tags) => go.GetTags().HaveAny(tags);
		public static bool HaveAllTags(this GameObject go, params IntTag[] tags) => go.GetTags().HaveAll(tags);
	}
}