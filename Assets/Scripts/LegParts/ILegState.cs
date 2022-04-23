using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController
{
    /// <summary>
    /// 脚部パーツのステート
    /// </summary>
    public interface ILegState
    {
        /// <summary>
        /// ステート開始時
        /// </summary>
        /// <param name="control"></param>
        void OnEnter(LegControl control);
        /// <summary>
        /// ステートUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(LegControl control);
        /// <summary>
        /// ステート移動関係Update
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(LegControl control);
    }
}