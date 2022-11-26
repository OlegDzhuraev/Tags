using UnityEngine;

namespace InsaneOne.Tags
{
	public class GlobalTags
	{
		public static Tags Instance
		{
			get
			{
				if (instance == null)
				{
					var obj = new GameObject(nameof(GlobalTags));
					GameObject.DontDestroyOnLoad(obj);
					
					instance = obj.GetTags();
				}

				return instance;
			}
		}
		
		static Tags instance;
	}
}