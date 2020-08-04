using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum NailShape
    {
        ShapeA,
        ShapeB,
        ShapeC,
        ShapeD,
        ShapeE,
        ShapeF
    }

    public enum Powder
    {
        PowderA,
        PowderB,
        PowderC,
        PowderD,
        PowderE,
        PowderF
    }

    //public enum Sticker
    //{
    //    StickerA,
    //    StickerB,
    //    StickerC,
    //    StickerD,
    //    StickerE,
    //    StickerF
    //}

    //public enum Filling
    //{
    //    FillingA,
    //    FillingB,
    //    FillingC,
    //    FillingD,
    //    FillingE,
    //    FillingF
    //}

    //public enum PaintBrush
    //{
    //    PaintBrushA,
    //    PaintBrushB,
    //    PaintBrushC,
    //    PaintBrushD,
    //    PaintBrushE,
    //    PaintBrushF
    //}

    public enum Interior
    {
        InteriorA,
        InteriorB,
        InteriorC,
        InteriorD,
        InteriorE,
        InteriorF
    }

    public enum Wall
    {
        WallA,
        WallB,
        WallC,
        WallD,
        WallE,
        WallF
    }

    public enum Floor
    {
        FloorA,
        FloorB,
        FloorC,
        FloorD,
        FloorE,
        FloorF
    }

    public struct Item
    {
        public Item(NailShape nailShape)
        {
            mNailShape = nailShape;
            mPowder = null;
        }

        public Item(Powder powder)
        {
            mPowder = powder;
            mNailShape = null;
        }

        public bool IsValid() => IsNailShape() || IsPowder();

        public bool IsNailShape() => mNailShape.HasValue;
        public NailShape NailShape => mNailShape.Value;

        public bool IsPowder() => mPowder.HasValue;
        public Powder Powder => mPowder.Value;

        private NailShape? mNailShape;
        private Powder? mPowder;
    }
}
