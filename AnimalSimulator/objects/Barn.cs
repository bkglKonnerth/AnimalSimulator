using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using AnimalSimulator.enums;

namespace AnimalSimulator.objects
{
    class Barn
    {
        public BarnType type { get; set; }

        public virtual BitmapImage getBarnPic()
        {
            return null;
        }
    }
}
