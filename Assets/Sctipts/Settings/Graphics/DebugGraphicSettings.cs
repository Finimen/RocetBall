using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DebugGraphicSettings : MonoBehaviour
{
    [SerializeField] private GameObject particels;
    [SerializeField] private MonoBehaviour fastPostProcessing;

    private PostEffectsBase[] postEffects;
    private ShaderSelecter shaderSelecter;

    private bool postProcessingState = true;
    private bool particlesState = true;
    private bool fastPostProcessingState;

    private void Awake()
    {
        postEffects = FindObjectsOfType<PostEffectsBase>();
        shaderSelecter = FindObjectOfType<ShaderSelecter>(true);
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        if(fastPostProcessing != null)
        {
            if (GUILayout.Button(nameof(UpdatePostProcessing)))
            {
                UpdatePostProcessing();
            }

            if (GUILayout.Button("DisabelBloom"))
            {
                fastPostProcessing.GetComponent<PostProcessor>().Settings.BloomEnabled = false;
            }
        }
        
        if (GUILayout.Button(nameof(UpdateParticels)))
        {
            UpdateParticels();
        }

        if(shaderSelecter != null)
        {
            if(GUILayout.Button("LowShader"))
            {
                shaderSelecter.UpdateShaders(false);
            }
        }

        GUILayout.EndHorizontal();
    }

    private void UpdatePostProcessing()
    {
        postProcessingState = !postProcessingState;

        foreach (var effect in postEffects)
        {
            effect.enabled = postProcessingState;
        }
    }

    private void UpdateFastPostProcessing()
    {
        fastPostProcessingState = !fastPostProcessingState;

        fastPostProcessing.enabled = fastPostProcessingState;
    }

    private void UpdateParticels()
    {
        particlesState = !particlesState;

        particels.gameObject.SetActive(particlesState);
    }
}