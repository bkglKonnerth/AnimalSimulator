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


        public virtual void feedAnimal(int amount)
        {
            foodLevel += amount;
        }
        public virtual void healAnimal(int amount)
        {
            healthLevel += amount;
        }
        public virtual void loveAnimal(int amount)
        {
            loveLevel += amount;

        }
        public virtual void removeFeed(int amount)
        {
            foodLevel -= amount;
        }
        public virtual void removeHeal(int amount)
        {
            healthLevel -= amount;
        }
        public virtual void removeLove(int amount)
        {
            loveLevel -= amount;
        }


        public virtual BitmapImage getAnimalPic()
        {
            return null;
        }

    }
}
