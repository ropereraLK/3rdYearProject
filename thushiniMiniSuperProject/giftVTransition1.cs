using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thushiniMiniSuperProject
{
   public class giftVTransition1
    {
        private string _text;
        private int _giftPos;

        public giftVTransition1 (string text, int giftPos)
        {
            _text = text;
            _giftPos = giftPos;
        }

        public int CaretPosition
        {
            get { return _giftPos; }
            set { _giftPos = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
