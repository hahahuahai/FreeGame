using Loxodon.Framework.Asynchronous;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public interface IPlayerService 
    {
        void SetPlayerData(PlayerModel playerModel);
        PlayerModel GetPlayerData();
    }

}
