using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationeryStoreSystem.Models
{
    public class DupIDeException:Exception
    {
        public DupIDeException(string message): base(message) {
        }
    }
}