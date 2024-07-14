using Application.Services;
using Core.Dapper.Concrete;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Persistance.Repositories;
public sealed class ArabaRepository(IConfiguration configuration) : DapperBase<Araba>(configuration), IArabaRepository
{
}
