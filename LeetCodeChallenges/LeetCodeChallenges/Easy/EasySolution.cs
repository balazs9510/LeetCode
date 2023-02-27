using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
    public partial class EasySolution
    {
		private static EasySolution? _instance;

        public static EasySolution Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EasySolution();
                }
                return _instance;
            }
        }

        private EasySolution()
		{
			
		}

	}
}
