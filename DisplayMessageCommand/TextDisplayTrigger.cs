using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;

namespace Celeste.Mod.DisplayMessageCommand {
    [CustomEntity("DisplayMessageCommand/TextDisplayTrigger")]
    public class TextDisplayTrigger : Trigger {
        private readonly string id;
        private readonly string text;
        private readonly float scale;
        private readonly float y;
        private readonly bool isLeft;
        private readonly float duration;
        private readonly bool onlyOnce;
        private readonly Color fillColor;
        private readonly bool useRawDeltaTime;

        public TextDisplayTrigger(EntityData data, Vector2 levelOffset) : base(data, levelOffset) {
            id = data.Attr("textID");
            text = data.Attr("message");
            scale = data.Float("scale");
            y = data.Float("yPosition");
            isLeft = data.Bool("isLeft");
            duration = data.Float("duration");
            onlyOnce = data.Bool("onlyOnce");
            fillColor = data.HexColor("fillColor", Color.White);
            useRawDeltaTime = data.Bool("useRawDeltaTime");
        }

        public override void OnEnter(Player p) {
            TextDisplayInLevel.displayMessageCommand(id, scale, y, isLeft, text, duration, fillColor, useRawDeltaTime);
            if (onlyOnce) {
                RemoveSelf();
            }
        }
    }
}
