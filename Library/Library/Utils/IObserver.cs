using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public interface IObserver
    {
        public void UpdateObserver();

        public Book WhatBook();
    }
}
