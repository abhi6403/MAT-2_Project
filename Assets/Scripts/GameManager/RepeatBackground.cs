using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace UI
{
    namespace Background
    {
        public class RepeatBackground : MonoBehaviour
        {
            private Vector3 startPos;
            private float repeatHeight;
            [SerializeField]
            private float speed = 30;

            private void Start()
            {
                startPos = transform.position;
                repeatHeight = GetComponent<BoxCollider2D>().size.y / 2;
            }

            private void Update()
            {
                PositionUpdate();
                MoveDown();
            }

            private void PositionUpdate()
            {
                if (transform.position.y < startPos.y - repeatHeight)
                {
                    transform.position = startPos;
                }
            }

            private void MoveDown()
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
        }
    }
}

