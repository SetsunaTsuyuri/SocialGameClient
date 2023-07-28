using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using MD;

namespace Outgame
{
    /// <summary>
    /// イベントホーム画面ビュー
    /// </summary>
    public class UIEventView : UIStackableView
    {
        [SerializeField]
        GameObject _goEventQuestButtonObject = null;

        [SerializeField]
        TextMeshProUGUI _eventTitleText = null;

        protected override void AwakeCall()
        {
            ViewId = ViewID.Event;
        }

        public override void Enter()
        {
            base.Enter();

            // イベント開催中のみボタンを表示する
            int eventId = EventHelper.GetAllOpenedEvent().FirstOrDefault();
            bool isEventOpen = EventHelper.IsEventOpen(eventId);
            _goEventQuestButtonObject.SetActive(isEventOpen);

            // イベントタイトルを表示する
            GameEvent gameEvent = MasterData.GetEvent(eventId);
            _eventTitleText.text = gameEvent.Name;
        }

        public void Back()
        {
            UIManager.Back();
        }

        public void GoEventQuest()
        {
            UIManager.NextView(ViewID.EventQuest);
        }

        public void GoRanking()
        {
            UIManager.NextView(ViewID.Ranking);
        }
    }
}
