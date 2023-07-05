using System.Net;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private BallViewData data;

        [SerializeField] private ParticleSystem move;
        [SerializeField] private ParticleSystem hit;

        private MeshRenderer ball;
        private TrailRenderer trail;

        public void SetBallMaterial(Material material)
        {
            ball.material = material;

            SaveData();
        }

        public void SetParticlesColor(Color color, bool save = true)
        {
            hit.startColor = color;
            move.startColor = color;

            if (save)
            {
                SaveData();
            }
        }

        public void SetTrail(Color color)
        {
            Gradient newGradient = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[3];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[3];

            colorKeys[0] = new GradientColorKey(color, 0);
            colorKeys[1] = new GradientColorKey(color, .5f);
            colorKeys[2] = new GradientColorKey(color, 1);

            alphaKeys[0] = new GradientAlphaKey(0f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 0.5f);
            alphaKeys[2] = new GradientAlphaKey(0f, 1f);
            
            newGradient.SetKeys(colorKeys, alphaKeys);

            trail.colorGradient = newGradient;

            trail.colorGradient.SetKeys(colorKeys, alphaKeys);

            SaveData();
        }

        private void Awake()
        {
            ball = GetComponent<MeshRenderer>();
            trail = GetComponentInChildren<TrailRenderer>();

            LoadData();
        }

        private void LoadData()
        {
            ball.material = data.FindMaterialByName(SaveSystem.LoadString("BallMaterial"));

            SetParticlesColor(SaveSystem.LoadColor("ParticlesColor"), false);
            SetTrail(PlayerPrefs.HasKey("TrailColor")? SaveSystem.LoadColor("TrailColor"): new Color(1, 1, 1, 0));
        }

        private void SaveData()
        {
            SaveSystem.SaveString("BallMaterial", ball.material.name);

            SaveSystem.SaveColor("ParticlesColor", move.startColor);
            SaveSystem.SaveColor("TrailColor", trail.startColor);
        }
    }
}