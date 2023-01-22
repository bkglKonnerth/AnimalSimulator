using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using AnimalSimulator.enums;

namespace AnimalSimulator.objects.AnimalObjects
{
    class Maus : Animal
    {
        public Maus()
        {
            type = AnimalType.Maus;
            feedCash = 15;
            strokeCash = 25;
        }
        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/maus.png"));
        }
    }
}
