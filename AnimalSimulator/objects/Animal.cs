using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using AnimalSimulator.enums;

namespace AnimalSimulator.objects
{
    class Animal
    {
        public AnimalType type { get; set; }
        public double healthLevel { get; set; } = 100;
        public double foodLevel { get; set; } = 100;
        public double loveLevel { get; set; } = 100;

        public Boolean dead { get; set; } = false;

        public int straveTimes { get; set; } = 0;
        public Boolean straving { get; set; } = false;
        public int nextFoodTime { get; set; } = 0;

        public virtual BitmapImage getAnimalPic()
        {
            return null;
        }

    }
}
