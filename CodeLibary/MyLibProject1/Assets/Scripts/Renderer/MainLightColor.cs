using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var light = GetComponent<Light>();
        if (light == null)
        {
            Debug.LogError(gameObject.name + "没有光源组件");
            return;
        }
        var intensity = light.intensity;
        Shader.SetGlobalColor("_MainLightColor", new Color(light.color.r * intensity, light.color.g * intensity, light.color.b * intensity, 1));
    }

    void OnDestroy()
    {
        Shader.SetGlobalColor("_MainLightColor", new Color(0, 0, 0, 0));
    }
}
