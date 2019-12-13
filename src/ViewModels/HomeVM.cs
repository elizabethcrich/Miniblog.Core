using Miniblog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniblog.Core.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<string> Categories { get; set; }
    }
}
