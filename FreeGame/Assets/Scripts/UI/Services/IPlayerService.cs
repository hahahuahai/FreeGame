using Loxodon.Framework.Asynchronous;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public interface IPlayerService 
    {
        void SetPlayerModel(PlayerModel playerModel);
        void SetPlayerScore(int score);
        void SetPlayerPosition(Vector3 position);
        void SetPlayerRotation(Vector3 rotation);
        PlayerModel GetPlayerData();
        void ClearPlayerData();
    }

}
