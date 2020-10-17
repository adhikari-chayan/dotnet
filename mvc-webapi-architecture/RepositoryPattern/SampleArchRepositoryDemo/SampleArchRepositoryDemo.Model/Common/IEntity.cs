using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArchRepositoryDemo.Model
{
    //All entities need to have an Id
   public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
