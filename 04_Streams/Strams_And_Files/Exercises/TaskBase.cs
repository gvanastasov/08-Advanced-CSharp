using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public abstract class TaskBase
    {
        private string _displayName = string.Empty;
        public string DisplayName
        {
            get
            {
                if(string.IsNullOrEmpty(_displayName))
                {
                    _displayName = Utils.SplitCamelCase(this.GetType().Name);
                }
                return _displayName;
            }
        }

        public abstract void Execute();

    }
}
