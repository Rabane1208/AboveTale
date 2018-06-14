using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace AT.Object
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float distance = 10f;
        [SerializeField] private float angle = 30f;

        private CameraModel Model { get; set; }

        private void Start()
        {
            Model = new CameraModel(moveSpeed);

            InitMove(Model);
        }

        private void InitMove(CameraModel model)
        {
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);

            var cameraPos = distance * new Vector3(0, Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
            Observable.EveryUpdate()
                .Select(_ => target.transform.position)
                .DistinctUntilChanged()
                .Subscribe(targetPos => transform.localPosition = targetPos + cameraPos);
        }
    }
}