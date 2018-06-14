using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace AT.Object
{
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private float rotateSpeed = 5;

        private PlayerView View { get { return GetComponent<PlayerView>(); } }
        private Rigidbody Rigid { get { return GetComponent<Rigidbody>(); } }
        private PlayerModel Model { get; set; }

        void Start()
        {
            Model = new PlayerModel(moveSpeed, rotateSpeed);

            InitMove(Model);
        }

        // TODO: 移動クラスを作ろうかな
        private void InitMove(PlayerModel model)
        {
            View.OnDir.Where(dir => dir != Vector3.zero)
                .Subscribe(dir =>
                {
                    Rigid.position += dir * model.MoveSpeed * Time.deltaTime;
                    Rigid.rotation = Quaternion.Lerp(Rigid.rotation, Quaternion.LookRotation(dir), model.RotateSpeed * Time.deltaTime);
                }).AddTo(this);
        }
    }
}