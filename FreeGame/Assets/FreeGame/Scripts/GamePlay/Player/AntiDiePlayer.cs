using Loxodon.Framework.Contexts;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FreeGame
{
    public class AntiDiePlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) //按下P键，防卡死
            {
                ChangePosition2StartingPlace();
            }
        }

        private void ChangePosition2StartingPlace()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                gameObject.transform.position = Consts.PlayerStartingPosition;
                gameObject.SetActive(true);
            }

        }

    }

}
