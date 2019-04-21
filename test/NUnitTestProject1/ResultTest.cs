using NUnit.Framework;
using THA.Domain;

namespace NUnitTestProject1
{
    public class ResultTest
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void ProfitPositive()
        {
            Result result = new Result();
            result.FirstAnalysers = new Analyser();
            result.FirstAnalysers.Message = @"19:51 Kyoukai [86]: Session data: From 2019-04-20, 19:29:24 to 2019-04-20, 19:50:45 Session: 00:21h XP Gain: 330 XP/h: 2,505 Loot: 0 Supplies: 442 Balance: -442 Damage: 230 Damage/h: 230 Healing: 149 Healing/h: 149 Killed Monsters: 8x orc berserker 1x orc leader 4x orc"; 
            result.FirstAnalysers.Compute(result.FirstAnalysers.Message);
            result.SecondAnalysers = new Analyser();
            result.SecondAnalysers.Message = @"19:28 Knight Marofado [336]: Session data: From 2019-04-20, 17:07:45 to 2019-04-20, 19:27:49 Session: 02:20h XP Gain: 1,106,897 XP/h: 144,992 Loot: 341,709 Supplies: 191,138 Balance: 150,571 Damage: 368,163 Damage/h: 232,074 Healing: 246,416 Healing/h: 107,992 Killed Monsters: 46x";
            result.SecondAnalysers.Compute(result.SecondAnalysers.Message);
            result.Compute();

            Assert.IsTrue(result.Profit);
        }

        [Test]
        public void ProfitNegative()
        {
            Result result = new Result();
            result.FirstAnalysers = new Analyser();
            result.FirstAnalysers.Message = @"19:51 Kyoukai [86]: Session data: From 2019-04-20, 19:29:24 to 2019-04-20, 19:50:45 Session: 00:21h XP Gain: 330 XP/h: 2,505 Loot: 200,000 Supplies: 100,000 Balance: -442 Damage: 230 Damage/h: 230 Healing: 149 Healing/h: 149 Killed Monsters: 8x orc berserker 1x orc leader 4x orc";
            result.FirstAnalysers.Compute(result.FirstAnalysers.Message);
            result.SecondAnalysers = new Analyser();
            result.SecondAnalysers.Message =@"19:28 Knight Marofado [336]: Session data: From 2019-04-20, 17:07:45 to 2019-04-20, 19:27:49 Session: 02:20h XP Gain: 1,106,897 XP/h: 144,992 Loot: 41,709 Supplies: 191,138 Balance: 150,571 Damage: 368,163 Damage/h: 232,074 Healing: 246,416 Healing/h: 107,992 Killed Monsters: 46x";
            result.SecondAnalysers.Compute(result.SecondAnalysers.Message);
            result.Compute();

            Assert.IsFalse(result.Profit);
        }
    }
}
