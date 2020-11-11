﻿using Engine.UI;
using UnityEngine;

namespace DayChangeSystem.Controllers
{
   public class DayCounterPresenter : IAttachableUi 
   {
      private readonly DayCounterView _view;

      public DayCounterPresenter(DayCounterView view)
      {
         _view = view;
      }

      public void SetDay(string value)
      {
         _view.DayText.text = value;
      }

      public void SetSeason(string value)
      {
         _view.SeasonText.text = value;
      }
   
      public void Attach(Transform parent)
      {
         _view.Attach(parent);
      }
   }
}