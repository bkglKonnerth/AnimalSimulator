using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnimalSimulator.enums;

using System.Windows.Media.Imaging;

namespace AnimalSimulator.objects.AnimalObjects
{

    //Animal animal = new Adler();

    class Adler : Animal
    {
        public Adler()
        {
            type = AnimalType.Adler;
            feedCash = 120;
            strokeCash = 200;
        }   


        public override BitmapImage getAnimalPic()
        {
            return new BitmapImage(new Uri("pack://application:,,,/pics/adler.png"));
        }
    }
}
