using System;
using UnityEditor;
using UnityEngine;

namespace InsaneOne.Tags.Dev
{
	[CustomEditor(typeof(MonoTags), true)]
	public class MonoTagsEditor : Editor
	{
		public override void OnInspectorGUI()
		{	
			if (!Application.isPlaying)
			{
				DrawNotify("Tags active only in runtime", MessageType.Info);
				return;
			}
			
			if (!TagsSettings.IsInited)
			{
				DrawNotify("TagsSettings is not initialized", MessageType.Warning);
				return;
			}
			
			DrawTags(target as MonoTags);
		}

		static void DrawNotify(string text, MessageType messageType)
		{
			GUILayout.BeginVertical();
			EditorGUILayout.HelpBox(text, messageType);
			GUILayout.EndVertical();
		}

		static void DrawTags(MonoTags monoTags)
		{
			if (!monoTags)
				DrawNotify("MonoTags is null. Some error occured.", MessageType.Error);

			GUILayout.BeginVertical();

			var tagsList = monoTags.Tags.GetTagsInternal();

			var tagStyle = new GUIStyle(EditorStyles.boldLabel);
			tagStyle.padding = new RectOffset(5, 5, 5, 5);
			
			foreach (var keyValuePair in tagsList)
			{
				var tagName = keyValuePair.Key.ToString();
				
				tagName = Enum.Parse(TagsSettings.TagsType, tagName).ToString();
				GUILayout.Label($"{tagName} [{keyValuePair.Value}]", tagStyle);
			}

			if (tagsList.Count == 0)
				DrawNotify("No tags on this object.", MessageType.Info);

			GUILayout.EndVertical();
		}
	}
}