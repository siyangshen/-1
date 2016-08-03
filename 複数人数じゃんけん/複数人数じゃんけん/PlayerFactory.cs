namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AbstractFactory
    /// </summary>
    public abstract class PlayerFactory
    {
        /// <summary>
        /// Methods
        /// </summary>
        /// <returns>PlayerFist</returns>
        public abstract Player CreatePlayer();
    }

    /// <summary>
    /// UserPlayerFactory
    /// </summary>
    public class UserPlayerFactory : PlayerFactory
    {
        /// <summary>
        /// Methods
        /// </summary>
        /// <returns>PlayerFist</returns>
        public override Player CreatePlayer()
       {
          return new User();
       }
    }

    /// <summary>
    /// CpuPlayerFactory
    /// </summary>
    public class CpuPlayerFactory : PlayerFactory
    {
        /// <summary>
        /// Methods
        /// </summary>
        /// <returns>PlayerFist</returns>
        public override Player CreatePlayer()
        {
            return new Cpu();
        }
    }
}
