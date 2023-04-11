using laba_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

using Assert = NUnit.Framework.Assert;

namespace TestProject1
{



    [TestClass]
    public class QuestRoomTests
    {
        [TestMethod]
        public void AddComponent_AddsComponentToList()
        {
            
            var questRoom = new QuestRoom();
            var quest = new Quest();

           
            questRoom.AddComponent(quest);

            
            Assert.That(questRoom.GetComponents(), Has.Member(quest));
        }
    }

}