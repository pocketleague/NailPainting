using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Game
{
    // Tests are overspecified and rely on the exact configuration
    // TODO: Remove...
    public static class ProgressUtilsTests
    {
        [Test]
        public static void TestMilestoneFromLevel()
        {
            Assert.AreEqual(1, ProgressUtils.GetMilestoneFromLevel(1));
            Assert.AreEqual(1, ProgressUtils.GetMilestoneFromLevel(3));
            Assert.AreEqual(2, ProgressUtils.GetMilestoneFromLevel(4));
            Assert.AreEqual(2, ProgressUtils.GetMilestoneFromLevel(6));
            Assert.AreEqual(3, ProgressUtils.GetMilestoneFromLevel(7));
            Assert.AreEqual(3, ProgressUtils.GetMilestoneFromLevel(10));
            Assert.AreEqual(4, ProgressUtils.GetMilestoneFromLevel(11));
            Assert.AreEqual(4, ProgressUtils.GetMilestoneFromLevel(15));
            Assert.AreEqual(5, ProgressUtils.GetMilestoneFromLevel(16));
            Assert.AreEqual(5, ProgressUtils.GetMilestoneFromLevel(20));
            Assert.AreEqual(6, ProgressUtils.GetMilestoneFromLevel(21));
            Assert.AreEqual(6, ProgressUtils.GetMilestoneFromLevel(25));
        }

        [Test]
        public static void TestFirstLevelOfMilestone()
        {
            Assert.AreEqual(1, ProgressUtils.GetFirstLevelOfMilestone(1));
            Assert.AreEqual(4, ProgressUtils.GetFirstLevelOfMilestone(2));
            Assert.AreEqual(7, ProgressUtils.GetFirstLevelOfMilestone(3));
            Assert.AreEqual(11, ProgressUtils.GetFirstLevelOfMilestone(4));
            Assert.AreEqual(16, ProgressUtils.GetFirstLevelOfMilestone(5));
            Assert.AreEqual(21, ProgressUtils.GetFirstLevelOfMilestone(6));
        }

        [Test]
        public static void TestLevelOfLastItemUnlock()
        {
            Assert.AreEqual(1, ProgressUtils.GetLevelOfLastItemUnlock(1));
            Assert.AreEqual(1, ProgressUtils.GetLevelOfLastItemUnlock(2));
            Assert.AreEqual(3, ProgressUtils.GetLevelOfLastItemUnlock(3));
            Assert.AreEqual(3, ProgressUtils.GetLevelOfLastItemUnlock(4));
            Assert.AreEqual(5, ProgressUtils.GetLevelOfLastItemUnlock(5));
            Assert.AreEqual(5, ProgressUtils.GetLevelOfLastItemUnlock(8));
            Assert.AreEqual(9, ProgressUtils.GetLevelOfLastItemUnlock(9));
            Assert.AreEqual(37, ProgressUtils.GetLevelOfLastItemUnlock(50));
        }

        [Test]
        public static void TestNextItemToUnlock()
        {
            Assert.AreEqual((new Item(NailShape.ShapeB), 3), ProgressUtils.GetNextItemToUnlock(1));
            Assert.AreEqual((new Item(NailShape.ShapeB), 3), ProgressUtils.GetNextItemToUnlock(2));
            Assert.AreEqual((new Item(Powder.PowderB), 5), ProgressUtils.GetNextItemToUnlock(3));
            Assert.AreEqual((new Item(Powder.PowderB), 5), ProgressUtils.GetNextItemToUnlock(4));
            Assert.AreEqual((new Item(Powder.PowderF), 37), ProgressUtils.GetNextItemToUnlock(36));
            Assert.AreEqual((new Item(), 37), ProgressUtils.GetNextItemToUnlock(37));
        }

        [Test]
        public static void TestItemToUnlockOnLevel()
        {
            Assert.AreEqual(new Item(NailShape.ShapeB), ProgressUtils.GetItemToUnlockOnLevel(2));
            Assert.AreEqual(new Item(), ProgressUtils.GetItemToUnlockOnLevel(3));
            Assert.AreEqual(new Item(Powder.PowderB), ProgressUtils.GetItemToUnlockOnLevel(4));
        }
    }
}
