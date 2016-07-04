using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiHunter.GameData
{
    interface IShooting
    {
        int Damage { get; set; }

        float ShootingSpeed { get; }

        float ShootingDelay { get;  }

        float SightSpeed { get;  }

    }
}
