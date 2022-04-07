using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GButton : Button 
{
   #region 点击缩放动画
   public bool scaleAnim = false;
   public Vector3 clickDownScale = new Vector3(0.95f,0.95f,1f);
   public Vector3 normalScale = Vector3.one;
   #endregion
   
   #region  声音播放
   public bool sound = false;
   public AudioClip clickEffect;
   #endregion

   public override void OnPointerDown(PointerEventData eventData)
   {
      base.OnPointerDown(eventData);
      if (scaleAnim)
         transform.localScale = clickDownScale;
   }

   public override void OnPointerUp(PointerEventData eventData)
   {
      base.OnPointerUp(eventData);
      if (scaleAnim)
         transform.localScale = normalScale;
   }

   public override void OnPointerClick(PointerEventData eventData)
   {
      base.OnPointerClick(eventData);
      if (sound && clickEffect != null)
      {
         Debug.LogError("PlayAudioEffect");
      }
   }
}
