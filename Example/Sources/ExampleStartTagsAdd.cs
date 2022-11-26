using System.Collections;
using InsaneOne.Tags;
using UnityEngine;

namespace Tags.Example
{
	public class ExampleStartTagsAdd : MonoBehaviour
	{
		private void Start()
		{
			var tags = gameObject.GetTags();
			tags.WasAdded += OnTagWasAdded;
			tags.WasRemoved += OnTagWasRemoved;
			
			StartCoroutine(ExampleAction());
		}

		IEnumerator ExampleAction()
		{
			Debug.Log("Example adding and removing tags.");
			gameObject.AddTag(ExampleTag.DisableMovement);

			yield return new WaitForSeconds(0.5f);
			
			gameObject.AddTag(ExampleTag.IsPoisoned);
			
			yield return new WaitForSeconds(0.5f);
			
			gameObject.RemoveTag(ExampleTag.DisableMovement);
			
			yield return new WaitForSeconds(0.5f);
			
			Debug.Log("Example stacking IsPoisoned tags (now should be 2 on object).");
			gameObject.AddTag(ExampleTag.IsPoisoned);
		}

		private void OnTagWasAdded(IntTag intTag)
		{
			var realTag = intTag.ToEnum<ExampleTag>();
			Debug.Log($"Tag {realTag} was added");
		}
		
		private void OnTagWasRemoved(IntTag intTag)
		{
			var realTag = intTag.ToEnum<ExampleTag>();
			Debug.Log($"Tag {realTag} was removed");
		}
	}
}