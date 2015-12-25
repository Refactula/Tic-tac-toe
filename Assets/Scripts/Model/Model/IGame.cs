using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGame
{

    Mark Get(int column, int row);

    Mark GetCurrentMark();

    bool IsGameOvered();

    Line GetWinningLine();

    Mark GetWinnerMark();

}
