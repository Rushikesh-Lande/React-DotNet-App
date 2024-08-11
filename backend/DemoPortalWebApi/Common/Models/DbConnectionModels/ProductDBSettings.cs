using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.DbConnectionModels
{
    public class ProductDBSettings
    {
        public string? ConnectionString
        {
            get;
            set;
        }
        public string? DatabaseName
        {
            get;
            set;
        }
        public string? ProductCollectionName
        {
            get;
            set;
        }
    }
}
