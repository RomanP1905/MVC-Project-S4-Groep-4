using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectAO_Wagenpark.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectAO_Wagenpark.DataAccesLayer
{
    public class WagenparkInitializer
    {
        public class wagenparkInitializer : System.Data.Entity.
            DropCreateDatabaseAlways<WagenparkContext>
        {
            protected override void Seed(WagenparkContext context)
            {
                var autos = new List<Auto>
                {
                    new Auto{
                        kenteken ="8PTS26",
                        merk ="Nissan",
                        Type ="Quasqai"
                    },
                    new Auto{
                        kenteken ="4XJK76",
                        merk ="Ford",
                        Type ="Focus"
                    }
            };
                autos.ForEach(s => context.Autos.Add(s));
                context.SaveChanges();

                var dealers = new List<Dealer>
                {
                    new Dealer
                    {
                        dealernr =34,
                        naam ="Vroegop"
                    },
                    new Dealer
                    {
                    dealernr = 73,
                    naam = "Bosmans"
                    }
                    };
                dealers.ForEach(s => context.Dealers.Add(s));
                context.SaveChanges();
                var werkplaats = new List<Werkplaats>
                {
                    new Werkplaats
                    {
                        werkplaatsnr = 2,
                        naam = "Quick"
                    },
                    new Werkplaats
                    {
                        werkplaatsnr = 18,
                        naam = "Cheap"
                    },
                    new Werkplaats
                    {
                        werkplaatsnr = 14,
                        naam = "Fixit"
                    },
                    new Werkplaats
                    {
                        werkplaatsnr = 6,
                        naam = "C&G"
                    }
                };
                werkplaats.ForEach(s => context.Werkplaats.Add(s));
                context.SaveChanges();

                var Onderhoud = new List<Onderhoud>
                {
                    new Onderhoud
                    {
                        onderhoudsdatum = Convert.ToDateTime("2016-03-16"),
                        kosten = 345
                    },
                    new Onderhoud
                    {
                        onderhoudsdatum = Convert.ToDateTime("2016-09-24"),
                        kosten = 128
                    }
                    
                };
                Onderhoud.ForEach(s => context.Onderhouds.Add(s));
                context.SaveChanges();
            }
        }
    }
}
