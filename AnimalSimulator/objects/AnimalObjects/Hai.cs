using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnimalSimulator.enums;

using System.Windows.Media.Imaging;

namespace AnimalSimulator.objects.AnimalObjects
{
    class Hai : Animal
    {
        public Hai()
        {
            type = AnimalType.Hai;
            strokeCash = 60;
            feedCash = 100;
        }
        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/hai.png"));
        }
    }
}
