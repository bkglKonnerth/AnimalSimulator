using System.Collections.Generic;

using AnimalSimulator.objects;

namespace AnimalSimulator.utils
{
    class GameManager
    {
        public static User user = new User();

        public static List<Animal> animalContainer = new List<Animal>();
        public static List<Barn> barnContainer = new List<Barn>();

        public static int page = 1;

    }

}
