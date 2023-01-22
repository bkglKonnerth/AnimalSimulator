using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSimulator.enums;

using System.Windows.Media.Imaging;

namespace AnimalSimulator.objects.AnimalObjects
{
    class Hund : Animal
    {
        public Hund()
        {
            type = AnimalType.Hund;
            strokeCash = 25;
            feedCash = 15;
        }
        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/hund.png"));
        }
    }

}
