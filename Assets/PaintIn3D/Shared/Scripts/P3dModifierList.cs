﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PaintIn3D
{
	/// <summary>This class maintains a list of paint modifiers and can apply the modifications to various settings.
	/// This is used by both the in-game and in-editor painting.</summary>
	[System.Serializable]
	public class P3dModifierList : ISerializationCallbackReceiver
	{
		[System.NonSerialized]
		private List<P3dModifier> modifiers;

		[SerializeField]
		private List<string> types;

		[SerializeField]
		private List<string> jsons;

		public int Count
		{
			get
			{
				if (modifiers != null)
				{
					return modifiers.Count;
				}

				return 0;
			}
		}

		public void ModifyAngle(ref float angle, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyAngle(ref angle, pressure);
		}

		public void ModifyColor(ref Color color, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyColor(ref color, pressure);
		}

		public void ModifyHardness(ref float hardness, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyHardness(ref hardness, pressure);
		}

		public void ModifyOpacity(ref float opacity, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyOpacity(ref opacity, pressure);
		}

		public void ModifyRadius(ref float radius, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyRadius(ref radius, pressure);
		}

		public void ModifyTexture(ref Texture texture, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyTexture(ref texture, pressure);
		}

		public void ModifyPosition(ref Vector3 position, bool preview, float pressure)
		{
			if (modifiers != null) foreach (var modifier in modifiers) if (modifier.Preview || !preview) modifier.ModifyPosition(ref position, pressure);
		}

		public void OnAfterDeserialize()
		{
			if (types != null && jsons != null && types.Count == jsons.Count)
			{
				if (modifiers == null)
				{
					modifiers = new List<P3dModifier>();
				}

				for (var i = modifiers.Count; i < types.Count; i++)
				{
					modifiers.Add(default(P3dModifier));
				}

				for (var i = modifiers.Count - 1; i >= 0; i--)
				{
					if (i < types.Count)
					{
						var type     = System.Type.GetType(types[i]);
						var modifier = modifiers[i];

						if (modifier == null || modifier.GetType() != type)
						{
							modifier = modifiers[i] = (P3dModifier)System.Activator.CreateInstance(type);
						}

						JsonUtility.FromJsonOverwrite(jsons[i], modifier);
					}
					else
					{
						modifiers.RemoveAt(i);
					}
				}
			}
		}

		public void OnBeforeSerialize()
		{
			if (types == null) types = new List<string>(); else types.Clear();
			if (jsons == null) jsons = new List<string>(); else jsons.Clear();

			if (modifiers != null)
			{
				foreach (var modifier in modifiers)
				{
					types.Add(modifier.GetType().FullName);
					jsons.Add(JsonUtility.ToJson(modifier));
				}
			}
		}

#if UNITY_EDITOR
		public void DrawEditorLayout(SerializedObject serializedObject, Object target, params string[] groups)
		{
			serializedObject.ApplyModifiedProperties();

			Undo.RecordObject(target, "Paint Modifiers");

			EditorGUI.BeginChangeCheck();

			DrawEditorLayout(true, groups);

			if (EditorGUI.EndChangeCheck() == true)
			{
				EditorUtility.SetDirty(target);
			}
		}

		public void DrawEditorLayout(bool showPreviewAndUnique, params string[] groups)
		{
			if (modifiers != null)
			{
				var remove = default(P3dModifier);

				foreach (var modifier in modifiers)
				{
					var group = (string)modifier.GetType().GetField("Group", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);
					var title = (string)modifier.GetType().GetField("Title", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);

					EditorGUILayout.BeginHorizontal();
						EditorGUILayout.LabelField(group + " / " + title);
						if (showPreviewAndUnique == true)
						{
							modifier.Preview = GUILayout.Toggle(modifier.Preview, new GUIContent("preview", "Should this modifier apply to preview paint as well?"), EditorStyles.miniButtonLeft, GUILayout.Width(50));
							modifier.Unique = GUILayout.Toggle(modifier.Unique, new GUIContent("unique", "Should this modifier use a unique seed?"), EditorStyles.miniButtonMid, GUILayout.Width(50));
						}
						if (GUILayout.Button("x", EditorStyles.miniButtonRight, GUILayout.Width(20)) == true)
						{
							remove = modifier;
						}
					EditorGUILayout.EndHorizontal();

					EditorGUI.indentLevel++;
						modifier.DrawEditorLayout();
					EditorGUI.indentLevel--;

					EditorGUILayout.Separator();
				}

				modifiers.Remove(remove);
			}

			if (GUILayout.Button("Add Modifier") == true)
			{
				var menu  = new GenericMenu();
				var types = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => typeof(P3dModifier).IsAssignableFrom(t) && t != typeof(P3dModifier));

				foreach (var type in types)
				{
					var addType  = type;
					var addGroup = (string)type.GetField("Group", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);
					var addTitle = (string)type.GetField("Title", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);

					if (groups != null && groups.Length > 0 && groups.Contains(addGroup) == false)
					{
						continue;
					}

					menu.AddItem(new GUIContent(addGroup + "/" + addTitle + " (" + type.Name + ")"), false, () =>
					{
						if (modifiers == null)
						{
							modifiers = new List<P3dModifier>();
						}

						modifiers.Add((P3dModifier)System.Activator.CreateInstance(addType));
					});
				}

				menu.ShowAsContext();
			}
		}
#endif
	}
}