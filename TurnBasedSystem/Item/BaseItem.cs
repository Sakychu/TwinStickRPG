using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Item
{
    internal class BaseItem
    {
        private String _name;
        private String _descKey;
        private Image _img = null;
        public String Name { get { return _name; } }
        public String Desc { get { return _descKey; } }
        public Image Image { get { return _img; } }

        internal BaseItem(String name, string desc)
        {
            _name = name;
            _descKey = desc;
            _img = loadImage();
        }

        internal virtual Image loadImage()
        {
            Image img = new Bitmap(64,64);
            try
            {
                img = Image.FromFile($"image\\items\\{_name}.png");
            }
            catch (Exception ex)
            {
                int size = 32;
                var drawingGraphics = Graphics.FromImage(img);
                drawingGraphics.FillRectangle(Brushes.Red, 0, 0, size, size);
                drawingGraphics.DrawRectangle(Pens.Black, 0, 0, size, size);
                int halfHeight = size / 2;
                int halfWidth = size / 2;
                drawingGraphics.DrawRectangle(Pens.Black, 0, 0, halfWidth, halfHeight);
                drawingGraphics.DrawRectangle(Pens.Black, halfWidth, halfHeight, halfWidth, halfHeight);
            }
            return img;
        }

        internal virtual void onGet(BaseUnit me)
        {

        }

        internal virtual void onAttack(BaseUnit me, BaseUnit? other)
        { 
        
        }
        internal virtual void onDamageTaken(BaseUnit me, BaseUnit other, float damage)
        {
        }

        internal virtual void onDamageDealt(BaseUnit me, BaseUnit other, float damage)
        {
        }

        internal virtual void onUnitKilled(BaseUnit me, BaseUnit other)
        {
        }

        internal virtual void onDeath(BaseUnit me)
        {
        }

        static public List<T?> GetDerivedInstances<T>()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(T)) && !type.IsAbstract)
                .Select(type => (T?)Activator.CreateInstance(type))
                .ToList();
        }
    }
}
