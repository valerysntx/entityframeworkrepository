using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.repository;
using entityframeworkrepository.webapp.Repository;
using Dictionary = entityframeworkrepository.Dictionary;

namespace entityframeworkrepository.webapp.Controllers
{
    [AllowAnonymous]
    public class DictionaryController : ApiController
    {
        private readonly IGenericDataRepository<Dictionary> _repository = null;
        private readonly IWorkBenchContext _ctx = null;

        public DictionaryController()
        {
            _ctx = new WorkBenchContext();
            _repository = new DictionaryRepository((DbContext) _ctx);
        }


        public DictionaryController(IGenericDataRepository<Dictionary> repository, IWorkBenchContext ctx)
        {
            _ctx = ctx ?? new WorkBenchContext();
            if (repository == null) repository = new DictionaryRepository((DbContext) _ctx);
            _repository = repository;
        }

        // GET: api/Dictionary
        public IEnumerable<Dictionary> Get()
        {
            return _repository.GetAll(x => x.People).ToList();
        }

        // GET: api/Dictionary paged list tests
        public IEnumerable<Dictionary> Get(int page, int count)
        {
            DictionaryRepository repository = (DictionaryRepository) _repository;
            return repository.GetPagedList(x => x.IsDeleted.GetValueOrDefault(false) == false, page, count, people => people.People);
        }

        // GET: api/Dictionary/5
        public Dictionary Get(int id)
        {
            return _repository.GetSingle(x => x.Id2.GetValueOrDefault() == id);
        }

        // POST: api/Dictionary
        public void Post([FromBody]Dictionary value)
        {
            _repository.Add(value);
        }

        // PUT: api/Dictionary/5
        public void Put(int id, [FromBody]Dictionary value)
        {
            var item = _repository.GetSingle(x => x.Id2 == id);
            if (item != null)
            {
                _repository.Update(value);
            }
        }

        // DELETE: api/Dictionary/5
        public void Delete(int id)
        {
            _repository.Remove(_repository.GetSingle(x => x.Id2 == id));
        }
    }
}
