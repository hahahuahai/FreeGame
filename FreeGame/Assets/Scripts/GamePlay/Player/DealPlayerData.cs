using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FreeGame
{
    public class DealPlayerData : MonoBehaviour
    {
        public GameObject Player;

        IPlayerService playerService;

        private void Start()
        {
            ApplicationContext applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            playerService = container.Resolve<IPlayerService>();

            PlayerModel playerModel = playerService.GetPlayerData();
            Debug.Log("playerModel.Score:" + playerModel.Score);
            Debug.Log("playerModel.Position:" + playerModel.Position);
            Debug.Log("playerModel.Rotation:" + playerModel.Rotation);

            Player.transform.localPosition = playerModel.Position;
            Player.transform.localRotation = Quaternion.Euler(playerModel.Rotation);
            Debug.Log("Player.transform.localPosition:" + Player.transform.localPosition);

            Player.SetActive(true);
        }

        private void OnDestroy()
        {
            playerService.SetPlayerPosition(Player.transform.localPosition);
            playerService.SetPlayerRotation(Player.transform.localRotation.eulerAngles);
        }
    }

}