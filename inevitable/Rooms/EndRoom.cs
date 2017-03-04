using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Llatext.Rooms
{
    public interface IEndRoom: IRoom
    {
        /// <summary>
        /// Sets the cause of death and how long the player has survived for
        /// </summary>
        /// <param name="cause"></param>
        /// <param name="day"></param>
        void SetCauseOfDeath(string cause);

    }
}
