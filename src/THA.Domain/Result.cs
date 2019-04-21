using System;
using System.Collections.Generic;

namespace THA.Domain
{
    public class Result
    {
        public Guid Id { get; set; }
        public bool Profit { get; set; }
        public int WasteTotal { get; set; }
        public int ProfitTotal { get; set; }
        public int ProfitParcial { get; set; }
        public Analyser FirstAnalysers { get; set; }
        public Analyser SecondAnalysers { get; set; }
        public Analyser ThirdAnalysers { get; set; }
        public Analyser FourthAnalysers { get; set; }

        public Result()
        {
            Id = Guid.NewGuid();
            FirstAnalysers = new Analyser();
            SecondAnalysers = new Analyser();
            ThirdAnalysers = new Analyser();
            FourthAnalysers = new Analyser();
        }

        public void Compute()
        {
            int total = 0, players = 0, waste = 0;

            if (!String.IsNullOrEmpty(this.FirstAnalysers.Message))
            {
                total += this.FirstAnalysers.Loot;
                waste += this.FirstAnalysers.Suplies;
                players++;
            }
            if (!String.IsNullOrEmpty(this.SecondAnalysers.Message))
            {
                total += this.SecondAnalysers.Loot;
                waste += this.SecondAnalysers.Suplies;
                players++;
            }
            if (!String.IsNullOrEmpty(this.ThirdAnalysers.Message))
            {
                total += this.ThirdAnalysers.Loot;
                waste += this.ThirdAnalysers.Suplies;
                players++;
            }
            if (!String.IsNullOrEmpty(this.FourthAnalysers.Message))
            {
                total += this.FourthAnalysers.Loot;
                waste += this.FourthAnalysers.Suplies;
                players++;
            }
            this.WasteTotal = waste;
            this.ProfitTotal = total;

            if (total > waste)
            {
                this.Profit = true;
                this.ProfitParcial = (total - waste) / players;

                if (!String.IsNullOrEmpty(this.FirstAnalysers.Message))
                {
                    this.FirstAnalysers.Payback = this.FirstAnalysers.Suplies + ProfitParcial;
                }
                if (!String.IsNullOrEmpty(this.SecondAnalysers.Message))
                {
                    this.SecondAnalysers.Payback = this.SecondAnalysers.Suplies + ProfitParcial;
                }
                if (!String.IsNullOrEmpty(this.ThirdAnalysers.Message))
                {
                    this.ThirdAnalysers.Payback = this.ThirdAnalysers.Suplies + ProfitParcial;
                }
                if (!String.IsNullOrEmpty(this.FourthAnalysers.Message))
                {
                    this.FourthAnalysers.Payback = this.FourthAnalysers.Suplies + ProfitParcial;
                }
            }
            else
            {
                this.Profit = false;
                this.ProfitParcial = (total - waste) / players;
                int porcentagem = 0;

                if (waste == 0)
                    waste = 1;

                if (!String.IsNullOrEmpty(this.FirstAnalysers.Message))
                {
                    porcentagem = (this.FirstAnalysers.Suplies  * 100) / waste;
                    this.FirstAnalysers.Payback = (total /100) *porcentagem ;
                }
                if (!String.IsNullOrEmpty(this.SecondAnalysers.Message))
                {
                    porcentagem = (this.SecondAnalysers.Suplies * 100) / waste;
                    this.SecondAnalysers.Payback = (total / 100) * porcentagem;
                }
                if (!String.IsNullOrEmpty(this.ThirdAnalysers.Message))
                {
                    porcentagem = (this.ThirdAnalysers.Suplies  * 100) / waste;
                    this.ThirdAnalysers.Payback = (total / 100) * porcentagem;
                }
                if (!String.IsNullOrEmpty(this.FourthAnalysers.Message))
                {
                    porcentagem = (this.FourthAnalysers.Suplies  * 100) / waste;
                    this.FourthAnalysers.Payback = (total / 100) * porcentagem;
                }
            }
        }
    }
}
