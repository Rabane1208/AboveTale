using System;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace AT.Object
{
    public class PlayerView : MonoBehaviour
    {
        public IObservable<Vector3> OnDir { get { return Observable.EveryUpdate().Select(_ => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized); } }
        public IObservable<float> OnHorizontal { get { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Horizontal")); } }
        public IObservable<float> OnVertical { get { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Vertical")); } }
    }
}