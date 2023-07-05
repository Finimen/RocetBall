using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Settings/BallView")]
    public class BallViewData : ScriptableObject
    {
        [SerializeField] private Material[] allMaterials;

        public Material FindMaterialByName(string name)
        {
            name = name.Replace("(Instance)", "");
            name = name.Replace(" ", "");

            foreach (Material material in allMaterials)
            {
                if (material.name == name)
                {
                    return material;
                }
            }

            return allMaterials[0];
        }
    }
}