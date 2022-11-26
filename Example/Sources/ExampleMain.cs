using System.Collections;
using InsaneOne.Tags;
using UnityEngine;

namespace Tags.Example
{
	public class ExampleMain : MonoBehaviour
	{
		private void Start()
		{
			var tags = gameObject.GetTags();
			tags.WasAdded += OnTagWasAdded;
			tags.WasRemoved += OnTagWasRemoved;
			
			GlobalTags.Instance.WasAdded += OnGlobalTagWasAdded;
			
			StartCoroutine(ExampleAction());
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
		
		private void OnGlobalTagWasAdded(IntTag intTag)
		{
			var realTag = intTag.ToEnum<ExampleTag>();
			Debug.Log($"GLOBAL Tag {realTag} was added");
		}

		IEnumerator ExampleAction()
		{
			LogHeading("Add tag example:");
			gameObject.AddTag(ExampleTag.DisableMovement);

			yield return new WaitForSeconds(1f);
			
			LogHeading("Add another tag:");
			gameObject.AddTag(ExampleTag.IsPoisoned);

			Debug.Log($"Checking that tag {ExampleTag.IsPoisoned} was really added...");

			if (gameObject.HasTag(ExampleTag.IsPoisoned))
				Debug.Log($"Object has tag {ExampleTag.IsPoisoned}!");

			yield return new WaitForSeconds(1f);
			
			LogHeading("Example stacking IsPoisoned tags:");
			gameObject.AddTag(ExampleTag.IsPoisoned);
			Debug.Log($"Counting amount of {ExampleTag.IsPoisoned}...");
			var tagsCount = gameObject.CountTags(ExampleTag.IsPoisoned);
			Debug.Log($"Object have {tagsCount} {ExampleTag.IsPoisoned} tags");
			
			yield return new WaitForSeconds(1f);
			
			LogHeading("Tag remove example:");
			gameObject.RemoveTag(ExampleTag.DisableMovement);
			
			yield return new WaitForSeconds(1f);
			
			LogHeading("Checking that 2 tags added in the same time:");
			gameObject.AddTag(ExampleTag.AlternativeAttackEnabled);
			
			var isTwoTags = gameObject.HasAllTags(ExampleTag.IsPoisoned, ExampleTag.AlternativeAttackEnabled);
			Debug.Log($"Is GameObject have {ExampleTag.IsPoisoned} and {ExampleTag.AlternativeAttackEnabled}: {isTwoTags}");

			yield return new WaitForSeconds(1f);
			
			LogHeading("Using global tags example:");
			GlobalTags.Instance.Add(ExampleTag.AlternativeAttackEnabled);
			
			Debug.Log($"Checking that global tag {ExampleTag.AlternativeAttackEnabled} was really added...");
			if (GlobalTags.Instance.Has(ExampleTag.AlternativeAttackEnabled))
				Debug.Log($"Object has tag {ExampleTag.AlternativeAttackEnabled}!");
		}

		void LogHeading(string text) => Debug.Log($"<color=yellow><b>{text}</b></color>");
	}
}