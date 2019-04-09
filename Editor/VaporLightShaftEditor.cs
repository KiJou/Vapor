﻿using UnityEngine;
using UnityEditor;

namespace VaporAPI {
	[CustomEditor(typeof(VaporLightShaft))]
	[CanEditMultipleObjects]
	public class VaporLightShaftEditor : VaporBaseEditor {
		Editor m_settingEditor;

		[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Active, typeof(VaporLightShaft))]
		static void DrawZoneGizmo(VaporLightShaft zone, GizmoType type) {
			Gizmos.matrix = zone.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(Vector3.zero, zone.Size);
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();

			SettingsField("m_setting", "Physical properties of the fog in this zone", ref m_settingEditor);
			PropertyField("Size", "");
			PropertyField("Radius", "Softening radius");
            PropertyField("ZoneIntensity", "Light Shaft Intensity");
            PropertyField("m_light", "Light Component");
            PropertyField("SpotBaseSize", "Base of the Spotlight");
            PropertyField("fallOffMultiplier", "Fall-Off Multiplier");
            PropertyField("ShadowValue", "Shadow Map Multiplier");
            PropertyField("CustomShadowMap", "Custom Map/Texture");

            serializedObject.ApplyModifiedProperties();
		}

		void OnDisable() {
			if (m_settingEditor != null) {
				DestroyImmediate(m_settingEditor);
			}
		}
	}
}