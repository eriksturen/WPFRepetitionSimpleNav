using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRepetition.Models
{
    public class DataModel
    {
        private int _counter;
        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;
            }
        }

    }
}
