using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class Config
    {
        public const int LEVEL_OF_FIRST_SANDING_APPEARANCE = 3;

        public static readonly int[] LEVELS_PER_MILESTONE =
        {
            3, 3, 4, 5 // 5, 5, 5...
        };

        // Must be in ascending order!
        public static readonly (Item, int)[] ITEM_UNLOCK_LEVELS =
        {
            (new Item(NailShape.ShapeA), 1),
            (new Item(Powder.PowderA), 1),
            (new Item(NailShape.ShapeB), 3),
            (new Item(Powder.PowderB), 5),
            (new Item(NailShape.ShapeC), 9),
            (new Item(Powder.PowderC), 13),
            (new Item(NailShape.ShapeD), 17),
            (new Item(Powder.PowderD), 21),
            (new Item(NailShape.ShapeE), 25),
            (new Item(Powder.PowderE), 29),
            (new Item(NailShape.ShapeF), 33),
            (new Item(Powder.PowderF), 37)
        };

        public static readonly (NailShape, Powder)[] CUSTOMER_REQUESTS =
        {
            (NailShape.ShapeA, Powder.PowderA),
            (NailShape.ShapeA, Powder.PowderA),
            (NailShape.ShapeB, Powder.PowderA),
            (NailShape.ShapeB, Powder.PowderA),
            (NailShape.ShapeB, Powder.PowderB)
        };

        public static readonly int[] INTERIOR_PRICES =
        {
            100, 200, 300
        };

        public static readonly int[] WALL_PRICES =
        {
            150, 250, 350
        };

        public static readonly int[] FLOOR_PRICES =
        {
            200, 300, 400
        };
    }
}
