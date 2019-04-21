using NUnit.Framework;
using THA.Domain;

namespace Tests
{
    public class AnalyserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CharacterFail()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"Session data: From 2019-04-20, 12:04:24 to 2019-04-20, 12:22:37 Session: 00:18h XP Gain: 66 XP / h: 0 Loot: 0 Supplies: 20 Balance: -20 Damage: 90 Damage / h: 90 Healing: 0 Healing / h: 0 Killed Monsters: 3x cave rat Looted items: None");
            Assert.IsEmpty(analyser.Character);
        }

        [Test]
        public void CharacterSucess()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"12:34 Gabi Tolentino [200]: Session data: From 2019-04-20, 12:32:59 to 2019-04-20, 12:33:42 Session: 00:00h XP Gain: 79 XP/h: 622 Loot: 0 Supplies: 114 Balance: -114 Damage: 120 Damage/h: 120 Healing: 0 Healing/h: 0 Killed Monsters: 1x crazed beggar Looted items: None");
            Assert.IsNotEmpty(analyser.Character);
        }

        [Test]
        public void SessionSucess()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"12:34 Gabi Tolentino [200]: Session data: From 2019-04-20, 12:32:59 to 2019-04-20, 12:33:42 Session: 00:00h XP Gain: 79 XP/h: 622 Loot: 0 Supplies: 114 Balance: -114 Damage: 120 Damage/h: 120 Healing: 0 Healing/h: 0 Killed Monsters: 1x crazed beggar Looted items: None");
            Assert.IsNotEmpty(analyser.Session);
        }

        [Test]
        public void SessionLoot()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"12:34 Gabi Tolentino [200]: Session data: From 2019-04-20, 17:07:45 to 2019-04-20, 19:27:49 Session: 02:20h XP Gain: 1,106,897 XP/h: 144,992 Loot: 341,709 Supplies: 191,138 Balance: 150,571 Damage: 368,163 Damage/h: 232,074 Healing: 246,416 Healing/h: 107,992 Killed Monsters: 46x");
            Assert.NotZero(analyser.Loot);
        }

        [Test]
        public void SessionSuplies()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"12:34 Gabi Tolentino [200]: Session data: From 2019-04-20, 17:07:45 to 2019-04-20, 19:27:49 Session: 02:20h XP Gain: 1,106,897 XP/h: 144,992 Loot: 341,709 Supplies: 191,138 Balance: 150,571 Damage: 368,163 Damage/h: 232,074 Healing: 246,416 Healing/h: 107,992 Killed Monsters: 46x");
            Assert.NotZero(analyser.Suplies);
        }

        [Test]
        public void SessionBalance()
        {
            Analyser analyser = new Analyser();
            analyser.Compute(@"12:34 Gabi Tolentino [200]: Session data: From 2019-04-20, 17:07:45 to 2019-04-20, 19:27:49 Session: 02:20h XP Gain: 1,106,897 XP/h: 144,992 Loot: 341,709 Supplies: 191,138 Balance: 150,571 Damage: 368,163 Damage/h: 232,074 Healing: 246,416 Healing/h: 107,992 Killed Monsters: 46x");
            Assert.NotZero(analyser.Balance);
        }
    }
}