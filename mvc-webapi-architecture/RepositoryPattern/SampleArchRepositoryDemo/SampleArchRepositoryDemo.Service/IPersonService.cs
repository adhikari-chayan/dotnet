using SampleArchRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArchRepositoryDemo.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long id);
    }
}
