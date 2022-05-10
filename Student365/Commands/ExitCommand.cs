using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student365.Commands
{
    public class ExitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}