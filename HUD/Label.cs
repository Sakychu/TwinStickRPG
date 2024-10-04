using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.HUD
{
    internal class Label
    {
        private String _text;
        //internal String size;

        internal Vector2 position;
        internal Vector2 velo = new Vector2(0,0);
        internal bool shouldRemove;

        public Label(string text, Vector2 position, int maxLife = 0)
        {
            _text = text;
            this.position = position;
            MaxLife = maxLife;
        }

        public SizeF getSize(Graphics g, Font f)
        {
            SizeF size = g.MeasureString(_text, f);
            return size;
        }

        public Vector2 Position { get { return position; } }

        public string Text { get => _text; set => _text = value; }
        public int Life { get; internal set; }
        public int MaxLife { get; internal set; }
    }
}
