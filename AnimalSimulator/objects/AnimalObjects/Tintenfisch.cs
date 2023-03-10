using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSimulator.enums;

using System.Windows.Media.Imaging;

namespace AnimalSimulator.objects.AnimalObjects
{
    class Tintenfisch : Animal
    {
        public Tintenfisch()
        {
            type = AnimalType.Tintenfisch;
            feedCash = 240;
            strokeCash = 400;
        }
        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/tintenfisch.png"));
        }
    }
}
