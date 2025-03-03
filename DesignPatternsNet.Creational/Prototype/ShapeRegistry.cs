using DesignPatternsNet.Common.Drawing;
using System.Collections.Generic;

namespace DesignPatternsNet.Creational.Prototype
{
    /// <summary>
    /// Registry for storing and retrieving prototype shapes
    /// </summary>
    public class ShapeRegistry
    {
        private Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();

        public void RegisterShape(string key, IShape shape)
        {
            _shapes[key] = shape;
        }

        public IShape GetShape(string key)
        {
            if (_shapes.TryGetValue(key, out var shape))
            {
                return shape.Clone();
            }
            return null;
        }

        public IEnumerable<string> GetAvailableShapes()
        {
            return _shapes.Keys;
        }
    }
}
