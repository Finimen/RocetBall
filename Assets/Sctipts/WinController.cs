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
using FinimenSniperC.RollerBall;
using FinimenSniperC.Level;
using System.Collections;

namespace FinimenSniperC
{
    [DisallowMultipleComponent]
    internal class WinController : MonoBehaviour
    {
        [SerializeField] private LevelData currentLevel;

        [SerializeField] private UIArrayAlphaController[] canvases;
        [SerializeField] private UIArrayAlphaController winText;

        [SerializeField] private int allBotsCount;

        [SerializeField] private int damagedBotsCount;

        private BallUserControl player;

        private Vector3 ballStartPosition;

        public bool IsCompleted { get; private set; }

        public LevelData LevelData { get { return currentLevel; } }

        private void Awake()
        {
            player = FindObjectOfType<BallUserControl>();

            ballStartPosition = player.transform.position;

            StartKeyMode();
        }

        private void Start()
        {
            DeadZone[] deadZones = FindObjectsOfType<DeadZone>();

            foreach (DeadZone deadZone in deadZones)
            {
                deadZone.OnPlayerEnter += ResetPositionForPlayer;
            }
        }

        #region HIT_ALL_BOTS_MODE
        private void StartHitAllBotsMode()
        {
            BotController[] allBots = FindObjectsOfType<BotController>();

            allBotsCount = allBots.Length;

            foreach (BotController botController in allBots)
            {
                botController.OnGetDamage += IncreaseDamagedBotsCount;
            }
        }

        private void IncreaseDamagedBotsCount()
        {
            damagedBotsCount++;

            CheckWinProgers();
        }
        #endregion

        #region KEY_MODE
        private void StartKeyMode()
        {
           FindObjectOfType<Key>().OnPlayerEntered += CompleteLevel;
        }
        #endregion

        private void CheckWinProgers()
        {
            if (allBotsCount == damagedBotsCount)
            {
                CompleteLevel();
            }
        }

        private void CompleteLevel()
        {
            StartCoroutine(ShowWinText());

            currentLevel.Complete();

            player.enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            foreach (var canvas in canvases)
            {
                canvas.SetArrayAlpha(0);
            }

            IsCompleted = true;
        }

        private IEnumerator ShowWinText()
        {
            FindObjectOfType<ScoreManager>().SubmitScore();

            yield return new WaitForSeconds(.5f);

            winText.SetArrayAlpha(1);

            yield return new WaitForSeconds(1.25f);

            winText.SetArrayAlpha(0);

            yield return new WaitForSeconds(1);

            var leaderbordUI = FindObjectOfType<LeaderbordUI>(true);
            leaderbordUI.Show();
            leaderbordUI.Close.onClick.AddListener(() =>
            UIController.Instance.ShowWinIcon());
        }

        private void ResetPositionForPlayer()
        {
            player.transform.position = ballStartPosition;
        }
    }
}