﻿using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
   public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");


        }

        private void Update()
        {
            
            if (InAttackRangeOfPlayer()  && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();

            }
        }

        private bool InAttackRangeOfPlayer()
        {

            float distanceToPLayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPLayer < chaseDistance;
        }
    }
}
