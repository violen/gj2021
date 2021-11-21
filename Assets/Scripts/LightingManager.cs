using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private void Update() {
        if (preset == null) {
            return;
        }
        if (Application.isPlaying) {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24; // clamp 0-24
            UpdateLighting(timeOfDay / 24f);
        }
    }

    public bool IsDayTime() {
        if (timeOfDay >= 7 && timeOfDay <= 20) 
            return true;
        return false;
    }

    private void UpdateLighting(float timeOfDay) {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timeOfDay);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timeOfDay);

        if (directionalLight != null) {
            directionalLight.color = preset.directionalColor.Evaluate(timeOfDay);

            // turn light direction
            directionalLight.transform.localRotation = Quaternion.Euler(
                new Vector3((timeOfDay * 360f) - 90f, 170f, 0)
            );
        }
    }

    private void OnValidate() {
        if (directionalLight != null)
        {
            return;
        }

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        } 
        else
        {
            Light[] lights = FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional) {
                    directionalLight = light;
                    return;
                }
             }
        }
    }
}
