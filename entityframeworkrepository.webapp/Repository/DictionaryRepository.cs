using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Web.Helpers;
using entityframeworkrepository.repository;
using entityframeworkrepository.repository.cache;


namespace entityframeworkrepository.webapp.Repository
{
    public class DictionaryRepository : GenericCacheRepository<Dictionary>
    {
        public DictionaryRepository(DbContext context) : base(context)
        {
        }
    }
}