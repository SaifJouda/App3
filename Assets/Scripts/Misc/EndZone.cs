using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saif.Scoreboards
{
    public class EndZone : MonoBehaviour
    {
        public GameObject gameController;
        void OnTriggerStay2D(Collider2D other)
        {
            if(other.tag=="Player")
                gameController.GetComponent<GameController>().GameEnd();
            //other.GetComponent<EnemyDamageControl>().ChangeHealth(-1);
        }
    }
}