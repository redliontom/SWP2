using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

using SWP2.Prototypes;
using SWP2.Command;
using SWP2.Composite;

namespace SWP2
{
    class GraphicsEditor
    {
        private static GraphicsEditor instance = null;

        private Composite.Composite _root;
        private Canvas _scene;

        private ModelShape.type? _type;

        private mode? _mode;
        public enum mode
        {
            Move, Select, Deselect
        };

        private pen _pen;
        public enum pen
        {
            Typ1, Typ2
        };

        private GraphicsEditor()
        {
            _type = ModelShape.type.Square;
            _mode = null;
            _pen = pen.Typ1;
        }

        public static GraphicsEditor GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GraphicsEditor();
                }
                return instance;
            }
        }

        public Composite.Composite Root { get { return _root; } set { _root = value; } }
        public ModelShape.type? Type { get { return _type; } set { _type = value; } }
        public mode? Mode { get { return _mode; } set { _mode = value; } }
        public pen Pen { get { return _pen; } set { _pen = value; } }
        public Canvas Scene { get { return _scene; } set { _scene = value; } }
    }
}
