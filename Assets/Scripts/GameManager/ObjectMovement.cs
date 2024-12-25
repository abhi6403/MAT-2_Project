using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InifinityJumper.Game
{
    public class ObjectMovement : MonoBehaviour
    {
        public float moveSpeed;
        [SerializeField]
        private Vector3 moveDirection;

        [SerializeField] private Vector3 destroyPosition;

        private void Update()
        {
            ItemMovement();
            DestroyItem();
        }
        private void ItemMovement()
        {
            var step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, step);
        }

        private void DestroyItem()
        {
            if (transform.position.x == destroyPosition.x)
            {
                Destroy(gameObject);
            } else if (transform.position.y == destroyPosition.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
