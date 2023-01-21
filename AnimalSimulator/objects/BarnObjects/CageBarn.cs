using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


using AnimalSimulator.enums;

namespace AnimalSimulator.objects.BarnObjects
{
    class CageBarn : Barn
    {
        public CageBarn()
        {
            type = BarnType.Cage;
        }

        public override BitmapImage getBarnPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/Käfig.png"));
        }
    }
}
