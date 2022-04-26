using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BodyController
{
    /// <summary>
    /// 胴体パーツのステート
    /// </summary>
    public interface IBodyState
    {
        /// <summary>
        /// ステート開始時
        /// </summary>
        /// <param name="control"></param>
        void OnEnter(BodyController control);
        /// <summary>
        /// ステートUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(BodyController control);
        /// <summary>
        /// ステート移動関係Update
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(BodyController control);
    }
}