﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsApi.Interfaces
{
    public interface WebDriverInterface
    {
        Task<string> RunDriverClient(string url);

        void StatusTestCode();
    }
}