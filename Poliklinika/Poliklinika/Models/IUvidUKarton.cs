﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
   public  interface IUvidUKarton
    {
        void izlistajNalaze();
        void izlistajAktuelneNalaze();
        void izlistajTrenutnuTerapiju();

        void izlistajHistorijuTerapija();

    }
}
