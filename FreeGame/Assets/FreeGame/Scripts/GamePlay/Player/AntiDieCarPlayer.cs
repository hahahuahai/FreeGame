using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public class AntiDieCarPlayer : MonoBehaviour
    {


        // Update is called once per frame
        void Update()
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
                gameObject.transform.position = Consts.CarPlayerStartingPosition;
                gameObject.SetActive(true);
            }
        }
    }

}
