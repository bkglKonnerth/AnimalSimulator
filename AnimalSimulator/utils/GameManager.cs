using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using AnimalSimulator.objects;
using AnimalSimulator.objects.AnimalObjects;

namespace AnimalSimulator.utils
{
    class GameManager
    {
        public static User user = new User();

        public static List<Animal> animalContainer = new List<Animal>();

    }

}
