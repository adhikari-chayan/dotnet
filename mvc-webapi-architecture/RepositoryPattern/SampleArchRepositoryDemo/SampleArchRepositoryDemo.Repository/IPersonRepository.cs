﻿using SampleArchRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArchRepositoryDemo.Repository
{
   public interface IPersonRepository:IGenericRepository<Person>
    {
        Person GetById(long id);
    }
}
