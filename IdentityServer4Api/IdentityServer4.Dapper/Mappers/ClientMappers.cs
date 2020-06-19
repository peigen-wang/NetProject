using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Dapper.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>()).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.Client ToModel(this Entities.Client entity)
        {
            return Mapper.Map<Models.Client>(entity);
        }

        public static Entities.Client ToEntity(this Models.Client model)
        {
            return Mapper.Map<Entities.Client>(model);
        }
    }
}
