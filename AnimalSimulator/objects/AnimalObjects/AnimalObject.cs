using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

using AnimalSimulator.interfaces;
using AnimalSimulator.enums;
using AnimalSimulator.utils;


namespace AnimalSimulator.objects.AnimalObjects
{
    class AnimalObject : Animal, AnimalImpl
    {
        public override BitmapImage getAnimalPic()
        {
            switch (type)
            {
                case AnimalType.Hund:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/hund.png"));
                case AnimalType.Katze:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/katze.png"));
                case AnimalType.Maus:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/maus.png"));
                case AnimalType.Adler:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/adler.png"));
                case AnimalType.Hai:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/hai.png"));
                case AnimalType.Goldfisch:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/goldfisch.png"));
                case AnimalType.Tintenfisch:
                    return new BitmapImage(new Uri("pack://application:,,,/pics/tintenfisch.png"));
                default:
                    return null;
            }
        }

    }
}
