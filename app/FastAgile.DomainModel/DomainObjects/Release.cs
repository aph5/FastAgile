using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastAgile.DomainModel.DomainObjects
{
    public class Release
    {
        private int _realseNumber;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private List<Iteration> _iterations;
    }
}
