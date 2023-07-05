/*               
            ░███████╗██╗███╗░░██╗██╗██╗░░░░░██╗███████╗███╗░░██╗   ░██████╗███╗░░██╗██╗██████╗░███████╗██████╗░░
			░██╔════╝██║████╗░██║██║████░░████║██╔════╝████╗░██║   ██╔════╝████╗░██║██║██╔══██╗██╔════╝██╔══██╗░
			░███████╗██║██╔██╗██║██║██║░██░░██║█████╗░░██╔██╗██║   ╚█████╗░██╔██╗██║██║██████╔╝█████╗░░██████╔╝░
			░██╔════╝██║██║╚████║██║██║░░░░░██║██╔══╝░░██║╚████║   ░╚═══██╗██║╚████║██║██╔═══╝░██╔══╝░░██╔══██╗░
			░██║░░░░░██║██║░╚███║██║██║░░░░░██║███████╗██║░╚███║   ██████╔╝██║░╚███║██║██║░░░░░███████╗██║░░██║░
			░╚═╝░░░░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝   ╚═════╝░╚═╝░░╚══╝╚═╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝░
____________________________________________________________________________________________________________________________________________
                █▀▀▄ █──█ 　 ▀▀█▀▀ █──█ █▀▀ 　 ░█▀▀▄ █▀▀ ▀█─█▀ █▀▀ █── █▀▀█ █▀▀█ █▀▀ █▀▀█ 
                █▀▀▄ █▄▄█ 　 ─░█── █▀▀█ █▀▀ 　 ░█─░█ █▀▀ ─█▄█─ █▀▀ █── █──█ █──█ █▀▀ █▄▄▀ 
                ▀▀▀─ ▄▄▄█ 　 ─░█── ▀──▀ ▀▀▀ 　 ░█▄▄▀ ▀▀▀ ──▀── ▀▀▀ ▀▀▀ ▀▀▀▀ █▀▀▀ ▀▀▀ ▀─▀▀
____________________________________________________________________________________________________________________________________________
*/
using UnityEngine;

namespace FinimenSniperC.Level
{
    [CreateAssetMenu]
    internal class LevelData : ScriptableObject , ILevelData
    {
        [SerializeField] private bool completed;

        [SerializeField] private bool unlocked;

        [SerializeField] private LevelData nextLevel;

        public bool Completed 
        {
            get 
            { 
                return SaveSystem.LoadBool(saveComplete);
            }
        }
        public bool Unlocked
        {
            get
            {
                return saveUnlock == "Level0Unlock"? true : SaveSystem.LoadBool(saveUnlock);
            }
        }

        private string saveUnlock
        {
            get
            {
                return name + "Unlock";
            }
        }

        private string saveComplete
        {
            get
            {
                return name + "Complete";
            }
        }

        public void Unlock()
        {
            if (!SaveSystem.LoadBool(saveUnlock))
            {
                SaveSystem.SaveBool(saveUnlock, true);
            }
            else
            {
                throw new System.Exception("Level is completed, why unlock?");
            }
        }

        public void Complete()
        {
            if (!SaveSystem.LoadBool(saveUnlock))
            {
                Unlock();
            }

            if (SaveSystem.LoadBool(saveUnlock))
            {
                SaveSystem.SaveBool(saveComplete, true);

                SaveSystem.SaveBool(nextLevel.saveUnlock, true);
            }
        }

        [ContextMenu("SaveData")]
        private void SaveData()
        {
            SaveSystem.SaveBool(saveUnlock, unlocked);
            SaveSystem.SaveBool(saveComplete, completed);

            Debug.Log("DataSeved");
        }

        [ContextMenu("UpdateData")]
        private void UpdateData()
        {
            unlocked = SaveSystem.LoadBool(saveUnlock);
            completed = SaveSystem.LoadBool(saveComplete);
        }
    }
}