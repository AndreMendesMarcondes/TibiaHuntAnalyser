using System;

namespace THA.Domain
{
    public class Analyser
    {
        #region [ Properties ]
        public string Character { get; set; }
        public string Session { get; set; }
        public int Loot { get; set; }
        public int Suplies { get; set; }
        public int Balance { get; set; }
        public int Payback { get; set; }
        public string Message { get;set; }
        #endregion

        #region [ Constructor ]
        public void Compute(string message)
        {
            this.Character = GetCharacter(message);
            this.Session = GetSession(message);
            this.Loot = Convert.ToInt32(GetLoot(message));
            this.Suplies = Convert.ToInt32(GetSuplies(message));
            this.Balance = Convert.ToInt32(GetBalance(message));
        }
        #endregion

        #region [ Methods ]
        private string GetCharacter(string message)
        {
            if (message.Contains("["))
                return message.Substring(6, (message.IndexOf("[", 0) - 7));

            return "No Name";
        }
        private string GetSession(string message)
        {
            return GetBetween(message, "Session:", "XP Gain").Trim();
        }
        private string GetLoot(string message)
        {
            return GetBetween(message, "Loot:", "Supplies").Trim().Replace(",","");
        }
        private string GetSuplies(string message)
        {
            return GetBetween(message, "Supplies:", "Balance:").Trim().Replace(",", "");
        }
        private string GetBalance(string message)
        {
            return GetBetween(message, "Balance:", "Damage:").Trim().Replace(",", "");
        }

        private string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
