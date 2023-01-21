using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSimulator.enums;

using System.Windows.Media.Imaging;

namespace AnimalSimulator.objects.AnimalObjects
{
    class Goldfisch : Animal
    {
        public Goldfisch()
        {
            type = AnimalType.Goldfisch;
        }
        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/goldfisch.png"));
        }
    }
}
