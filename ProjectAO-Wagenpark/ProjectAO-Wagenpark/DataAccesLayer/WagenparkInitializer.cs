using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectAO_Wagenpark.Models;

namespace ProjectAO_Wagenpark.DataAccesLayer
{
    public class WagenparkInitializer
    {
        public class SchoolInitializer : System.Data.Entity.
            DropCreateDatabaseIfModelChanges<WagenparkContext>
        {
            protected override void Seed(WagenparkContext context)
            {
                var autos = new List<Auto>
                {
                    new Auto{
                        Kenteken ="8PTS26",
                        Merk ="Nissan",
                        Type ="Quasqai"
                    },
                    new Auto{
                        Kenteken ="4XJK76",
                        Merk ="Ford",
                        Type ="Focus"
                    }
            };
                autos.ForEach(s => context.Autos.Add(s));
                context.SaveChanges();

                var dealers = new List<Dealer>
                {
                    new Dealer
                    {
                        DealerNR =34,
                        Naam ="Vroegop"
                    },
                    new Dealer
                    {
                    DealerNR = 73,
                    Naam = "Bosmans"
                    }
                    };
                dealers.ForEach(s => context.Dealers.Add(s));
                context.SaveChanges();
                var werkplaats = new List<Werkplaats>
                {
                    new Werkplaats
                    {
                        WerkplaatsNr = 2,
                        Naam = "Quick"
                    },
                    new Werkplaats
                    {
                        WerkplaatsNr = 18,
                        Naam = "Cheap"
                    },
                    new Werkplaats
                    {
                        WerkplaatsNr = 14,
                        Naam = "Fixit"
                    },
                    new Werkplaats
                    {
                        WerkplaatsNr = 6,
                        Naam = "C&G"
                    }
                };
                werkplaats.ForEach(s => context.Werkplaats.Add(s));
                context.SaveChanges();

                var Onderhoud = new List<Onderhoud>
                {
                    new Onderhoud
                    {
                        OnderhoudsDatum = 100316,
                        OnderhoudsKosten = 345
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 240916,
                        OnderhoudsKosten = 128
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 070317,
                        OnderhoudsKosten = 175
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 021117,
                        OnderhoudsKosten = 405
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 141016,
                        OnderhoudsKosten = 190
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 140417,
                        OnderhoudsKosten = 225
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 211017,
                        OnderhoudsKosten = 310
                    },
                    new Onderhoud
                    {
                        OnderhoudsDatum = 190418,
                        OnderhoudsKosten = 290
                    }
                };
                Onderhoud.ForEach(s => context.Onderhouds.Add(s));
                context.SaveChanges();
            }
        }
    }
}
