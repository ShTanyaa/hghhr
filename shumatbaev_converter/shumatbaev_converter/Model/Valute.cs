﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shumatbaev_converter.Model
{
    public class Valute
    {
        public int Code { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{Nominal} {Name}";
        }
    }

}
