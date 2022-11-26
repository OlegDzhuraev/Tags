using System;

namespace InsaneOne.Tags
{
	public static class TagsSettings
	{
		public static bool IsInited { get; private set; }
		public static Type TagsType { get; private set; }
		
		public static void Init<T>() where T : Enum
		{
			IsInited = true;
			TagsType = typeof(T);
		}
	}
}