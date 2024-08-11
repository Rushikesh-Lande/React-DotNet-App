using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.DbConnectionModels
{
    public class TransactionDBSettings
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
        public string? TransactionCollectionName
        {
            get;
            set;
        }
    }
}
