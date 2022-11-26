using InsaneOne.Tags;
using UnityEngine;

namespace Tags.Example
{
	public class ExampleTagsInit : MonoBehaviour
	{
		private void Awake()
		{
			TagsSettings.Init<ExampleTag>();
		}
	}
}