using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using AnimalSimulator.enums;

namespace AnimalSimulator.objects.BarnObjects
{
    class WaterBarn : Barn
    {
        public WaterBarn() 
        {
            type = BarnType.Water;    
        }

        public override BitmapImage getBarnPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/Aquarium.png"));
        }
    }
}
